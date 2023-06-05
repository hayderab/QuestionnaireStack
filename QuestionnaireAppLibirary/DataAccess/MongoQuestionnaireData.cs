using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;

namespace QuestionnaireAppLibirary.DataAccess
{
    public class MongoQuestionnaireData : IQuestionnaireData
    {
        private readonly IDbconnection _db;
        private readonly IUserData _userData;
        private readonly IMemoryCache _cache;
        private readonly IMongoCollection<QuestionnaireModel> _questionnaire;
        private const string CacheName = "QuestionnarieData";

        public MongoQuestionnaireData(IDbconnection db, IUserData userData, IMemoryCache cache)
        {
            _db = db;
            _userData = userData;
            _cache = cache;
            _questionnaire = db.QuestionnaireCollection;
        }


        public async Task<List<QuestionnaireModel>> GetAllQuesionnaire()
        {
            var output = _cache.Get<List<QuestionnaireModel>>(CacheName);

            if (output is null)
            {
                var results = await _questionnaire.FindAsync(s => s.Archived == false);   // limiting the questionare we want to get back eg not archieved.
                output = results.ToList();
                _cache.Set(CacheName, output, TimeSpan.FromMinutes(value: 1));
            }

            return output;
        }


        public async Task<List<QuestionnaireModel>> GetUserQuestionnaire(string userId)
        {
            var output = _cache.Get<List<QuestionnaireModel>>(userId);

            if (output is null)
            {
                var result = await _questionnaire.FindAsync(s => s.Author.Id == userId);
                output = result.ToList();

                _cache.Set(userId, output, TimeSpan.FromMinutes(value:1));
            }

            return output;
        }

        public async Task<List<QuestionnaireModel>> GetAllApprovedQuestionnaire()
        {
            var output = await GetAllQuesionnaire();
            return output.Where(x => x.ApprovedForRelease).ToList();
        }



        public async Task<QuestionnaireModel> GetQuestionnaire(string id)
        {
            var results = await _questionnaire.FindAsync(s => s.Id == id);

            return results.FirstOrDefault();
        }



        public async Task<List<QuestionnaireModel>> GetAllQuestionnaireForApproval()
        {
            var output = await GetAllQuesionnaire();

            return output.Where(x => x.ApprovedForRelease == false && x.Rejected == false).ToList();
        }


        public async Task UpdateQuestionnaire(QuestionnaireModel questionnaire)
        {
            await _questionnaire.ReplaceOneAsync(s => s.Id == questionnaire.Id, questionnaire);
            _cache.Remove(CacheName);
        }



        public async Task UpVoteQuestionnaire(string questionnaireId, string userId)
        {
            var client = _db.Client;

            using var session = await client.StartSessionAsync();

            session.StartTransaction();

            try
            {
                var db = client.GetDatabase(_db.DbName);
                var questionnaireInTransaction = db.GetCollection<QuestionnaireModel>(_db.QuestionnaireCollectionName);
                var questionnaire = (await questionnaireInTransaction.FindAsync(s => s.Id == questionnaireId)).First();



                bool isUpVote = questionnaire.UserVotes.Add(userId);
                if (isUpVote == false)
                {
                    questionnaire.UserVotes.Remove(userId);
                }


                await questionnaireInTransaction.ReplaceOneAsync(s => s.Id == questionnaireId, questionnaire);


                var usersInTransction = db.GetCollection<UserModal>(_db.UserCollectionName);
                var user = await _userData.GetUser(questionnaire.Author.Id);

                if (isUpVote)
                {
                    user.VotedOnQuestionnaire.Add(item: new BasicQuestionnaireModel(questionnaire));
                }
                else
                {
                    var questionnaireToRemove = user.VotedOnQuestionnaire.Where(s => s.Id == questionnaireId).First();
                    user.VotedOnQuestionnaire.Remove(questionnaireToRemove);
                }

                await usersInTransction.ReplaceOneAsync(u => u.Id == userId, user);
                await session.CommitTransactionAsync();

                _cache.Remove(CacheName);

            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw;
            }


        }



        public async Task CreateQuestionnaire(QuestionnaireModel questionnaire)
        {
            var client = _db.Client;

            using var session = await client.StartSessionAsync();

            session.StartTransaction();

            try
            {
                var db = client.GetDatabase(_db.DbName);
                var questionnaireInTransaction = db.GetCollection<QuestionnaireModel>(_db.QuestionnaireCollectionName);

                //questionnaire.Questions = questions;

                await questionnaireInTransaction.InsertOneAsync(questionnaire);


                var userInTranscation = db.GetCollection<UserModal>(_db.UserCollectionName);
                var user = await _userData.GetUser(questionnaire.Author.Id);
                user.AuthoredQuestionnaire.Add(item: new BasicQuestionnaireModel(questionnaire));
                await userInTranscation.ReplaceOneAsync(u => u.Id == user.Id, user);

                await session.CommitTransactionAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}

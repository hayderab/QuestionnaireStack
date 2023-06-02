

using MongoDB.Bson.Serialization.Serializers;

namespace QuestionnaireAppLibirary.DataAccess
{
    public class MongoUserData : IUserData
    {

        private readonly IMongoCollection<UserModal> _users;


        public MongoUserData(IDbconnection db)
        {
            _users = db.UserCollection;
        }


        public async Task<List<UserModal>> GetUserAsync()
        {
            var results = await _users.FindAsync(_ => true); // return all records
            return results.ToList();
        }


        // getting user based on Id
        public async Task<UserModal> GetUser(string id)
        {
            var results = await _users.FindAsync(u => u.Id == id);
            return results.FirstOrDefault();
        }

        // getting object id for authentication
        public async Task<UserModal> GetUserFromAuthentication(string objectId)
        {
            var results = await _users.FindAsync(u => u.Id == objectId);
            return results.FirstOrDefault();
        }


        public Task CreateUser(UserModal user)
        {
            return _users.InsertOneAsync(user);
        }

        public Task UpdateUser(UserModal user)
        {
            var filter = Builders<UserModal>.Filter.Eq(field: "Id", user.Id);
            return _users.ReplaceOneAsync(filter, user, options: new ReplaceOptions { IsUpsert = true }); // update in found else create one

        }
    }
}

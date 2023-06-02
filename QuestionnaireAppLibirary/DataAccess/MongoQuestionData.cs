using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireAppLibirary.DataAccess
{
    public class MongoQuestionData
    {

        private readonly IDbconnection _db; 
        private readonly IMongoCollection<QuestionModel> _questions;
        private readonly IMemoryCache _cache;

        private const string CacheName = "QuestionData";

       public MongoQuestionData(IDbconnection db, IMemoryCache cache)
        {
            _db  = db;
            _cache = cache;
            _questions = db.QuestionCollection; 
        }


        public async Task<List<QuestionModel>> GetAllQuestions()
        {
            var output = _cache.Get<List<QuestionModel>>(CacheName); 
            if(output == null)
            {
                var results = await _questions.FindAsync(_ => true);
                output = results.ToList();
            }
            return output;
        }

        public async Task<QuestionModel> CreateQuestions(QuestionModel question)
        {

            var output  = await _questions.
            return null; 
        }
  


   


    }
}

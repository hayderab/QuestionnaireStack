using Microsoft.Extensions.Caching.Memory;

namespace QuestionnaireAppLibirary.DataAccess
{
    public class MongoStatusData : IStatusData
    {

        private readonly IMongoCollection<StatusModal> _statuses;
        private readonly IMemoryCache _cache;
        private const string cacheName = "StatusData";

        public MongoStatusData(IDbconnection db, IMemoryCache cache)
        {
            _cache = cache;
            _statuses = db.StatusCollection;
        }



        public async Task<List<StatusModal>> GetAllStatus()
        {
            var output = _cache.Get<List<StatusModal>>(cacheName);

            if (output == null)
            {
                var result = await _statuses.FindAsync(_ => true);
                output = result.ToList();

                _cache.Set(cacheName, output, TimeSpan.FromDays(value: 1));// 1 day

            }
            return output;
        }


        public Task CreateStatus(StatusModal status)
        {
            return _statuses.InsertOneAsync(status);
        }
    }
}

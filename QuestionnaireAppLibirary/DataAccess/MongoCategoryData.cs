

using Microsoft.Extensions.Caching.Memory;

namespace QuestionnaireAppLibirary.DataAccess;

public class MongoCategoryData : ICategoryData
{
    private readonly IMongoCollection<CategoryModel> _categories;
    private readonly IMemoryCache _cache;
    private const string cacheName = "CatageoryData";

    public MongoCategoryData(IDbconnection db, IMemoryCache cache)
    {
        _cache = cache;
        _categories = db.CategoryCollection;
    }


    public async Task<List<CategoryModel>> GetAllCategories()
    {
        var output = _cache.Get<List<CategoryModel>>(cacheName);
        // if data is not cached.
        if (output == null)
        {
            var result = await _categories.FindAsync(_ => true);
            output = result.ToList();

            _cache.Set(cacheName, output, TimeSpan.FromDays(value: 1));// get new list everyday.
        }
        return output;
    }


    public Task CreateCategory(CategoryModel category)
    {
        return _categories.InsertOneAsync(category); 
    }


}


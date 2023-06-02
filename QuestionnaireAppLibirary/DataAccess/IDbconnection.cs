using MongoDB.Driver;

namespace QuestionnaireAppLibirary.DataAccess
{
    public interface IDbconnection
    {
        IMongoCollection<CategoryModel> CategoryCollection { get; }
        string CategoryCollectionName { get; }
        MongoClient Client { get; }
        string DbName { get; }
        IMongoCollection<QuestionModel> QuestionCollection { get; }
        string QuestionCollectionName { get; }
        IMongoCollection<QuestionnaireModel> QuestionnaireCollection { get; }
        string QuestionnaireCollectionName { get; }
        IMongoCollection<StatusModal> StatusCollection { get; }
        string StatusCollectionName { get; }
        IMongoCollection<UserModal> UserCollection { get; }
        string UserCollectionName { get; }
    }
}
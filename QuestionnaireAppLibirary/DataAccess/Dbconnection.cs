
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace QuestionnaireAppLibirary.DataAccess;

public class Dbconnection : IDbconnection
{

    private readonly IConfiguration _config;
    private readonly IMongoDatabase _db;            //internally useable
    private string _connectionId = "MongoDB";


    public string DbName { get; private set; }
    public string CategoryCollectionName { get; private set; } = "catergories";
    public string StatusCollectionName { get; private set; } = "status";
    public string UserCollectionName { get; private set; } = "user";
    public string QuestionnaireCollectionName { get; private set; } = "questionnaire";
    public string QuestionCollectionName { get; private set; } = "questions";




    public MongoClient Client { get; private set; } // client connects to database then we connect to collection/tables
    // connection to tables
    public IMongoCollection<CategoryModel> CategoryCollection { get; private set; }
    public IMongoCollection<StatusModal> StatusCollection { get; private set; }
    public IMongoCollection<QuestionnaireModel> QuestionnaireCollection { get; private set; }
    public IMongoCollection<UserModal> UserCollection { get; private set; }


    public IMongoCollection<QuestionModel> QuestionCollection { get; private set; }


    // constructor
    public Dbconnection(IConfiguration config)
    {
        _config = config;
        Client = new MongoClient(_config.GetConnectionString(_connectionId));
        DbName = _config[key: "DatabaseName"];
        _db = Client.GetDatabase(DbName);


        // only initiate database once and reuse collection connetion and enhance performance.
        CategoryCollection = _db.GetCollection<CategoryModel>(CategoryCollectionName);
        StatusCollection = _db.GetCollection<StatusModal>(StatusCollectionName);
        QuestionnaireCollection = _db.GetCollection<QuestionnaireModel>(QuestionnaireCollectionName);
        UserCollection = _db.GetCollection<UserModal>(UserCollectionName);
        QuestionCollection = _db.GetCollection<QuestionModel>(QuestionCollectionName);
    }





}
 
namespace QuestionnaireAppLibirary.DataAccess
{
    public interface IMongoQuestionnaireData
    {
        Task CreateQuestionnaire(QuestionnaireModel questionnaire);
        Task<List<QuestionnaireModel>> GetAllApprovedQuestionnaire();
        Task<List<QuestionnaireModel>> GetAllQuesionnaire();
        Task<List<QuestionnaireModel>> GetAllQuestionnaireForApproval();
        Task<QuestionnaireModel> GetQuestionnaire(string id);
        Task UpdateQuestionnaire(QuestionnaireModel questionnaire);
        Task UpVoteQuestionnaire(string questionnaireId, string userId);
    }
}
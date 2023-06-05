namespace QuestionnaireAppLibirary.DataAccess
{
    public interface IQuestionnaireData
    {
        Task CreateQuestionnaire(QuestionnaireModel questionnaire);
        Task<List<QuestionnaireModel>> GetAllApprovedQuestionnaire();
        Task<List<QuestionnaireModel>> GetAllQuesionnaire();
        Task<List<QuestionnaireModel>> GetAllQuestionnaireForApproval();
        Task<QuestionnaireModel> GetQuestionnaire(string id);
        Task<List<QuestionnaireModel>> GetUserQuestionnaire(string userId);
        Task UpdateQuestionnaire(QuestionnaireModel questionnaire);
        Task UpVoteQuestionnaire(string questionnaireId, string userId);
    }
}
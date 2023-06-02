namespace QuestionnaireAppLibirary.DataAccess
{
    public interface IStatusData
    {
        Task CreateStatus(StatusModal status);
        Task<List<StatusModal>> GetAllStatus();
    }
}
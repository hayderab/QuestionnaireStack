namespace QuestionnaireAppLibirary.DataAccess
{
    public interface IUserData
    {
        Task CreateUser(UserModal user);
        Task<UserModal> GetUser(string id);
        Task<List<UserModal>> GetUserAsync();
        Task<UserModal> GetUserFromAuthentication(string objectId);
        Task UpdateUser(UserModal user);
    }
}
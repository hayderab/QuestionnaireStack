

namespace QuestionnaireAppLibirary.Models
{
    public class BasicUserModal
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }


        public BasicUserModal()
        {
            
        }

        public BasicUserModal(UserModal user)
        {
            Id = user.Id;
            DisplayName = user.DisplayName;
            
        }

    }
}

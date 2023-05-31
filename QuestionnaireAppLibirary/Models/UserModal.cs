
namespace QuestionnaireAppLibirary.Models
{
    public class UserModal
    {

        public int Id { get; set; }

         public string ObjectIndentifier { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public List<BasicQuestionnaireModel> AuthoredQuestionnaire { get; set; } = new();
        public List<BasicQuestionnaireModel> VotedOnQuestionnaire { get; set; } = new();


    }
}

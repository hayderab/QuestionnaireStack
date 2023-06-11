
namespace QuestionnaireAppLibirary.Models
{  

    // TODO : Create Id, Saperate table
    public class QuestionModel
    {
        public string Question { get; set; }
        public List<OptionModel> Options { get; set; } = new(); // List of available options for the question
        public int CorrectAnswerIndex { get; set; } // Index of the correct answer within the Options list
    }

    public class OptionModel
    {
        public string Option { get; set; }
    }
}

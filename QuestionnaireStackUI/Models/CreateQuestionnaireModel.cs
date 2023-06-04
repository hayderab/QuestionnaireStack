using System.ComponentModel.DataAnnotations;

namespace QuestionnaireStackUI.Models
{
    public class CreateQuestionnaireModel
    {
        [Required]
        [MaxLength(75)]
        public string QuestionnaireTitle { get; set; }

        [Required]
        [MinLength(1)]
        [Display(Name = "Category")]
        public string CategoryId { get; set; }

        [Required]
        [MaxLength(500)]
        public string QuestionnaireDesc { get; set; }

        public List<QuestionModel> Questions { get; set; } = new List<QuestionModel>();


    }
}

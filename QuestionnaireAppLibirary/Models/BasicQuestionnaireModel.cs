using MongoDB.Bson.Serialization.Attributes;

namespace QuestionnaireAppLibirary.Models
{
    public class BasicQuestionnaireModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string QuestionnaireTitle { get; set; }


        public BasicQuestionnaireModel() { }


        public BasicQuestionnaireModel (QuestionnaireModel questionnaire)
        {
            Id = questionnaire.Id;
            QuestionnaireTitle = questionnaire.QuestionnaireTitle;
        }
         
    }
}

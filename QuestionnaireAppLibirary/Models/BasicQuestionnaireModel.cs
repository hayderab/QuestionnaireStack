using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireAppLibirary.Models
{
    public class BasicQuestionnaireModel
    {

        public string Id { get; set; }

        public string Questionnaire { get; set; }

        public BasicQuestionnaireModel() { }


        public BasicQuestionnaireModel (BasicQuestionnaireModel questionnaire)
        {
            Id = questionnaire.Id;
            Questionnaire = questionnaire.Id;
        }
         
    }
}

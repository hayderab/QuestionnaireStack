using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireAppLibirary.Models
{
    public  class QuestionnaireModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string QuestionnaireTitle { get; set; }

        public string QuestionnaireDesc { get; set;}

         
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public CategoryModel Category { get; set; }

        public BasicUserModal Author { get; set; }

        public HashSet<string> UserVotes { get; set; } = new();

        public StatusModal QuestionnaireStatus { get; set; }

        public string OwnerNotes { get; set; }


        public bool ApprovedForRelease { get; set; } = false;

        public bool Archived { get; set; } = false;

        public bool Rejected { get; set; } = false;

        public List<BasicQuestionnaireModel> VotedOnQuestionnaire { get; set; } = new();

        public List<BasicQuestionnaireModel> AuthoredQuestionnaire { get; set; } = new();

        public List<QuestionModel> Questions { get; set; } = new List<QuestionModel>();

    }
}

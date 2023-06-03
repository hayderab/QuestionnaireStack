using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireAppLibirary.Models
{
  
    public class StatusModal
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
       
        public string Id { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }


    }
}

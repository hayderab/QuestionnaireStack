﻿

using MongoDB.Bson.Serialization.Attributes;

namespace QuestionnaireAppLibirary.Models
{
    public class BasicUserModal
    {
        [BsonRepresentation(BsonType.ObjectId)]

        public string  Id { get; set; }
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

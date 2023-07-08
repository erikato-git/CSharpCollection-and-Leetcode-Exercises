using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoDB
{
    internal class PersonModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]     // auto-id
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbCRUD.Models
{
    [BsonIgnoreExtraElements]   // ignore extra elements from MongoDb
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]    // converts mongo-data type to dotnet data-type and vice versa
        public string Id { get; set; } = string.Empty;
        
        [BsonElement("name")]   // name in the document
        public string Name { get; set; } = string.Empty;

        [BsonElement("graduated")]
        public bool IsGraduated { get; set; }

        [BsonElement("courses")]
        public string[]? Courses { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; } = string.Empty;

        [BsonElement("age")]
        public int Age { get; set; }

    }
}

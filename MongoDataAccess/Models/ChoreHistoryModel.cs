using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDataAccess.Models
{
    public class ChoreHistoryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ChoreId { get; set; }
        public string ChoreText { get; set; }
        public DateTime DateCompleted { get; set; }
        public UserModel WhoCompleted { get; set; }

        public ChoreHistoryModel()
        {
            
        }

        // Update-model
        public ChoreHistoryModel(ChoreModel chore)
        {
            ChoreId = chore.Id;
            DateCompleted = chore.LastCompleted ?? DateTime.Now;
            WhoCompleted = chore.AsssignTo;
            ChoreText = chore.ChoreText;
        }

    }
}

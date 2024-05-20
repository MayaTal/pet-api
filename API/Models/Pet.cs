using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API.Models
{ 

    public class Pet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("color")]
        public string Color { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("createdAt")]
        public DateTime? CreatedAt { get; set; }
    }

}

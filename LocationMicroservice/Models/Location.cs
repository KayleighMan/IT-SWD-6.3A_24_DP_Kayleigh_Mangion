using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LocationMicroservice.Models
{
    public class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Email { get; set; } 
        public string City { get; set; }
        public string Nickname { get; set; } 
    }
}

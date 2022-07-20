using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Micro.Services.ACC.Entity
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Familly { get; set; }
        public string? Mob { get; set; }
    }
}

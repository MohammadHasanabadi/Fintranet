using MongoDB.Bson.Serialization.Attributes;

namespace Micro.Services.ACC.Entity
{
    public class Group
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("GroupName")]
        public string GroupName { get; set; }

        [BsonElement("GroupCode")]
        public string GroupCode { get; set; }
    }
}

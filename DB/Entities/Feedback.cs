using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyBlog.DB.Entities
{
    public class Feedback
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;
        [BsonElement("content")]
        public string Content { get; set; } = string.Empty;
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }



    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyBlog.DB.Entities
{
    public class Tool
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("icon")]
        public string Icon { get; set; } = string.Empty;
        [BsonElement("selector")]
        public string Selector { get; set; } = string.Empty;
        [BsonElement("viewer")]
        public string Viewer { get; set; } = string.Empty;


    }
}

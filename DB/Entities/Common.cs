using MongoDB.Bson.Serialization.Attributes;

namespace MyBlog.DB.Entities
{
    public class LocalizedString
    {
        [BsonElement("en")]
        public string En { get; set; } = string.Empty;

        [BsonElement("vi")]
        public string Vi { get; set; } = string.Empty;
    }
}

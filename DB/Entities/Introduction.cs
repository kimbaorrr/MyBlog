using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyBlog.DB.Entities
{
    public class Introduction
    {
        [BsonId]
        public ObjectId ObjectId { get; set; } = ObjectId.Empty;
        [BsonElement("welcome")]
        public LocalizedString Welcome { get; set; } = new LocalizedString();
        [BsonElement("passion")]
        public LocalizedString Passion { get; set; } = new LocalizedString();
        [BsonElement("goals")]
        public IList<LocalizedString> Goals { get; set; } = new List<LocalizedString>();

    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyBlog.DB.Entities
{

    public class Project
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("try_url")]
        public string TryUrl { get; set; } = string.Empty;

        [BsonElement("description")]
        public LocalizedString Description { get; set; } = new LocalizedString();

        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;
        [BsonElement("done")]
        public bool Done { get; set; } = false;

        [BsonElement("tech_stack")]
        public TechStack? TechStack { get; set; } = new TechStack();

        [BsonElement("evaluation_metrics")]
        public EvaluationMetrics? EvaluationMetrics { get; set; } = new EvaluationMetrics();

        [BsonElement("dataset")]
        public Dataset? Dataset { get; set; } = new Dataset();

        [BsonElement("model_path")]
        public string ModelPath { get; set; } = string.Empty;

        [BsonElement("contributions")]
        public LocalizedString Contributions { get; set; } = new LocalizedString();

        [BsonElement("takeaways")]
        public LocalizedString Takeaways { get; set; } = new LocalizedString();

        [BsonElement("tags")]
        public IList<string> Tags { get; set; } = new List<string>();

        [BsonElement("status")]
        public bool Status { get; set; } = false;

        [BsonElement("members")]
        public string Members { get; set; } = string.Empty;

        [BsonElement("role")]
        public LocalizedString Role { get; set; } = new LocalizedString();
        [BsonElement("start_time")]
        public string StartTime { get; set; } = string.Empty;
        [BsonElement("end_time")]
        public string EndTime { get; set; } = string.Empty;

        [BsonIgnore]
        public LocalizedString Scope => Convert.ToInt32(Members) > 1 ? new LocalizedString()
        {
            En = $"Teammate ({Members} members)",
            Vi = $"Nhóm ({Members} thành viên)"
        } : new LocalizedString()
        {
            En = "Individual",
            Vi = "Cá nhân"
        };


        [BsonElement("viewer")]
        public string Viewer { get; set; } = string.Empty;

        [BsonElement("source_code")]
        public SourceCode? SourceCode { get; set; } = new SourceCode();
    }

    public class EvaluationMetrics
    {
        [BsonElement("accuracy")]
        public string Accuracy { get; set; } = string.Empty;

        [BsonElement("f1_score")]
        public string F1Score { get; set; } = string.Empty;

        [BsonElement("precision")]
        public string Precision { get; set; } = string.Empty;

        [BsonElement("recall")]
        public string Recall { get; set; } = string.Empty;

        [BsonElement("confusion_matrix")]
        public string ConfusionMatrix { get; set; } = string.Empty;
    }

    public class Dataset
    {
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("url")]
        public string Url { get; set; } = string.Empty;

        [BsonElement("author")]
        public string Author { get; set; } = string.Empty;

        [BsonElement("freshness")]
        public string Freshness { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;
    }

    public class TechStack
    {
        [BsonElement("languages")]
        public IList<string> Languages { get; set; } = new List<string>();

        [BsonElement("front_end")]
        public IList<string> FrontEnd { get; set; } = new List<string>();

        [BsonElement("back_end")]
        public IList<string> BackEnd { get; set; } = new List<string>();

        [BsonElement("database")]
        public IList<string> Database { get; set; } = new List<string>();

        [BsonElement("infrastructure")]
        public IList<string> Infrastructure { get; set; } = new List<string>();

        [BsonElement("architecture")]
        public IList<string> Architecture { get; set; } = new List<string>();

        [BsonElement("libraries")]
        public IList<string> Libraries { get; set; } = new List<string>();

        [BsonElement("models")]
        public IList<string> Models { get; set; } = new List<string>();

        [BsonElement("frameworks")]
        public IList<string> Frameworks { get; set; } = new List<string>();

        [BsonElement("algorithm")]
        public IList<string> Algorithms { get; set; } = new List<string>();

        [BsonElement("task_type")]
        public IList<string> TaskType { get; set; } = new List<string>();
    }

    public class SourceCode
    {
        [BsonElement("github")]
        public string GitHub { get; set; } = string.Empty;

        [BsonElement("gitlab")]
        public string GitLab { get; set; } = string.Empty;
    }
}

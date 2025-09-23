using MongoDB.Driver;
using MyBlog.DB.Entities;

namespace MyBlog.DB
{
    public class MyBlogContext
    {
        private readonly IMongoDatabase _database;
        private readonly IConfiguration _configuration;

        public MyBlogContext(IConfiguration configuration)
        {
            _configuration = configuration;
            MongoClient client = new MongoClient(this._configuration["Database:MongoDB:Url"]);
            _database = client.GetDatabase(this._configuration["Database:MongoDB:DatabaseName"]);
        }

        public IMongoCollection<Project> Projects => this._database.GetCollection<Project>("projects");
        public IMongoCollection<Tool> Tools => this._database.GetCollection<Tool>("tools");
        public IMongoCollection<Personal> Personals => this._database.GetCollection<Personal>("personal");
        public IMongoCollection<Feedback> Feedbacks => this._database.GetCollection<Feedback>("feedbacks");
        public IMongoCollection<Introduction> Introductions => this._database.GetCollection<Introduction>("intro");
    }
}

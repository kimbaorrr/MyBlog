using MongoDB.Driver;
using MyBlog.DB.Entities;

namespace MyBlog.DB
{
    public class MyBlogContext
    {
        private readonly IMongoDatabase _database;

        public MyBlogContext(IConfiguration configuration)
        {
            MongoClient client = new MongoClient(configuration["Database:MongoDB:Url"]);
            _database = client.GetDatabase("my_blog");
        }

        public IMongoCollection<Project> Projects => this._database.GetCollection<Project>("projects");
        public IMongoCollection<Tool> Tools => this._database.GetCollection<Tool>("tools");
        public IMongoCollection<Personal> Personals => this._database.GetCollection<Personal>("personal");
        public IMongoCollection<Feedback> Feedbacks => this._database.GetCollection<Feedback>("feedbacks");
        public IMongoCollection<Introduction> Introductions => this._database.GetCollection<Introduction>("intro");
    }
}

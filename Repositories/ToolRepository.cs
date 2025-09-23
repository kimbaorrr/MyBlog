using MongoDB.Bson;
using MongoDB.Driver;
using MyBlog.DB;
using MyBlog.DB.Entities;
using MyBlog.Repositories.Interfaces;

namespace MyBlog.Repositories
{
    public class ToolRepository : CommonRepository, IToolRepository
    {
        public ToolRepository(MyBlogContext db) : base(db) { }
        public async Task<List<Tool>> GetTools()
        {
            return await this._db.Tools.Find(_ => true).ToListAsync();
        }
        public async Task<Tool> GetToolById(ObjectId objectId)
        {
            return await this._db.Tools.Find(x => x.Id == objectId).FirstOrDefaultAsync();
        }
    }
}

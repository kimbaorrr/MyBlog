using MongoDB.Driver;
using MyBlog.DB;
using MyBlog.DB.Entities;
using MyBlog.Repositories.Interfaces;

namespace MyBlog.Repositories
{
    public class ProjectRepository : CommonRepository, IProjectRepository
    {
        public ProjectRepository(MyBlogContext db) : base(db) { }
        public async Task<List<Project>> GetProjects()
        {
            return await this._db.Projects.Find(_ => true).ToListAsync();
        }
    }
}

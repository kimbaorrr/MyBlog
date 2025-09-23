using MyBlog.DB.Entities;

namespace MyBlog.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjects();
    }
}

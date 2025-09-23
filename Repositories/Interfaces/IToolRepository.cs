using MongoDB.Bson;
using MyBlog.DB.Entities;

namespace MyBlog.Repositories.Interfaces
{
    public interface IToolRepository
    {
        Task<List<Tool>> GetTools();
        Task<Tool> GetToolById(ObjectId objectId);
    }
}

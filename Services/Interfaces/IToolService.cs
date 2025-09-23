using MyBlog.DB.Entities;
using MyBlog.Models.ViewModels;

namespace MyBlog.Services.Interfaces
{
    public interface IToolService
    {
        Task<List<Tool>> GetToolsByLang(string lang);
    }
}

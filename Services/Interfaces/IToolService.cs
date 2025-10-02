using MyBlog.DB.Entities;
using MyBlog.Models.ViewModels;

namespace MyBlog.Services.Interfaces
{
    public interface IToolService
    {
        /// <summary>
        /// Lấy danh sách công cụ tiện ích
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        Task<List<Tool>> GetToolsByLang(string lang);
    }
}

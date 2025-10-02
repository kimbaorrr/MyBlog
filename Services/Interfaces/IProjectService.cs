using MyBlog.Models.ViewModels;

namespace MyBlog.Services.Interfaces
{
    public interface IProjectService
    {
        /// <summary>
        /// Lấy danh sách dự án
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        Task<List<ProjectPageViewModel>> GetProjectsByLang(string lang);
    }
}

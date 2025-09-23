using MyBlog.Models.ViewModels;

namespace MyBlog.Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectPageViewModel>> GetProjectsByLang(string lang);
    }
}

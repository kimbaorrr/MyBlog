using MyBlog.Models.ViewModels;

namespace MyBlog.Services.Interfaces
{
    public interface IHomeService
    {
        string GetClock();
        Task<HomeCardInfoViewModel> GetCardInfoByLang(string lang);
        Task<HomeIntroContentViewModel> GetHomeIntroContentByLang(string lang);
    }
}

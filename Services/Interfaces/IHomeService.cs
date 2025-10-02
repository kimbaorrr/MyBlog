using MyBlog.Models.ViewModels;

namespace MyBlog.Services.Interfaces
{
    public interface IHomeService
    {
        /// <summary>
        /// Lấy thông tin bản thân cho Mini Card
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        Task<HomeCardInfoViewModel> GetCardInfoByLang(string lang);
        /// <summary>
        /// Lấy thông tin giới thiệu
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        Task<HomeIntroContentViewModel> GetHomeIntroContentByLang(string lang);
    }
}

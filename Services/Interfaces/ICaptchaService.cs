using MyBlog.Models;

namespace MyBlog.Services.Interfaces
{
    public interface ICaptchaService
    {
        /// <summary>
        /// Xác thực dịch vụ HCaptcha (Cloudflare)
        /// </summary>
        /// <param name="token">Token nhận từ client</param>
        /// <returns></returns>
        Task<HCaptchaResponse> ValidateHCaptcha(string token);
    }
}

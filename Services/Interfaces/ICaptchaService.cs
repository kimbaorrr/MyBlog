using MyBlog.Models;

namespace MyBlog.Services.Interfaces
{
    public interface ICaptchaService
    {
        Task<HCaptchaResponse> ValidateHCaptcha(string token);
    }
}

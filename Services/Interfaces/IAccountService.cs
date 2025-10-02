using MyBlog.Areas.Admin.Models.ViewModels;
using System.Security.Claims;

namespace MyBlog.Services.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Đăng nhập người dùng
        /// </summary>
        /// <param name="accountLoginViewModel"></param>
        /// <returns>success:message:isTwoFA</returns>
        Task<(bool, string, bool)> Login(AccountLoginViewModel accountLoginViewModel);
        /// <summary>
        /// Đăng xuất người dùng hiện tại
        /// </summary>
        /// <returns></returns>
        Task Logout();
        /// <summary>
        /// Đăng kí tài khoản mới
        /// </summary>
        /// <param name="accountRegisterViewModel"></param>
        /// <returns>success:message</returns>
        Task<(bool, string)> Register(AccountRegisterViewModel accountRegisterViewModel);
        /// <summary>
        /// Xác thưc mã 2FA
        /// </summary>
        /// <param name="twoFactorAuthViewModel"></param>
        /// <returns></returns>
        Task<(bool, string)> VerifyTwoFactor(TwoFactorAuthViewModel twoFactorAuthViewModel);
        /// <summary>
        /// Lấy khóa 2FA để đăng kí trên app Authenticator
        /// </summary>
        /// <param name="claimUser">Người dùng đã đăng nhập</param>
        /// <returns>success:message</returns>
        Task<(bool, string, string)> GetTwoFactorKey(ClaimsPrincipal claimUser);
        /// <summary>
        /// Cấu hình bật/tắt 2FA
        /// </summary>
        /// <param name="claimUser">Người dùng đã đăng nhập</param>
        /// <param name="authCode">Khóa xác thực 2FA sinh từ app</param>
        /// <param name="isEnabled">Chế độ bật/tắt 2FA</param>
        /// <returns>success:message:totpLink</returns>
        Task<(bool, string)> ToggleTwoFactor(ClaimsPrincipal claimUser, string authCode, bool isEnabled);
    }
}

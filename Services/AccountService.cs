using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using MyBlog.Areas.Admin.Models.ViewModels;
using MyBlog.DB.Entities;
using MyBlog.Services.Interfaces;
using System.Security.Claims;

namespace MyBlog.Services
{
    public class AccountService : CommonService<AccountService>, IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICaptchaService _captchaService;
        public AccountService(ILogger<AccountService> logger, IStringLocalizer<SharedResource> localizer, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICaptchaService captchaService) : base(logger, localizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _captchaService = captchaService;
        }


        public async Task<(bool, string, bool)> Login(AccountLoginViewModel accountLoginViewModel)
        {
            var captchaResponse = await this._captchaService.ValidateHCaptcha(accountLoginViewModel.Token);
            if (!captchaResponse.Success)
            {
                return (false, "Xác thực Captcha không thành công !", false);
            }

            var result = await this._signInManager.PasswordSignInAsync(accountLoginViewModel.Username, accountLoginViewModel.Password, false, false);
            if (!result.Succeeded)
            {
                return (false, "Thông tin đăng nhập không đúng !", false);
            }

            if (result.RequiresTwoFactor)
            {
                return (true, string.Empty, true);
            }

            return (true, string.Empty, false);
        }

        public async Task Logout()
        {
            await this._signInManager.SignOutAsync();
        }

        public async Task<(bool, string)> Register(AccountRegisterViewModel accountRegisterViewModel)
        {
            ApplicationUser newUser = new()
            {
                UserName = accountRegisterViewModel.Username,
                Email = accountRegisterViewModel.Email,
                DisplayName = accountRegisterViewModel.LastName + " " + accountRegisterViewModel.FirstName,
                DisplayAvatar = accountRegisterViewModel.Avatar
            };
            var result = await this._userManager.CreateAsync(newUser, accountRegisterViewModel.Password);
            if (result.Succeeded)
            {
                return (true, "Tạo tài khoản thành công !");
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return (false, $"Tạo tài khoản thất bại với các lỗi:\n" + errors);
            }
        }

        public async Task<(bool, string)> VerifyTwoFactor(TwoFactorAuthViewModel twoFactorAuthViewModel)
        {
            var result = await this._signInManager.TwoFactorAuthenticatorSignInAsync(twoFactorAuthViewModel.AuthCode, false, false);
            if (!result.Succeeded)
            {
                return (false, "Mã xác thực không đúng !");
            }
            return (true, string.Empty);
        }

        public async Task<(bool, string, string)> GetTwoFactorKey(ClaimsPrincipal claimUser)
        {
            var user = await this._userManager.GetUserAsync(claimUser);

            var key = await this._userManager.GetAuthenticatorKeyAsync(user!);

            if (string.IsNullOrEmpty(key))
            {
                await this._userManager.ResetAuthenticatorKeyAsync(user!);
                key = await this._userManager.GetAuthenticatorKeyAsync(user!);
            }

            string issuer = "MyBlog";
            byte digists = 6;

            var totpUri = $"otpauth://totp/{issuer}:{user!.NormalizedUserName}?secret={key}&issuer={issuer}&digits={digists}";

            return (true, string.Empty, totpUri);

        }

        public async Task<(bool, string)> ToggleTwoFactor(ClaimsPrincipal claimUser, string authCode, bool isEnabled)
        {
            var user = await this._userManager.GetUserAsync(claimUser);

            bool isValid = await this._userManager.VerifyTwoFactorTokenAsync(user!, TokenOptions.DefaultAuthenticatorProvider, authCode);

            if (!isValid)
            {
                return (false, "Mã xác thực TOTP không hợp lệ !");
            }

            await this._userManager.SetTwoFactorEnabledAsync(user!, isEnabled);

            return (true, isEnabled ? "Đã mở khóa xác minh 2 bước !" : "Đã tắt xác minh 2 bước !");
        }
    }
}

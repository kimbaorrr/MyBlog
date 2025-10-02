using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MyBlog.Areas.Admin.Models.ViewModels;
using MyBlog.Controllers;
using MyBlog.DB.Entities;
using MyBlog.Services.Interfaces;

namespace MyBlog.Areas.Admin.Controllers
{
    [Route("admin/auth")]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IDistributedCache _distributedCache;

        public AccountController(IAccountService accountService, IDistributedCache distributedCache)
        {
            _accountService = accountService;
            _distributedCache = distributedCache;
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AccountLoginViewModel accountLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                (bool success, string messsage, bool isTwoFA) =
                    await this._accountService.Login(accountLoginViewModel);

                if (success && isTwoFA)
                {
                    var tempKey = Guid.CreateVersion7().ToString();

                    await this._distributedCache.SetStringAsync(
                        tempKey,
                        accountLoginViewModel.Username,
                        new DistributedCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                        });

                    var data = new
                    {
                        redirectUrl = Url.Action("VerifyTwoFA", "Account", new { area = "Admin", tempKey = tempKey })
                    };

                    return CreateJsonResult(success, messsage, data);
                }

                var homeData = new
                {
                    redirectUrl = Url.Action("Index", "Home", new { area = "Admin" })
                };

                return CreateJsonResult(success, messsage, homeData);
            }

            var errors = string.Join("\n", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));

            return CreateJsonResult(false,
                "Các trường nhập liệu không chính xác.\nThông tin các lỗi gồm:\n" + errors);
        }


        [HttpGet("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this._accountService.Logout();
            return RedirectToAction("Login", "Account", new { area = "Admin" });
        }

        [HttpPost("register")]
        [AutoValidateAntiforgeryToken]
        [Authorize]
        public async Task<IActionResult> Register(AccountRegisterViewModel accountRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                (bool success, string messsage) = await this._accountService.Register(accountRegisterViewModel);
                return CreateJsonResult(success, messsage);
            }
            var errors = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            return CreateJsonResult(false, "Dữ liệu các trường không hợp lệ:\n" + errors);
        }

        [HttpGet("verify_2fa")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyTwoFA([FromQuery] string tempKey)
        {
            string userName = await this._distributedCache.GetStringAsync(tempKey) ?? string.Empty;
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }
            return View();
        }

        [HttpPost("verify_2fa")]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyTwoFA(TwoFactorAuthViewModel twoFactorAuthViewModel)
        {
            if (ModelState.IsValid)
            {
                (bool success, string messsage) = await this._accountService.VerifyTwoFactor(twoFactorAuthViewModel);
                var data = new
                {
                    redirectUrl = Url.Action("Index", "Home", new { area = "Admin" })
                };
                return CreateJsonResult(success, messsage, data);
            }

            var errors = string.Join("\n", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));

            return CreateJsonResult(false, "Dữ liệu các trường không hợp lệ:\n" + errors);
        }

        [HttpPost("toggle_2fa")]
        [AutoValidateAntiforgeryToken]
        [Authorize]
        public async Task<IActionResult> ToggleTwoFA([FromForm] string authCode, [FromForm] bool isEnabled)
        {
            (bool success, string message) = await this._accountService.ToggleTwoFactor(User, authCode, isEnabled);
            return CreateJsonResult(success, message);
        }


    }
}

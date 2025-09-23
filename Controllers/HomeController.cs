using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.ViewModels;
using MyBlog.Services.Interfaces;

namespace MyBlog.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _homeService = homeService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HomeCardInfoViewModel homeCardInfoViewModel = await this._homeService.GetCardInfoByLang(GetLang());
            HomeIntroContentViewModel homeIntroContentViewModel = await this._homeService.GetHomeIntroContentByLang(GetLang());
            HomePageViewModel homePageViewModel = new()
            {
                HomeCardInfoViewModel = homeCardInfoViewModel,
                HomeIntroContentViewModel = homeIntroContentViewModel,
            };
            return View(homePageViewModel);
        }
    }
}

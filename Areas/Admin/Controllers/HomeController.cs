using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TwoFA()
        {
            return View();
        }
    }
}

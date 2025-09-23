using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    [Route("cv")]
    public class CVController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult Index()
        {
            return View();
        }
    }
}

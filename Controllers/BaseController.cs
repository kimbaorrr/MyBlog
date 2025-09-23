using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MyBlog.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Lấy lang từ Header
        /// </summary>
        /// <returns></returns>
        protected string GetLang()
        {
            return CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToLower();
        }
        /// <summary>
        /// Khởi tạo JSON trả về
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected JsonResult CreateJsonResult(bool success = true, string message = "", object? data = null)
        {
            var result = new 
            {
                success = success!,
                message = message!,
                data = data!
            };

            return Json(result);
        }
    }

    
}

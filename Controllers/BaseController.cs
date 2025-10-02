using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace MyBlog.Controllers
{
    public abstract class BaseAppController : Controller
    {
        /// <summary>
        /// Lấy lang từ Header
        /// </summary>
        /// <returns></returns>
        protected static string GetLang()
        {
            return CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToLower();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected JsonResult CreateJsonResult(bool success = true, string message = "", object? data = null)
        {
            var result = new
            {
                success = success!,
                message = message!,
                data = data ?? new {}
            };

            return Json(result);
        }
    }

    public abstract class BaseController : BaseAppController
    {
        
    }
}

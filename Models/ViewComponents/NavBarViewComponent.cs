using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MyBlog.Models.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string viewName, object? model)
        {
            var currentController = ViewContext.RouteData.Values["controller"]?.ToString() ?? "";
            var currentAction = ViewContext.RouteData.Values["action"]?.ToString() ?? "";
            var currentLang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            ViewBag.CurrentController = currentController;
            ViewBag.CurrentAction = currentAction;
            ViewBag.CurrentLang = currentLang;

            return View(viewName, model);
        }
    }
}

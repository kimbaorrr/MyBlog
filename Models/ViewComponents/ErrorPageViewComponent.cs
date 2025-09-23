using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Models.ViewComponents
{
    public class ErrorPageViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

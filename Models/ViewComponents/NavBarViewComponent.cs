using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Models.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

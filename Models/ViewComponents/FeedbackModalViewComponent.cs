using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.ViewModels;

namespace MyBlog.Models.ViewComponents
{
    public class FeedbackModalViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(FeedbackViewModel model)
        {
            return View(model); // truyền model riêng của modal
        }
    }
}

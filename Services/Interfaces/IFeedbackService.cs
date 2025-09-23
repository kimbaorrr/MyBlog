using MyBlog.Models.ViewModels;

namespace MyBlog.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<(bool, string)> NewFeedbackViewModel(FeedbackViewModel newFeedbackViewModel);
    }
}

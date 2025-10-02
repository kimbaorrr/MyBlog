using MyBlog.Models.ViewModels;

namespace MyBlog.Services.Interfaces
{
    public interface IFeedbackService
    {
        /// <summary>
        /// Ghi nhận Feedback từ người dùng
        /// </summary>
        /// <param name="newFeedbackViewModel"></param>
        /// <returns>success:message</returns>
        Task<(bool, string)> NewFeedbackViewModel(FeedbackViewModel newFeedbackViewModel);
    }
}

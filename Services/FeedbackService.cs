using Microsoft.Extensions.Localization;
using MyBlog.DB.Entities;
using MyBlog.Models;
using MyBlog.Models.ViewModels;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;

namespace MyBlog.Services
{
    public class FeedbackService : CommonService<FeedbackService>, IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly ICaptchaService _captchaService;
        public FeedbackService(IStringLocalizer<SharedResource> localizer, ILogger<FeedbackService> logger, IFeedbackRepository feedbackRepository, ICaptchaService captchaService) : base(logger, localizer)
        {
            _feedbackRepository = feedbackRepository;
            _captchaService = captchaService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newFeedbackViewModel"></param>
        /// <returns>(Trạng thái, nội dung lỗi nếu có)</returns>
        public async Task<(bool, string)> NewFeedbackViewModel(FeedbackViewModel newFeedbackViewModel)
        {
            HCaptchaResponse response = await this._captchaService.ValidateHCaptcha(newFeedbackViewModel.Token);
            if (response != null && response.Success) 
            {
                Feedback feedback = new Feedback()
                {
                    Name = newFeedbackViewModel.Name,
                    Content = newFeedbackViewModel.Content,
                    Email = newFeedbackViewModel.Email,
                    CreatedAt = DateTime.UtcNow
                };
                this._feedbackRepository.AddFeedback(feedback);
                return (true, string.Empty);
            }
            return (false, string.Join(",", response!.ErrorCodes));
            
            
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.ViewModels;
using MyBlog.Services.Interfaces;

namespace MyBlog.Controllers
{
    [Route("feedback")]
    public class FeedbackController : BaseController
    {
        private readonly IFeedbackService _feedbackService;
        private readonly ILogger _logger;
        public FeedbackController(IFeedbackService feedbackService, ILogger<FeedbackController> logger)
        {
            _feedbackService = feedbackService;
            _logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("send")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Send(FeedbackViewModel newFeedbackViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                string errorMessages = string.Join("; ", errors);

                return BadRequest(CreateJsonResult(false, errorMessages));
            }

            (bool success, string message) = await _feedbackService.NewFeedbackViewModel(newFeedbackViewModel);

            if (!success)
            {
                _logger.LogError("SendFeedback: Lỗi khi tạo Feedback trong DB {Message}", message);
                return BadRequest(CreateJsonResult(success, message));
            }

            return Ok(CreateJsonResult(success, "Đã ghi nhận ý kiến đóng góp của bạn\nCảm ơn bạn rất nhiều !"));
        }

    }
}

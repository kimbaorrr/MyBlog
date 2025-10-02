using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models.ViewModels
{
    public class FeedbackViewModel
    {
        [DataType(DataType.Text)]
        [MaxLength(75)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        [MaxLength(100)]
        [Required]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.MultilineText)]
        [MaxLength(255)]
        [Required]
        public string Content { get; set; } = string.Empty;
        [DataType(DataType.Text)]
        [Required]
        public string Token { get; set; } = string.Empty;
    }
}

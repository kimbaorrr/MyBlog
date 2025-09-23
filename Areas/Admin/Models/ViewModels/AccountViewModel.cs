using System.ComponentModel.DataAnnotations;

namespace MyBlog.Areas.Admin.Models.ViewModels
{
    public class LoginViewModel
    {
        [DataType(DataType.Text)]
        public string Username { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
    public class TwoFactorAuthViewModel
    {
        public string AuthCode { get; set; } = string.Empty;
    }
}

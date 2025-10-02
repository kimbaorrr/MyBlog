using System.ComponentModel.DataAnnotations;

namespace MyBlog.Areas.Admin.Models.ViewModels
{
    public abstract class BaseAccountViewModel
    {
        [DataType(DataType.Text)]
        [Required()]
        public string Username { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Token { get; set; } = string.Empty;
    }
    public class AccountLoginViewModel : BaseAccountViewModel
    {
        
    }
    public class AccountRegisterViewModel : BaseAccountViewModel
    {
        [DataType(DataType.Text)]
        [Required]
        public string LastName { get; set; } = string.Empty;
        [DataType(DataType.Text)]
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; } = string.Empty;
    }

    public class TwoFactorAuthViewModel
    {
        public string AuthCode { get; set; } = string.Empty;
    }
}

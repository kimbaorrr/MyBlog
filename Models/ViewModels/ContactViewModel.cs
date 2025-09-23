using MyBlog.DB.Entities;

namespace MyBlog.Models.ViewModels
{
    public class ContactPageViewModel
    {
        public string AvatarUrl { get; set; } = "#";
        public string Title { get; set; } = string.Empty;
        public List<string> Content { get; set; } = new List<string>();
        public Socials Socials { get; set; } = new Socials { };

    }
}

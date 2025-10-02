using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Identity;

namespace MyBlog.DB.Entities
{
    public class ApplicationUser : MongoUser
    {
        public string DisplayName { get; set; } = string.Empty;
        public string DisplayAvatar { get; set; } = string.Empty;
    }
}

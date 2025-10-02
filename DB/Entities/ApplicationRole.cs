using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Identity;

namespace MyBlog.DB.Entities
{
    public class ApplicationRole: MongoRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }
}

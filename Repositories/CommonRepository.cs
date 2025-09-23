using MyBlog.DB;

namespace MyBlog.Repositories
{
    public abstract class CommonRepository
    {
        protected readonly MyBlogContext _db;
        public CommonRepository(MyBlogContext db)
        {
            _db = db;
        }
    }
}

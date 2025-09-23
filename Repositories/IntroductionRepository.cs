using Microsoft.CodeAnalysis.CSharp.Syntax;
using MongoDB.Driver;
using MyBlog.DB;
using MyBlog.DB.Entities;
using MyBlog.Repositories.Interfaces;

namespace MyBlog.Repositories
{
    public class IntroductionRepository : CommonRepository, IIntroductionRepository
    {
        public IntroductionRepository(MyBlogContext db) : base(db) { }
        public async Task<List<Introduction>> GetIntroductions()
        {
            return await this._db.Introductions.Find(_ => true).ToListAsync();
        }
    }
}

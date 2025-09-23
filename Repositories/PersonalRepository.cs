using Microsoft.CodeAnalysis.Elfie.Model.Strings;
using MongoDB.Driver;
using MyBlog.DB;
using MyBlog.DB.Entities;
using MyBlog.Models.ViewModels;
using MyBlog.Repositories.Interfaces;

namespace MyBlog.Repositories
{
    public class PersonalRepository : CommonRepository, IPersonalRepository
    {
        public PersonalRepository(MyBlogContext db) : base(db) { }
        public async Task<List<Personal>> GetPersonals()
        {
            return await this._db.Personals.Find(_ => true).ToListAsync();
        }
        public async Task<string> GetAvatar()
        {
            var personal = await this._db.Personals.Find(_ => true).FirstOrDefaultAsync();
            return personal.Avatar;
            
        }
        public async Task<Socials> GetSocials()
        {
            var personal = await _db.Personals.Find(_ => true).FirstOrDefaultAsync();
            return personal.Socials;
        }

    }
}

using MyBlog.DB.Entities;

namespace MyBlog.Repositories.Interfaces
{
    public interface IPersonalRepository
    {
        Task<List<Personal>> GetPersonals();
        Task<string> GetAvatar();
        Task<Socials> GetSocials();
    }
}

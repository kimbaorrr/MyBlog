using MyBlog.DB.Entities;

namespace MyBlog.Repositories.Interfaces
{
    public interface IIntroductionRepository
    {
        Task<List<Introduction>> GetIntroductions();
    }
}

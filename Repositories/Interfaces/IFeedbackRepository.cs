using MyBlog.DB.Entities;

namespace MyBlog.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<List<Feedback>> GetFeedbacks();
        void AddFeedback(Feedback fb);
    }
}

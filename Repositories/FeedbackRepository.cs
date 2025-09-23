using MongoDB.Driver;
using MyBlog.DB;
using MyBlog.DB.Entities;
using MyBlog.Repositories.Interfaces;

namespace MyBlog.Repositories
{
    public class FeedbackRepository : CommonRepository, IFeedbackRepository
    {
        public FeedbackRepository(MyBlogContext db) : base(db) { }
        public async Task<List<Feedback>> GetFeedbacks()
        {
            return await this._db.Feedbacks.Find(_ => true).ToListAsync();
        }

        public async void AddFeedback(Feedback fb)
        {
            await this._db.Feedbacks.InsertOneAsync(fb);
        }


    }
}

using E_Learning_Management_System.Data;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;
using E_Learning_Management_System.Repository;

namespace E_LearningManagementSystem.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicatioDbContext _context;

        public FeedbackRepository(ApplicatioDbContext context)
        {
            this._context = context;
        }
        public async Task<int> DeleteById(int id)
        {
            var tt= await _context.Feedbacks.FindAsync(id);
            var ttt = new FeedbackDTO()
            {
                FeedbackId=tt.FeedbackId,
                QuizID=tt.QuizID,
            };
            _context.Feedbacks.Remove(tt);
            var raw= await  _context.SaveChangesAsync();

            return raw;
        }

        public async  Task<IEnumerable<FeedbackDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public  Task<FeedbackDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<FeedbackDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Insert(FeedbackDTO cart)
        {
            throw new NotImplementedException();
        }

        public async  Task<int> Update(int id, FeedbackDTO cart)
        {
            throw new NotImplementedException();
        }
    }
}

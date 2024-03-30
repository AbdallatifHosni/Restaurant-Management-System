using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;

namespace E_Learning_Management_System.Repository
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<FeedbackDTO>> GetAll();
        Task<FeedbackDTO> GetById(int id);
        Task<FeedbackDTO> GetByName(string name);
        Task<int> Insert(FeedbackDTO dto);
        Task<int> Update(int id, FeedbackDTO dto);
        Task<int> DeleteById(int id);
    }
}

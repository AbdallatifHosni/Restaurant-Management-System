using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;

namespace E_Learning_Management_System.Repository
{
    public interface ILearnerRepository
    {
        Task<IEnumerable<LearnerDTO>> GetAll();
        Task<LearnerDTO> GetById(int id);
        Task<LearnerDTO> GetByName(string name);
        Task<int> Insert(LearnerDTO model);
        Task<int> Update(int id, LearnerDTO model);
        Task<int> DeleteById(int id);
    }
}

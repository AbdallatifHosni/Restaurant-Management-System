using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;

namespace E_Learning_Management_System.Repository
{
    public interface IDurationRepository
    {
        Task<IEnumerable<DurationDTO>> GetAll();
        Task<DurationDTO> GetById(int id);
        Task<DurationDTO> GetByName(string name);
        Task<int> Insert(DurationDTO cart);
        Task<int> Update(int id, DurationDTO cart);
        Task<int> DeleteById(int id);
    }
}

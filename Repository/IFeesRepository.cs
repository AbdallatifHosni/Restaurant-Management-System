using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;

namespace E_Learning_Management_System.Repository
{
    public interface IFeesRepository
    {
        Task<IEnumerable<FeesDTO>> GetAll();
        Task<FeesDTO> GetById(int id);
        Task<FeesDTO> GetByName(string name);
        Task<int> Insert(FeesDTO cart);
        Task<int> Update(int id, FeesDTO cart);
        Task<int> DeleteById(int id);
    }
}

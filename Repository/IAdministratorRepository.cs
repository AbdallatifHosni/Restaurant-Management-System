using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;
using System.Collections;

namespace E_Learning_Management_System.Repository
{
    public interface IAdministratorRepository
    {
        Task<IEnumerable<AdministratorDTO>>GetAll();
        Task<AdministratorDTO> GetById(int id);
        Task<AdministratorDTO> GetByName(string name);
        Task<int> Insert(AdministratorDTO cart);
        Task<int> Update(int id, AdministratorDTO cart);
        Task<int> DeleteById(int id);

    }
}

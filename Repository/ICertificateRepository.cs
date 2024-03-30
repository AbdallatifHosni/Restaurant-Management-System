using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;

namespace E_Learning_Management_System.Repository
{
    public interface ICertificateRepository
    {
        Task<IEnumerable<CertificateDTO>> GetAll();
        Task<CertificateDTO> GetById(int id);
        Task GetByName(string name);
        Task Insert(CertificateDTO cart);
        Task Update(int id, CertificateDTO cart);
        Task<int> DeleteById(int id);

    }
}

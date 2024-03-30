using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;

namespace E_Learning_Management_System.Repository
{
    public interface IContentRepository
    {
        Task<IEnumerable<ContentDTO>> GetAll();
        Task<ContentDTO> GetById(int id);
        Task<int> GetByName(string name);
        Task<int> Insert(ContentDTO cart);
        Task<int> Update(int id, ContentDTO cart);
        Task<int> DeleteById(int id);
    }
}

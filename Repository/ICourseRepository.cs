using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;

namespace E_Learning_Management_System.Repository
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseDTO>> GetAll();
        Task<CourseDTO> GetById(int id);
        Task<CourseDTO> GetByName(string name);
        Task<int> Insert(CourseDTO cart);
        Task<int> Update(int id, CourseDTO cart);
        Task<int> DeleteById(int id);
    }
}
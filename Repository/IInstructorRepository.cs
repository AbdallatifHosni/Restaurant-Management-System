using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;
using E_LearningManagementSystem.DTO;

namespace E_Learning_Management_System.Repository
{
    public interface IInstructorRepository
    {
        Task<IEnumerable<InstructorDTO>> GetAll();
        Task<InstructorDTO> GetById(int id);
        Task<InstructorDTO> GetByName(string name);
        Task<InstructorCourseNameDTO> getInstructorCourseName(int InstructorId);
        Task<int> Insert(InstructorDTO model);
        Task<int> Update(int id, InstructorDTO model);
        Task<int> DeleteById(int id);
    }
}

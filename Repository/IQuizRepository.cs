using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;

namespace E_Learning_Management_System.Repository
{
    public interface IQuizRepository
    {
        Task<IEnumerable<QuizDTO>> GetAll();
        Task<QuizDTO> GetById(int id);
        Task<QuizDTO> GetByName(int name);
        Task<int> Insert(QuizDTO model);
        Task<int> Update(int id, QuizDTO model);
        Task<int> DeleteById(int id);
    }
}

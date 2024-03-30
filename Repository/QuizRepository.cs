using E_Learning_Management_System.Data;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;
using E_Learning_Management_System.Repository;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace E_LearningManagementSystem.Repository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicatioDbContext _context;

        public QuizRepository(ApplicatioDbContext context )
        {
            this._context = context;
        }
        public async Task<int> DeleteById(int id)
        {
            
           var item= await _context.Quizzes.FindAsync(id);
            var tt =_context.Quizzes.Remove(item);
            int raw=await _context.SaveChangesAsync();
            return raw;

        }

        public async Task<IEnumerable<QuizDTO>> GetAll()
        {
           var itemss=await  _context.Quizzes.ToListAsync();
            List<QuizDTO> fara = new List<QuizDTO>();
            foreach ( var item in itemss )
            {
                var QuizDTO=new QuizDTO()
                {
                    Mark=item.Mark,

                    Id = item.Id,
                };
                fara.Add(QuizDTO);

            };

            return fara ;


        }

        public async Task<QuizDTO> GetById(int id)
        {
            var hello = await _context.Quizzes.FirstOrDefaultAsync(e=>e.Id==id);
            var item = new QuizDTO()
            {
                Id = hello.Id,
                Mark = hello.Mark,
            };

            return item;

        }

        public async  Task<QuizDTO> GetByName(int  id)
        {
            var hello = await _context.Quizzes.FirstOrDefaultAsync(e => e.Id == id);
            var item = new QuizDTO()
            {
                Id = hello.Id,
                Mark = hello.Mark,
            };

            return item;

        }

        public async Task<int> Insert(QuizDTO cart)
        {
            var item = new Quiz()
            {
                Id = cart.Id,
                Mark = cart.Mark,

            };

            var oo= await _context.AddAsync(item);
            int raw= await  _context.SaveChangesAsync();

            return raw;

        }

        public async Task<int> Update(int id, QuizDTO dto)
        {
            var fara = await _context.Quizzes.FirstOrDefaultAsync(q=>q.Id==id);
            fara.Mark= dto.Mark;
            fara.Id= dto.Id;
            _context.Entry(fara).State=EntityState.Modified;
           int raw = await _context.SaveChangesAsync();
            return raw;
            
            

        }
    }
}

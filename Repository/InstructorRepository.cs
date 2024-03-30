using E_Learning_Management_System.Data;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;
using E_Learning_Management_System.Repository;
using E_LearningManagementSystem.DTO;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace E_LearningManagementSystem.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly ApplicatioDbContext _context;

        public InstructorRepository(ApplicatioDbContext context)
        {
            this._context = context;
        }
        public async Task<int> DeleteById(int id)
        {
            var uu = await  _context.Instructors.FirstOrDefaultAsync(e=>e.InstructorID== id);

            _context.Entry(uu).State = EntityState.Deleted;

            int raw =  await _context.SaveChangesAsync();

            return raw ;
        }
        public async Task<IEnumerable<InstructorDTO>> GetAll()
        {
            var rr=_context.Instructors.ToList();
            List<InstructorDTO> instDTOs = new List<InstructorDTO>();
            foreach (var item in rr)
            {
                var uu=new InstructorDTO()
                {
                    //AccountId = item.AccountId,
                    //Courses=item.Courses
                    Email = item.Email,
                    Name = item.Name,

                    InstructorID = item.InstructorID,
                };

                instDTOs.Add(uu);
            }

            return instDTOs;

        }

        public async Task<InstructorDTO> GetById(int id)
        {
            var InstructorDTO =  await _context.Instructors.FirstOrDefaultAsync(e=>e.InstructorID==id);
            var item = new InstructorDTO()
            {
                InstructorID= id,
               // AccountId= InstructorDTO.AccountId,
             
                Email= InstructorDTO.Email,
                Name = InstructorDTO.Name,

            };

            return item;

        }

        public  async Task<InstructorDTO> GetByName(string name)
        {
            var InstructorDTO = await _context.Instructors.FirstOrDefaultAsync(w=>w.Name==name);
            var item = new InstructorDTO()
            {
                InstructorID = InstructorDTO.InstructorID,
               // AccountId = InstructorDTO.AccountId,
                Email = InstructorDTO.Email,
                Name = InstructorDTO.Name,

            };
            return item;
        }

        public async Task<int> Insert(InstructorDTO model)
        {
            var titi = new Instructor()
            {
               InstructorID= model.InstructorID ,
               //AccountId=model.AccountId,
               Email= model.Email,
               Name = model.Name,
            };

            await _context.AddAsync(titi);
            int raw = await _context.SaveChangesAsync();
            return raw;
        }

        public async Task<int> Update(int id, InstructorDTO model)
        {
            var uu=_context.Instructors.FirstOrDefault(e=>e.InstructorID==id);
            var titi = new Instructor()
            {
                InstructorID = model.InstructorID,
                //AccountId = model.AccountId,
                Email = model.Email,
                Name = model.Name,

            };

            _context.Entry(titi).State= EntityState.Modified;
          int raw = await _context.SaveChangesAsync();

            return raw;

        }
        public async Task<InstructorCourseNameDTO> getInstructorCourseName(int InstructorId)
        {
            var item = await _context.Instructors
                .Include(e => e.Courses)
                .FirstOrDefaultAsync(e=>e.InstructorID== InstructorId);//.ToListAsync();
            var mo = new InstructorCourseNameDTO()
            {
                CourseName = item.Name,
                InstructorName=item.Courses.FirstOrDefault().Name



             };

            return mo;


        }
    }
}

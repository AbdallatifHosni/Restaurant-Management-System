using E_Learning_Management_System.Data;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;
using E_Learning_Management_System.Repository;
using Microsoft.EntityFrameworkCore;

namespace E_LearningManagementSystem.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicatioDbContext _context;

        public CourseRepository(ApplicatioDbContext context) 
        {
            this._context = context;
        }
        public async Task<int> DeleteById(int id)
        {
            var item = await _context.Courses.FirstOrDefaultAsync(e=>e.CourseId==id);
            var tt=await _context.SaveChangesAsync();
            return tt;
        }

        public async Task<IEnumerable<CourseDTO>> GetAll()
        {
            var items=await _context.Courses.ToListAsync();
            List<CourseDTO> modelss = new List<CourseDTO>();

            foreach (var item in items)
            {
                CourseDTO coc= new CourseDTO()
                {

                    CourseId = item.CourseId,
                    Description = item.Description,
                    Name = item.Name,

                };
                modelss.Add(coc);
                

            }

            return modelss;
        }

        public async Task<CourseDTO> GetById(int id)
        {
            var iteml = await _context.Courses.FirstOrDefaultAsync(e=>e.CourseId== id);
            var ddd = new CourseDTO()
            {
                CourseId = iteml.CourseId,
                Description = iteml.Description,
                Name = iteml.Name,

            };

            return ddd;

        }

        public async Task<CourseDTO> GetByName(string name)
        {
            var items = await _context.Courses.FirstOrDefaultAsync(asd=>asd.Name== name);
            var ddd = new CourseDTO()
            {
                CourseId = items.CourseId,
                Description = items.Description,
                Name = items.Name,

            };

            return ddd;

        }

        public async Task<int> Insert(CourseDTO model)
        {
            var item =new Course()
            {
                Description = model.Description,


                CourseId = model.CourseId,
                Name = model.Name,
            };
            _context.Courses.Add(item);
            int i= await _context.SaveChangesAsync();
            return i;


        }

        public async Task<int> Update(int id, CourseDTO cart)
        {
            var yy=await _context.Courses.FirstOrDefaultAsync(e=>e.CourseId == id);

            var ddd = new CourseDTO()
            {
                CourseId = yy.CourseId,
                Description = yy.Description,
                Name = yy.Name,

            };
            _context.Entry(ddd).State = EntityState.Modified;
             int raw = _context.SaveChanges();

            return raw;

        }
    }
}

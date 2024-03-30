using E_Learning_Management_System.Data;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;
using E_Learning_Management_System.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace E_LearningManagementSystem.Repository
{
    public class LearnerRepository : ILearnerRepository
    {
        private readonly ApplicatioDbContext _context;

        public LearnerRepository(ApplicatioDbContext context ) 
        {
            this._context = context;
        }
        public async Task<int> DeleteById(int id)
        {
            var item= await _context.Learners.FirstOrDefaultAsync(l => l.Id == id);
            _context.Entry(item).State = EntityState.Modified;

             int raw =await _context.SaveChangesAsync();
            return raw;

        }

        public async Task<IEnumerable<LearnerDTO>> GetAll()
        {
          var models= await _context.Learners.ToListAsync();
            var items=new List<LearnerDTO>();
            foreach (var model in models)
            {
                var we=new LearnerDTO()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Address=model.Address,

                };
                items.Add(we);
            }

            return items;

            
        }

        public Task<LearnerDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LearnerDTO> GetByName(string name)
        {

            var leaner = await _context.Learners.FirstOrDefaultAsync(e=>e.Name==name);
            var item = new LearnerDTO() { 
             Name = leaner.Name,
             Address = leaner.Address,
             Id=leaner.Id,
           // courses=leaner.courses.
            };
            return item;
        }

        public async Task<int> Insert(LearnerDTO dto)
        {
            var iit = new Learner()
            { 
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,

            
            };
           await   _context.Learners.AddAsync(iit);
            int raw=await  _context.SaveChangesAsync();
            return raw;


            
        }

        public async Task<int> Update(int id, LearnerDTO dto)
        {
            var olditem=await  _context.Learners.FirstOrDefaultAsync(e=>e.Id==id);
            dto.Name = olditem.Name;
            dto.Address = olditem.Address;
            dto.Id = olditem.Id;
           int raw= await _context.SaveChangesAsync();
            return raw;
        }
    }
}

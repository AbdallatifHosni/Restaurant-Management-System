using E_Learning_Management_System.Data;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;
using E_Learning_Management_System.Repository;
using Microsoft.EntityFrameworkCore;

namespace E_LearningManagementSystem.Repository
{
    public class FeesRepository : IFeesRepository
    {
        private readonly ApplicatioDbContext _context;

        public FeesRepository(ApplicatioDbContext context)
        {
            this._context = context;
        }
        public  async Task<int> DeleteById(int id)
        {
            var item= await _context.Fees.FirstOrDefaultAsync(fe => fe.Id == id);

            _context.Fees.Remove(item);

           var raw = await  _context.SaveChangesAsync();

            return raw;
            
        }

        public  async Task<IEnumerable<FeesDTO>> GetAll()
        {
            var items = await _context.Fees.ToListAsync();

            var models = new List<FeesDTO>();

            foreach (var item in items)
            {
                var gg=new FeesDTO()
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    Description = item.Description,
                    Payment = item.Payment,
                    Total = item.Total,
                };
                models.Add(gg);

            }

            return models;
           
        }

        public async  Task<FeesDTO> GetById(int id)
        {
            var item =  await _context.Fees.FirstOrDefaultAsync(e=>e.Id==id);
            var nn = new FeesDTO()
            {
                Amount = item.Amount,
                Description = item.Description,
                Payment = item.Payment,
                Total = item.Total,
                Id = item.Id,
            };

            return nn ; 


        }

        public  async Task<FeesDTO> GetByName(string name)
        {
            var item = await _context.Fees.FirstOrDefaultAsync(e => e.Amount == name);
            var nn = new FeesDTO()
            {
                Amount = item.Amount,
                Description = item.Description,
                Payment = item.Payment,
                Total = item.Total,
                Id = item.Id,
            };

            return nn;

        }

        public async Task<int> Insert(FeesDTO model)
        {
            var varr = new Fees()
            {
                Amount = model.Amount,
                Description = model.Description,
                Payment = model.Payment,
                Total = model.Total,
                Id = model.Id,
            };

            _context.Entry(varr).State = EntityState.Added;
            int raw=await  _context.SaveChangesAsync();
            return raw;
        }

        public  async Task<int> Update(int id, FeesDTO dto)
        {
            var olditem =_context.Fees.FirstOrDefault(e => e.Id == id);
            var nn = new Fees()
            {
            Amount = dto.Amount,
            Description = dto.Description,
            Payment = dto.Payment,
            Total = dto.Total,
            Id = dto.Id,
        };


            _context.Entry(nn).State = EntityState.Modified;
            var raw= await _context.SaveChangesAsync();
            return raw;

        }
    }
}

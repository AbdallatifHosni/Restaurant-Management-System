using E_Learning_Management_System.Data;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;
using E_Learning_Management_System.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_LearningManagementSystem.Repository
{
    public class DurationRepository : IDurationRepository
    {
        private readonly ApplicatioDbContext _context;

        public DurationRepository(ApplicatioDbContext context)
        {
            this._context = context;
        }
        public async Task<int> DeleteById(int id)
        {
          var item =await   _context.Durations.FirstOrDefaultAsync(d => d.Id == id);
            _context.Durations.Remove(item);
           int u=await _context.SaveChangesAsync();
            return u;
        }

        public async Task<IEnumerable<DurationDTO>> GetAll()
        {
           var items= await _context.Durations.ToListAsync();
             var models= new List<DurationDTO>();
            foreach (var item in items)
            {
                DurationDTO dto = new DurationDTO()
                {
                   DurationType = item.DurationType,
                   Id = item.Id,
                   Description = item.Description,
                   DurationDate = item.DurationDate,
                   CourseId = item.CourseId,

                   

                };

                models.Add(dto);
            }

            return models;

        }

        public async Task<DurationDTO> GetById(int id)
        {
            var item = await _context.Durations.FindAsync(id);
            var dto = new DurationDTO()
            { CourseId=item.CourseId,
            Description=item.Description,
            DurationDate=item.DurationDate,
            DurationType = item.DurationType,
            Id=item.Id,

            };
            return dto;
        }

        public Task<DurationDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Insert(DurationDTO model)
        {
            var item = new Duration() 
            { 
                Description= model.Description,
                CourseId = model.CourseId,
                Id=model.Id,
                DurationDate=model.DurationDate,
                DurationType = model.DurationType,

            };
            await _context.Durations.AddAsync(item);
            int i =await _context.SaveChangesAsync();
            return i;
        }

        public async Task<int> Update(int id, DurationDTO model)
        {
             var item = await _context.Durations.FindAsync(id);
            item.Description= model.Description;
            item.CourseId = model.CourseId;
            item.Id = id;
            item.DurationDate = model.DurationDate;
            item.DurationType = model.DurationType;

            _context.Entry(item).State = EntityState.Modified;
           int raw=await  _context.SaveChangesAsync();

            return raw;



        }
    }
}

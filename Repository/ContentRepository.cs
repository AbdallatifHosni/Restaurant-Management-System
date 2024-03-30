using E_Learning_Management_System.Data;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Repository;
using Microsoft.EntityFrameworkCore;

namespace E_LearningManagementSystem.Repository
{
    public class ContentRepository : IContentRepository
    {
        private readonly ApplicatioDbContext _context;

        public ContentRepository(ApplicatioDbContext context) 
        {
            _context = context;
        }
        public async Task<int> DeleteById(int id)
        {
            var items = await _context.Contents.FirstOrDefaultAsync(e=>e.ContentId==id);
            var raw = await _context.SaveChangesAsync();
            return raw;
        }

        public Task<IEnumerable<ContentDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ContentDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(ContentDTO cart)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(int id, ContentDTO cart)
        {
            throw new NotImplementedException();
        }
    }
}

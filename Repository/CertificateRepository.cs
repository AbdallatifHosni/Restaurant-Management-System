using E_Learning_Management_System.Data;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Repository;
using Microsoft.EntityFrameworkCore;

namespace E_LearningManagementSystem.Repository
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly ApplicatioDbContext _context;

        public CertificateRepository(ApplicatioDbContext context)
        {
            _context = context;
        }
        public async Task<int> DeleteById(int id)
        {
            var item =await _context.Certificates.FirstOrDefaultAsync(ii => ii.CertificateId==id);
            _context.Certificates.Remove(item);
            var raw =await _context.SaveChangesAsync();
            return raw;

        }

        public Task<IEnumerable<CertificateDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CertificateDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Insert(CertificateDTO cart)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, CertificateDTO cart)
        {
            throw new NotImplementedException();
        }
    }
}

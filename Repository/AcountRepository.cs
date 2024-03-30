using E_Learning_Management_System.Data;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;
using E_Learning_Management_System.Repository;
using Microsoft.EntityFrameworkCore;

namespace E_LearningManagementSystem.Repository
{
    public class AcountRepository : IAcountRepository
    {
        private readonly ApplicatioDbContext _context;
        public AcountRepository(ApplicatioDbContext context) 
        {
            this._context = context;
        
        }
        public async Task<int> DeleteById(string id)
        {
            var asd = await _context.Accounts.FirstOrDefaultAsync(e=>e.AccountAddress==id);
            _context.Entry(asd).State = EntityState.Deleted;
            int raw = await _context.SaveChangesAsync();
            return raw;
        }

        public async Task<List<AccountDTO>> GetAll()
        {

            var items = await _context.Accounts.ToListAsync();

            List<AccountDTO> EEE = new List<AccountDTO>();

            foreach (var account in items)
            {

                var accountDTO = new AccountDTO()
                {
                    AccountAddress = account.AccountAddress,
                    Accounttype = account.Accounttype,

                };

                EEE.Add(accountDTO);
            }

            return EEE;

        }

        public async Task<AccountDTO> GetById(string AccountAddress)
        {
            var item = await _context.Accounts.
                FirstOrDefaultAsync(e=>e.AccountAddress== AccountAddress);

            AccountDTO EEE = new AccountDTO()
            {
               AccountAddress = item.AccountAddress,
               Accounttype = item.AccountAddress,

            };


            return EEE;

        }

        public async Task<AccountDTO> GetByName(string name)
        {
            var item = await _context.Accounts.
                           FirstOrDefaultAsync(e => e.AccountAddress == name);

            AccountDTO EEE = new AccountDTO()
            {
                AccountAddress = item.AccountAddress,
                Accounttype = item.AccountAddress,

            };


            return EEE;

        }

        public async  Task<int> Insert(AccountDTO dto)
        {

            var trtr = new Account()
            {
                AccountAddress=dto.AccountAddress,
                Accounttype = dto.Accounttype,
            };

           await _context.AddAsync(trtr);
          int raw = await _context.SaveChangesAsync();
            return raw;

        }

        public async Task<int> Update(string id, AccountDTO model)
        {
            var olditem = await _context.Accounts.FirstOrDefaultAsync(e=>e.AccountAddress== id);
            
               olditem.AccountAddress = model.AccountAddress;
               olditem. Accounttype= model.Accounttype;

            
            
            _context.Accounts.Update(olditem);
            var raw =await _context.SaveChangesAsync();

            return raw ;
        }
    }
}

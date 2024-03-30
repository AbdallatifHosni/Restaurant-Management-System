using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;


namespace E_Learning_Management_System.Repository
{
    public interface IAcountRepository
    {
        public Task< List<AccountDTO>> GetAll();
        public Task< AccountDTO> GetById(string id);
        public Task<AccountDTO> GetByName(string name);
        public Task<int> Insert(AccountDTO cart);
        public Task<int>  Update(string id, AccountDTO cart);
        public Task<int> DeleteById(string id);



    }
}

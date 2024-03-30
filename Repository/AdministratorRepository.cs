using E_Learning_Management_System.Data;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Model;
using E_Learning_Management_System.Repository;
using Microsoft.EntityFrameworkCore;

namespace E_LearningManagementSystem.Repository
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly ApplicatioDbContext dbContext;

        public AdministratorRepository(ApplicatioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> DeleteById(int id)
        {
            var item = await dbContext.Administrators.FindAsync(id);
            //var item = await dbContext.Administrators.FindAsync(id);
            dbContext.Entry(item).State = EntityState.Deleted;
            var raw = await dbContext.SaveChangesAsync();
            return raw;
           
        }

        public async Task<IEnumerable<AdministratorDTO>> GetAll()
        {
            var items = await dbContext.Administrators.ToListAsync();
             List< AdministratorDTO> models = new List<AdministratorDTO>();
            foreach (var item in items)
            {
                AdministratorDTO rrr = new AdministratorDTO()
                {
                    ID=item.AdminID,
                    Name=item.AdminName,
                };

                models.Add(rrr);


            }

            return models;
        }

        public async Task<AdministratorDTO> GetById(int id)
        {
           var item = await dbContext.Administrators.FindAsync(id);

            var ttt = new AdministratorDTO()
            {
                ID= item.AdminID,
                Name=item.AdminName,

            };
            return ttt;
        }

        public Task<AdministratorDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(AdministratorDTO model)
        {
            var itrem = new Administrator()
            {
                AdminID=model.ID,

               AdminName= model.Name,

            };
             dbContext.Administrators.Add(itrem);
             var raw= dbContext.SaveChangesAsync();
            return raw;        
        }

        public async Task<int> Update(int id, AdministratorDTO model)
        {
            var olditem = await dbContext.Administrators.FindAsync(id);
            var nin = new Administrator()
            {
                AdminName = model.Name,
                AdminID = model.ID,
            };

            dbContext.Entry(nin).State = EntityState.Modified; 

            int raw=  await dbContext.SaveChangesAsync();
            return raw ;




        }
    }
}

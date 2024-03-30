using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Learning_Management_System.Data;
using E_Learning_Management_System.Model;
using E_Learning_Management_System.Repository;
using E_Learning_Management_System.DTO;

namespace E_LearningManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAcountRepository repository;

        public AccountsController(IAcountRepository repository )
        {
            this.repository = repository;
        }

        // GET: api/Accounts
        [HttpGet/*("api/{id:alpha}")*/]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAccounts()
        {
            return await repository.GetAll(); 
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetAccount(string id)
        {
            var account = await  repository.GetByName(id);


            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(string id, AccountDTO account)
        {
            if (id != account.AccountAddress)
            {
                return BadRequest();
            }

              await  repository.Update(id, account);
            

            return NoContent();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(AccountDTO account)
        {
            await repository.Insert(account);
        

            return CreatedAtAction("GetAccount", new { id = account.AccountAddress }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
           var item= await repository.GetByName(id);
            await repository.DeleteById(id);

            if (item == null)
            {
                return NotFound();
            }


            return NoContent();
        }

    }
}

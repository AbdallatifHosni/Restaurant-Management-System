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
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_LearningManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        private readonly IAdministratorRepository _administrator;

        public AdministratorsController(IAdministratorRepository administrator)
        {
            this._administrator = administrator;
        }

        // GET: api/Administrators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdministratorDTO>>> GetAdministrators()
        {
            return Ok(await _administrator.GetAll());
        }

        // GET: api/Administrators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdministratorDTO>> GetAdministrator(int id)
        {
            var administrator = await _administrator.GetById(id);

            if (administrator == null)
            {
                return NotFound();
            }

            return Ok(administrator);
        }

        // PUT: api/Administrators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrator(int id, AdministratorDTO administrator)
        {
            if (id != administrator.ID)
            {
                return BadRequest();
            }

             var tttt=  await  _administrator.Update(id,administrator);

            return Ok(tttt); 
        }

        // POST: api/Administrators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdministratorDTO>> PostAdministrator(AdministratorDTO administrator)
        {
           var item = _administrator.Insert(administrator);

            return CreatedAtAction("GetAdministrator", new { id = administrator.ID }, administrator);
        }

        // DELETE: api/Administrators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrator(int id)
        {
            var administrator = await _administrator.GetById(id);
            if (administrator == null)
            {
                return NotFound();
            }
           await  _administrator.DeleteById(id);


            return NoContent();
        }

    }
}

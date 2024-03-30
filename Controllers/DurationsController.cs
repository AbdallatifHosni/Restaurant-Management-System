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
    public class DurationsController : ControllerBase
    {
        private readonly IDurationRepository _repository;

        public DurationsController(IDurationRepository repository)
        {
            this._repository = repository;
        }

        // GET: api/Durations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DurationDTO>>> GetDuration()
        {
            return Ok(await _repository.GetAll());
        }

        // GET: api/Durations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DurationDTO>> GetDuration(int id)
        {
            var tt= await _repository.GetById(id); 

            return Ok(tt);
        }

        // PUT: api/Durations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuration(int id, DurationDTO duration)
        {
            if (id != duration.Id)
            {
                return BadRequest();
            }
            await _repository.Update(id, duration);
            

            try
            {

            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Durations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DurationDTO>> PostDuration(DurationDTO duration)
        {
           await  _repository.Insert(duration);


            return CreatedAtAction("GetDuration", new { id = duration.Id }, duration);
        }

        // DELETE: api/Durations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuration(int id)
        {
            var duration = await _repository.DeleteById(id);
            if (duration == null)
            {
                return NotFound();
            }


            return NoContent();
        }

    }
}

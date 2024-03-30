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
    public class LearnersController : ControllerBase
    {
        private readonly ILearnerRepository _repository;

        public LearnersController(ILearnerRepository repository)
        {
          
            this._repository = repository;
        }

        // GET: api/Learners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LearnerDTO>>> GetLearner()
        {
           var learners =await  _repository.GetAll();

            return  Ok(learners);
        }

        // GET: api/Learners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LearnerDTO>> GetLearner(int id)
        {
            var learner = await _repository.GetById(id);

            if (learner == null)
            {
                return NotFound();
            }

            return Ok(learner);
        }

        // PUT: api/Learners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLearner(int id, LearnerDTO learner)
        {
            if (id != learner.Id)
            {
                return BadRequest();
            }

             await _repository.Update(id, learner);

            return Ok(learner);
        }

        // POST: api/Learners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LearnerDTO>> PostLearner(LearnerDTO learner)
        {
           await  _repository.Insert(learner);
  

            return CreatedAtAction("GetLearner", new { id = learner.Id }, learner);
        }

        // DELETE: api/Learners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLearner(int id)
        {
            await _repository.DeleteById(id);


            return NoContent();
        }

    }
}

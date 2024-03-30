using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Learning_Management_System.Data;
using E_Learning_Management_System.Model;
using E_LearningManagementSystem.Repository;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Repository;

namespace E_LearningManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackRepository _repository;

        public FeedbacksController(IFeedbackRepository repository )
        {
            this._repository = repository;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDTO>>> GetFeedbackDTO()
        {
            var models = await _repository.GetAll();
            return Ok(models);
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackDTO>> GetFeedbackDTO(int id)
        {
            var feedbackDTO = await _repository.GetById(id);

            if (feedbackDTO == null)
            {
                return NotFound();
            }

            return Ok(feedbackDTO);
        }

        // PUT: api/Feedbacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedbackDTO(int id, FeedbackDTO feedback)
        {
            if (id != feedback.FeedbackId)
            {
                return BadRequest();
            }

            await _repository.Update(id, feedback);

            try
            {
               
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return NoContent();
        }

        // POST: api/Feedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedbackDTO>> PostFeedbackDTO(FeedbackDTO model)
        {
            await _repository.Insert(model);

            return CreatedAtAction("GetFeedbackDTO", new { id = model.FeedbackId }, model);
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbackDTO(int id)
        {
            var feedbackDTO = await _repository.DeleteById(id);
            if (feedbackDTO == null)
            {
                return NotFound();
            }


            return NoContent();
        }

    }
}

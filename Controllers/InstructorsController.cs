using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Learning_Management_System.Data;
using E_Learning_Management_System.Model;
using E_LearningManagementSystem.DTO;
using E_LearningManagementSystem.Repository;
using E_Learning_Management_System.Repository;
using E_Learning_Management_System.DTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_LearningManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
  
        private readonly IInstructorRepository _repository;

        public InstructorsController(ApplicatioDbContext context,IInstructorRepository repository)
        {
            this._repository = repository;
        }

        // GET: api/Instructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorDTO>>> GetInstructors()
        {
         var items =  await _repository.GetAll();
            return Ok(items);
        }

        // GET: api/Instructors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instructor>> GetInstructor(int id)
        {
            var instructor = await _repository.GetById(id);

            if (instructor == null)
            {
                return NotFound();
            }

            return Ok(instructor);
        }

        // PUT: api/Instructors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstructor(int id, InstructorDTO instructor)
        {
            if (id != instructor.InstructorID)
            {
                return BadRequest();
            }

            var item= await _repository.Update(id, instructor);          


            return Ok(item);
        }

        // POST: api/Instructors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InstructorDTO>> PostInstructor(InstructorDTO instructor)
        {
             await _repository.Insert(instructor);


            return CreatedAtAction("GetInstructor", new { id = instructor.InstructorID }, instructor);
        }

        // DELETE: api/Instructors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            var instructor = await _repository.GetById(id);
            if (instructor == null)
            {
                return NotFound();
            }
             await _repository.DeleteById(id);

            return NoContent();
        }
        [HttpGet("apiii/{id:int}")]
        public async Task<IActionResult> getInstructorCourseName(int id)
        {
            var item  =await _repository.getInstructorCourseName(id);

            return Ok(item);

        }
    }
}

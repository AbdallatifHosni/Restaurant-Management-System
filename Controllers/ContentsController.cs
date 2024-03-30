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
    public class ContentsController : ControllerBase
    {
        private readonly IContentRepository _repository;

        public ContentsController(IContentRepository repository)
        {
            this._repository = repository;
        }

        // GET: api/ContentDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentDTO>>> GetContentDTO()
        {
            return Ok(await _repository.GetAll());
        }

        // GET: api/ContentDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContentDTO>> GetContentDTO(int id)
        {
            var contentDTO= await _repository.GetById(id);

            if (contentDTO == null)
            {
                return NotFound();
            }

            return Ok(contentDTO) ;
        }

        // PUT: api/ContentDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContentDTO(int id, ContentDTO contentDTO)
        {
            if (id != contentDTO.ContentId)
            {
                return BadRequest();
            }

            await _repository.Update(id, contentDTO);


            return NoContent();
        }

        // POST: api/ContentDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContentDTO>> PostContentDTO(ContentDTO contentDTO)
        {
             await _repository.Insert(contentDTO);

            return CreatedAtAction("GetContentDTO", new { id = contentDTO.ContentId }, contentDTO);
        }

        // DELETE: api/ContentDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentDTO(int id)
        {
            var contentDTO = await _repository.GetById(id);
            if (contentDTO == null)
            {
                return NotFound();
            }

            await _repository.DeleteById(id);

            return NoContent();
        }

    }
}

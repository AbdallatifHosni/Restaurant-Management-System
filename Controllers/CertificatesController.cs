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
    public class CertificatesController : ControllerBase
    {
        private readonly ICertificateRepository _repository;

        public CertificatesController(ICertificateRepository repository )
        {
            this._repository = repository;
        }

        // GET: api/Certificates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificateDTO>>> GetCertificates()
        {
            return Ok( await _repository.GetAll());
        }

        // GET: api/Certificates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificateDTO>> GetCertificate(int id)
        {
            var certificate = await _repository.GetById(id);

            if (certificate == null)
            {
                return NotFound();
            }

            return Ok(certificate);
        }

        // PUT: api/Certificates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificate(int id, CertificateDTO certificate)
        {
            if (id != certificate.CertificateId)
            {
                return BadRequest();
            }
             await _repository.Update(id, certificate);

            return NoContent();
        }

        // POST: api/Certificates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CertificateDTO>> PostCertificate(CertificateDTO certificate)
        {
            await _repository.Insert(certificate);

            return CreatedAtAction("GetCertificate", new { id = certificate.CertificateId }, certificate);
        }

        // DELETE: api/Certificates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            var certificate = await _repository.GetById(id);
            if (certificate == null)
            {
                return NotFound();
            }

            await _repository.DeleteById(certificate.CertificateId);

            return NoContent();
        }

    }
}

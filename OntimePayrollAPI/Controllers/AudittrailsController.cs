using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

namespace OntimePayrollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudittrailsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public AudittrailsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Audittrails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Audittrail>>> GetAudittrails()
        {
            return await _context.Audittrails.ToListAsync();
        }

        // GET: api/Audittrails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Audittrail>> GetAudittrail(string id)
        {
            var audittrail = await _context.Audittrails.FindAsync(id);

            if (audittrail == null)
            {
                return NotFound();
            }

            return audittrail;
        }

        // PUT: api/Audittrails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAudittrail(string id, Audittrail audittrail)
        {
            if (id != audittrail.UserId)
            {
                return BadRequest();
            }

            _context.Entry(audittrail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AudittrailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Audittrails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Audittrail>> PostAudittrail(Audittrail audittrail)
        {
            _context.Audittrails.Add(audittrail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AudittrailExists(audittrail.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAudittrail", new { id = audittrail.UserId }, audittrail);
        }

        // DELETE: api/Audittrails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAudittrail(string id)
        {
            var audittrail = await _context.Audittrails.FindAsync(id);
            if (audittrail == null)
            {
                return NotFound();
            }

            _context.Audittrails.Remove(audittrail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AudittrailExists(string id)
        {
            return _context.Audittrails.Any(e => e.UserId == id);
        }
    }
}

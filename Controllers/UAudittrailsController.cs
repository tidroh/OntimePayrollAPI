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
    public class UAudittrailsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public UAudittrailsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/UAudittrails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UAudittrail>>> GetUAudittrails()
        {
            return await _context.UAudittrails.ToListAsync();
        }

        // GET: api/UAudittrails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UAudittrail>> GetUAudittrail(int? id)
        {
            var uAudittrail = await _context.UAudittrails.FindAsync(id);

            if (uAudittrail == null)
            {
                return NotFound();
            }

            return uAudittrail;
        }

        // PUT: api/UAudittrails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUAudittrail(int? id, UAudittrail uAudittrail)
        {
            if (id != uAudittrail.Logid)
            {
                return BadRequest();
            }

            _context.Entry(uAudittrail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UAudittrailExists(id))
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

        // POST: api/UAudittrails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UAudittrail>> PostUAudittrail(UAudittrail uAudittrail)
        {
            _context.UAudittrails.Add(uAudittrail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUAudittrail", new { id = uAudittrail.Logid }, uAudittrail);
        }

        // DELETE: api/UAudittrails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUAudittrail(int? id)
        {
            var uAudittrail = await _context.UAudittrails.FindAsync(id);
            if (uAudittrail == null)
            {
                return NotFound();
            }

            _context.UAudittrails.Remove(uAudittrail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UAudittrailExists(int? id)
        {
            return _context.UAudittrails.Any(e => e.Logid == id);
        }
    }
}

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
    public class NewAuditTrailsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public NewAuditTrailsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/NewAuditTrails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewAuditTrail>>> GetNewAuditTrails()
        {
            return await _context.NewAuditTrails.ToListAsync();
        }

        // GET: api/NewAuditTrails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewAuditTrail>> GetNewAuditTrail(string id)
        {
            var newAuditTrail = await _context.NewAuditTrails.FindAsync(id);

            if (newAuditTrail == null)
            {
                return NotFound();
            }

            return newAuditTrail;
        }

        // PUT: api/NewAuditTrails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewAuditTrail(string id, NewAuditTrail newAuditTrail)
        {
            if (id != newAuditTrail.UserId)
            {
                return BadRequest();
            }

            _context.Entry(newAuditTrail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewAuditTrailExists(id))
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

        // POST: api/NewAuditTrails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NewAuditTrail>> PostNewAuditTrail(NewAuditTrail newAuditTrail)
        {
            _context.NewAuditTrails.Add(newAuditTrail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NewAuditTrailExists(newAuditTrail.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNewAuditTrail", new { id = newAuditTrail.UserId }, newAuditTrail);
        }

        // DELETE: api/NewAuditTrails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewAuditTrail(string id)
        {
            var newAuditTrail = await _context.NewAuditTrails.FindAsync(id);
            if (newAuditTrail == null)
            {
                return NotFound();
            }

            _context.NewAuditTrails.Remove(newAuditTrail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewAuditTrailExists(string id)
        {
            return _context.NewAuditTrails.Any(e => e.UserId == id);
        }
    }
}

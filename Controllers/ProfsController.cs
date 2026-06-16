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
    public class ProfsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public ProfsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Profs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prof>>> GetProfs()
        {
            return await _context.Profs.ToListAsync();
        }

        // GET: api/Profs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prof>> GetProf(string id)
        {
            var prof = await _context.Profs.FindAsync(id);

            if (prof == null)
            {
                return NotFound();
            }

            return prof;
        }

        // PUT: api/Profs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProf(string id, Prof prof)
        {
            if (id != prof.Elevel)
            {
                return BadRequest();
            }

            _context.Entry(prof).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfExists(id))
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

        // POST: api/Profs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prof>> PostProf(Prof prof)
        {
            _context.Profs.Add(prof);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfExists(prof.Elevel))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProf", new { id = prof.Elevel }, prof);
        }

        // DELETE: api/Profs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProf(string id)
        {
            var prof = await _context.Profs.FindAsync(id);
            if (prof == null)
            {
                return NotFound();
            }

            _context.Profs.Remove(prof);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfExists(string id)
        {
            return _context.Profs.Any(e => e.Elevel == id);
        }
    }
}

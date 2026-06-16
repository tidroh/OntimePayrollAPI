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
    public class AentriesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public AentriesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Aentries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aentry>>> GetAentries()
        {
            return await _context.Aentries.ToListAsync();
        }

        // GET: api/Aentries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aentry>> GetAentry(string id)
        {
            var aentry = await _context.Aentries.FindAsync(id);

            if (aentry == null)
            {
                return NotFound();
            }

            return aentry;
        }

        // PUT: api/Aentries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAentry(string id, Aentry aentry)
        {
            if (id != aentry.Acode)
            {
                return BadRequest();
            }

            _context.Entry(aentry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AentryExists(id))
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

        // POST: api/Aentries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aentry>> PostAentry(Aentry aentry)
        {
            _context.Aentries.Add(aentry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AentryExists(aentry.Acode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAentry", new { id = aentry.Acode }, aentry);
        }

        // DELETE: api/Aentries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAentry(string id)
        {
            var aentry = await _context.Aentries.FindAsync(id);
            if (aentry == null)
            {
                return NotFound();
            }

            _context.Aentries.Remove(aentry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AentryExists(string id)
        {
            return _context.Aentries.Any(e => e.Acode == id);
        }
    }
}

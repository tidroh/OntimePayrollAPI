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
    public class LentriesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public LentriesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Lentries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lentry>>> GetLentries()
        {
            return await _context.Lentries.ToListAsync();
        }

        // GET: api/Lentries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lentry>> GetLentry(string id)
        {
            var lentry = await _context.Lentries.FindAsync(id);

            if (lentry == null)
            {
                return NotFound();
            }

            return lentry;
        }

        // PUT: api/Lentries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLentry(string id, Lentry lentry)
        {
            if (id != lentry.Acode)
            {
                return BadRequest();
            }

            _context.Entry(lentry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LentryExists(id))
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

        // POST: api/Lentries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lentry>> PostLentry(Lentry lentry)
        {
            _context.Lentries.Add(lentry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LentryExists(lentry.Acode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLentry", new { id = lentry.Acode }, lentry);
        }

        // DELETE: api/Lentries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLentry(string id)
        {
            var lentry = await _context.Lentries.FindAsync(id);
            if (lentry == null)
            {
                return NotFound();
            }

            _context.Lentries.Remove(lentry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LentryExists(string id)
        {
            return _context.Lentries.Any(e => e.Acode == id);
        }
    }
}

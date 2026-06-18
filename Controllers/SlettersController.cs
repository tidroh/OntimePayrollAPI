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
    public class SlettersController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public SlettersController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Sletters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sletter>>> GetSletters()
        {
            return await _context.Sletters.ToListAsync();
        }

        // GET: api/Sletters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sletter>> GetSletter(string id)
        {
            var sletter = await _context.Sletters.FindAsync(id);

            if (sletter == null)
            {
                return NotFound();
            }

            return sletter;
        }

        // PUT: api/Sletters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSletter(string id, Sletter sletter)
        {
            if (id != sletter.Ncode)
            {
                return BadRequest();
            }

            _context.Entry(sletter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SletterExists(id))
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

        // POST: api/Sletters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sletter>> PostSletter(Sletter sletter)
        {
            _context.Sletters.Add(sletter);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SletterExists(sletter.Ncode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSletter", new { id = sletter.Ncode }, sletter);
        }

        // DELETE: api/Sletters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSletter(string id)
        {
            var sletter = await _context.Sletters.FindAsync(id);
            if (sletter == null)
            {
                return NotFound();
            }

            _context.Sletters.Remove(sletter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SletterExists(string id)
        {
            return _context.Sletters.Any(e => e.Ncode == id);
        }
    }
}

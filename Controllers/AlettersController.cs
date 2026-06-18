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
    public class AlettersController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public AlettersController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Aletters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aletter>>> GetAletters()
        {
            return await _context.Aletters.ToListAsync();
        }

        // GET: api/Aletters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aletter>> GetAletter(string id)
        {
            var aletter = await _context.Aletters.FindAsync(id);

            if (aletter == null)
            {
                return NotFound();
            }

            return aletter;
        }

        // PUT: api/Aletters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAletter(string id, Aletter aletter)
        {
            if (id != aletter.Acode)
            {
                return BadRequest();
            }

            _context.Entry(aletter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AletterExists(id))
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

        // POST: api/Aletters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aletter>> PostAletter(Aletter aletter)
        {
            _context.Aletters.Add(aletter);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AletterExists(aletter.Acode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAletter", new { id = aletter.Acode }, aletter);
        }

        // DELETE: api/Aletters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAletter(string id)
        {
            var aletter = await _context.Aletters.FindAsync(id);
            if (aletter == null)
            {
                return NotFound();
            }

            _context.Aletters.Remove(aletter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AletterExists(string id)
        {
            return _context.Aletters.Any(e => e.Acode == id);
        }
    }
}

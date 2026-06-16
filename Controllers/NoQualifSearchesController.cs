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
    public class NoQualifSearchesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public NoQualifSearchesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/NoQualifSearches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoQualifSearch>>> GetNoQualifSearches()
        {
            return await _context.NoQualifSearches.ToListAsync();
        }

        // GET: api/NoQualifSearches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoQualifSearch>> GetNoQualifSearch(DateTime? id)
        {
            var noQualifSearch = await _context.NoQualifSearches.FindAsync(id);

            if (noQualifSearch == null)
            {
                return NotFound();
            }

            return noQualifSearch;
        }

        // PUT: api/NoQualifSearches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoQualifSearch(DateTime? id, NoQualifSearch noQualifSearch)
        {
            if (id != noQualifSearch.Dob)
            {
                return BadRequest();
            }

            _context.Entry(noQualifSearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoQualifSearchExists(id))
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

        // POST: api/NoQualifSearches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NoQualifSearch>> PostNoQualifSearch(NoQualifSearch noQualifSearch)
        {
            _context.NoQualifSearches.Add(noQualifSearch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NoQualifSearchExists(noQualifSearch.Dob))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNoQualifSearch", new { id = noQualifSearch.Dob }, noQualifSearch);
        }

        // DELETE: api/NoQualifSearches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoQualifSearch(DateTime? id)
        {
            var noQualifSearch = await _context.NoQualifSearches.FindAsync(id);
            if (noQualifSearch == null)
            {
                return NotFound();
            }

            _context.NoQualifSearches.Remove(noQualifSearch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoQualifSearchExists(DateTime? id)
        {
            return _context.NoQualifSearches.Any(e => e.Dob == id);
        }
    }
}

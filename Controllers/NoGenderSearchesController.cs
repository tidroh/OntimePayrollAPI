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
    public class NoGenderSearchesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public NoGenderSearchesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/NoGenderSearches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoGenderSearch>>> GetNoGenderSearches()
        {
            return await _context.NoGenderSearches.ToListAsync();
        }

        // GET: api/NoGenderSearches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoGenderSearch>> GetNoGenderSearch(DateTime? id)
        {
            var noGenderSearch = await _context.NoGenderSearches.FindAsync(id);

            if (noGenderSearch == null)
            {
                return NotFound();
            }

            return noGenderSearch;
        }

        // PUT: api/NoGenderSearches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoGenderSearch(DateTime? id, NoGenderSearch noGenderSearch)
        {
            if (id != noGenderSearch.Dob)
            {
                return BadRequest();
            }

            _context.Entry(noGenderSearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoGenderSearchExists(id))
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

        // POST: api/NoGenderSearches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NoGenderSearch>> PostNoGenderSearch(NoGenderSearch noGenderSearch)
        {
            _context.NoGenderSearches.Add(noGenderSearch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NoGenderSearchExists(noGenderSearch.Dob))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNoGenderSearch", new { id = noGenderSearch.Dob }, noGenderSearch);
        }

        // DELETE: api/NoGenderSearches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoGenderSearch(DateTime? id)
        {
            var noGenderSearch = await _context.NoGenderSearches.FindAsync(id);
            if (noGenderSearch == null)
            {
                return NotFound();
            }

            _context.NoGenderSearches.Remove(noGenderSearch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoGenderSearchExists(DateTime? id)
        {
            return _context.NoGenderSearches.Any(e => e.Dob == id);
        }
    }
}

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
    public class NoMarkSearchesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public NoMarkSearchesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/NoMarkSearches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoMarkSearch>>> GetNoMarkSearches()
        {
            return await _context.NoMarkSearches.ToListAsync();
        }

        // GET: api/NoMarkSearches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoMarkSearch>> GetNoMarkSearch(DateTime? id)
        {
            var noMarkSearch = await _context.NoMarkSearches.FindAsync(id);

            if (noMarkSearch == null)
            {
                return NotFound();
            }

            return noMarkSearch;
        }

        // PUT: api/NoMarkSearches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoMarkSearch(DateTime? id, NoMarkSearch noMarkSearch)
        {
            if (id != noMarkSearch.Dob)
            {
                return BadRequest();
            }

            _context.Entry(noMarkSearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoMarkSearchExists(id))
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

        // POST: api/NoMarkSearches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NoMarkSearch>> PostNoMarkSearch(NoMarkSearch noMarkSearch)
        {
            _context.NoMarkSearches.Add(noMarkSearch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NoMarkSearchExists(noMarkSearch.Dob))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNoMarkSearch", new { id = noMarkSearch.Dob }, noMarkSearch);
        }

        // DELETE: api/NoMarkSearches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoMarkSearch(DateTime? id)
        {
            var noMarkSearch = await _context.NoMarkSearches.FindAsync(id);
            if (noMarkSearch == null)
            {
                return NotFound();
            }

            _context.NoMarkSearches.Remove(noMarkSearch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoMarkSearchExists(DateTime? id)
        {
            return _context.NoMarkSearches.Any(e => e.Dob == id);
        }
    }
}

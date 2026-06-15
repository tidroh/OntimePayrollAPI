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
    public class DobonlySearchesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public DobonlySearchesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/DobonlySearches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DobonlySearch>>> GetDobonlySearches()
        {
            return await _context.DobonlySearches.ToListAsync();
        }

        // GET: api/DobonlySearches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DobonlySearch>> GetDobonlySearch(DateTime? id)
        {
            var dobonlySearch = await _context.DobonlySearches.FindAsync(id);

            if (dobonlySearch == null)
            {
                return NotFound();
            }

            return dobonlySearch;
        }

        // PUT: api/DobonlySearches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDobonlySearch(DateTime? id, DobonlySearch dobonlySearch)
        {
            if (id != dobonlySearch.Dob)
            {
                return BadRequest();
            }

            _context.Entry(dobonlySearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DobonlySearchExists(id))
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

        // POST: api/DobonlySearches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DobonlySearch>> PostDobonlySearch(DobonlySearch dobonlySearch)
        {
            _context.DobonlySearches.Add(dobonlySearch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DobonlySearchExists(dobonlySearch.Dob))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDobonlySearch", new { id = dobonlySearch.Dob }, dobonlySearch);
        }

        // DELETE: api/DobonlySearches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDobonlySearch(DateTime? id)
        {
            var dobonlySearch = await _context.DobonlySearches.FindAsync(id);
            if (dobonlySearch == null)
            {
                return NotFound();
            }

            _context.DobonlySearches.Remove(dobonlySearch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DobonlySearchExists(DateTime? id)
        {
            return _context.DobonlySearches.Any(e => e.Dob == id);
        }
    }
}

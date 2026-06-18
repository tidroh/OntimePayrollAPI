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
    public class DobQualSearchesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public DobQualSearchesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/DobQualSearches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DobQualSearch>>> GetDobQualSearches()
        {
            return await _context.DobQualSearches.ToListAsync();
        }

        // GET: api/DobQualSearches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DobQualSearch>> GetDobQualSearch(DateTime? id)
        {
            var dobQualSearch = await _context.DobQualSearches.FindAsync(id);

            if (dobQualSearch == null)
            {
                return NotFound();
            }

            return dobQualSearch;
        }

        // PUT: api/DobQualSearches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDobQualSearch(DateTime? id, DobQualSearch dobQualSearch)
        {
            if (id != dobQualSearch.Dob)
            {
                return BadRequest();
            }

            _context.Entry(dobQualSearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DobQualSearchExists(id))
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

        // POST: api/DobQualSearches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DobQualSearch>> PostDobQualSearch(DobQualSearch dobQualSearch)
        {
            _context.DobQualSearches.Add(dobQualSearch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DobQualSearchExists(dobQualSearch.Dob))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDobQualSearch", new { id = dobQualSearch.Dob }, dobQualSearch);
        }

        // DELETE: api/DobQualSearches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDobQualSearch(DateTime? id)
        {
            var dobQualSearch = await _context.DobQualSearches.FindAsync(id);
            if (dobQualSearch == null)
            {
                return NotFound();
            }

            _context.DobQualSearches.Remove(dobQualSearch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DobQualSearchExists(DateTime? id)
        {
            return _context.DobQualSearches.Any(e => e.Dob == id);
        }
    }
}

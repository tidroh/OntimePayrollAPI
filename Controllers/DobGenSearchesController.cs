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
    public class DobGenSearchesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public DobGenSearchesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/DobGenSearches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DobGenSearch>>> GetDobGenSearches()
        {
            return await _context.DobGenSearches.ToListAsync();
        }

        // GET: api/DobGenSearches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DobGenSearch>> GetDobGenSearch(DateTime? id)
        {
            var dobGenSearch = await _context.DobGenSearches.FindAsync(id);

            if (dobGenSearch == null)
            {
                return NotFound();
            }

            return dobGenSearch;
        }

        // PUT: api/DobGenSearches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDobGenSearch(DateTime? id, DobGenSearch dobGenSearch)
        {
            if (id != dobGenSearch.Dob)
            {
                return BadRequest();
            }

            _context.Entry(dobGenSearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DobGenSearchExists(id))
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

        // POST: api/DobGenSearches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DobGenSearch>> PostDobGenSearch(DobGenSearch dobGenSearch)
        {
            _context.DobGenSearches.Add(dobGenSearch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DobGenSearchExists(dobGenSearch.Dob))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDobGenSearch", new { id = dobGenSearch.Dob }, dobGenSearch);
        }

        // DELETE: api/DobGenSearches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDobGenSearch(DateTime? id)
        {
            var dobGenSearch = await _context.DobGenSearches.FindAsync(id);
            if (dobGenSearch == null)
            {
                return NotFound();
            }

            _context.DobGenSearches.Remove(dobGenSearch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DobGenSearchExists(DateTime? id)
        {
            return _context.DobGenSearches.Any(e => e.Dob == id);
        }
    }
}

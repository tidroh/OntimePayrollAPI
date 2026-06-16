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
    public class AllSearchesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public AllSearchesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/AllSearches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllSearch>>> GetAllSearches()
        {
            return await _context.AllSearches.ToListAsync();
        }

        // GET: api/AllSearches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllSearch>> GetAllSearch(DateTime? id)
        {
            var allSearch = await _context.AllSearches.FindAsync(id);

            if (allSearch == null)
            {
                return NotFound();
            }

            return allSearch;
        }

        // PUT: api/AllSearches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllSearch(DateTime? id, AllSearch allSearch)
        {
            if (id != allSearch.Dob)
            {
                return BadRequest();
            }

            _context.Entry(allSearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllSearchExists(id))
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

        // POST: api/AllSearches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AllSearch>> PostAllSearch(AllSearch allSearch)
        {
            _context.AllSearches.Add(allSearch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AllSearchExists(allSearch.Dob))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAllSearch", new { id = allSearch.Dob }, allSearch);
        }

        // DELETE: api/AllSearches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllSearch(DateTime? id)
        {
            var allSearch = await _context.AllSearches.FindAsync(id);
            if (allSearch == null)
            {
                return NotFound();
            }

            _context.AllSearches.Remove(allSearch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllSearchExists(DateTime? id)
        {
            return _context.AllSearches.Any(e => e.Dob == id);
        }
    }
}

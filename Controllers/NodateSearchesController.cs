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
    public class NodateSearchesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public NodateSearchesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/NodateSearches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NodateSearch>>> GetNodateSearches()
        {
            return await _context.NodateSearches.ToListAsync();
        }

        // GET: api/NodateSearches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NodateSearch>> GetNodateSearch(string id)
        {
            var nodateSearch = await _context.NodateSearches.FindAsync(id);

            if (nodateSearch == null)
            {
                return NotFound();
            }

            return nodateSearch;
        }

        // PUT: api/NodateSearches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNodateSearch(string id, NodateSearch nodateSearch)
        {
            if (id != nodateSearch.MyQualification)
            {
                return BadRequest();
            }

            _context.Entry(nodateSearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NodateSearchExists(id))
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

        // POST: api/NodateSearches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NodateSearch>> PostNodateSearch(NodateSearch nodateSearch)
        {
            _context.NodateSearches.Add(nodateSearch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NodateSearchExists(nodateSearch.MyQualification))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNodateSearch", new { id = nodateSearch.MyQualification }, nodateSearch);
        }

        // DELETE: api/NodateSearches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNodateSearch(string id)
        {
            var nodateSearch = await _context.NodateSearches.FindAsync(id);
            if (nodateSearch == null)
            {
                return NotFound();
            }

            _context.NodateSearches.Remove(nodateSearch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NodateSearchExists(string id)
        {
            return _context.NodateSearches.Any(e => e.MyQualification == id);
        }
    }
}

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
    public class QualifOnlySearchesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public QualifOnlySearchesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/QualifOnlySearches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QualifOnlySearch>>> GetQualifOnlySearches()
        {
            return await _context.QualifOnlySearches.ToListAsync();
        }

        // GET: api/QualifOnlySearches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QualifOnlySearch>> GetQualifOnlySearch(string id)
        {
            var qualifOnlySearch = await _context.QualifOnlySearches.FindAsync(id);

            if (qualifOnlySearch == null)
            {
                return NotFound();
            }

            return qualifOnlySearch;
        }

        // PUT: api/QualifOnlySearches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQualifOnlySearch(string id, QualifOnlySearch qualifOnlySearch)
        {
            if (id != qualifOnlySearch.MyQualification)
            {
                return BadRequest();
            }

            _context.Entry(qualifOnlySearch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QualifOnlySearchExists(id))
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

        // POST: api/QualifOnlySearches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QualifOnlySearch>> PostQualifOnlySearch(QualifOnlySearch qualifOnlySearch)
        {
            _context.QualifOnlySearches.Add(qualifOnlySearch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QualifOnlySearchExists(qualifOnlySearch.MyQualification))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQualifOnlySearch", new { id = qualifOnlySearch.MyQualification }, qualifOnlySearch);
        }

        // DELETE: api/QualifOnlySearches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQualifOnlySearch(string id)
        {
            var qualifOnlySearch = await _context.QualifOnlySearches.FindAsync(id);
            if (qualifOnlySearch == null)
            {
                return NotFound();
            }

            _context.QualifOnlySearches.Remove(qualifOnlySearch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QualifOnlySearchExists(string id)
        {
            return _context.QualifOnlySearches.Any(e => e.MyQualification == id);
        }
    }
}

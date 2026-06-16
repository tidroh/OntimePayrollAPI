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
    public class RefSourcesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public RefSourcesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/RefSources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefSource>>> GetRefSources()
        {
            return await _context.RefSources.ToListAsync();
        }

        // GET: api/RefSources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RefSource>> GetRefSource(string id)
        {
            var refSource = await _context.RefSources.FindAsync(id);

            if (refSource == null)
            {
                return NotFound();
            }

            return refSource;
        }

        // PUT: api/RefSources/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRefSource(string id, RefSource refSource)
        {
            if (id != refSource.Ncode)
            {
                return BadRequest();
            }

            _context.Entry(refSource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefSourceExists(id))
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

        // POST: api/RefSources
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RefSource>> PostRefSource(RefSource refSource)
        {
            _context.RefSources.Add(refSource);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RefSourceExists(refSource.Ncode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRefSource", new { id = refSource.Ncode }, refSource);
        }

        // DELETE: api/RefSources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRefSource(string id)
        {
            var refSource = await _context.RefSources.FindAsync(id);
            if (refSource == null)
            {
                return NotFound();
            }

            _context.RefSources.Remove(refSource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RefSourceExists(string id)
        {
            return _context.RefSources.Any(e => e.Ncode == id);
        }
    }
}

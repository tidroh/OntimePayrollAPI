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
    public class RefsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public RefsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Refs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ref>>> GetRefs()
        {
            return await _context.Refs.ToListAsync();
        }

        // GET: api/Refs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ref>> GetRef(string id)
        {
            var @ref = await _context.Refs.FindAsync(id);

            if (@ref == null)
            {
                return NotFound();
            }

            return @ref;
        }

        // PUT: api/Refs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRef(string id, Ref @ref)
        {
            if (id != @ref.Idno)
            {
                return BadRequest();
            }

            _context.Entry(@ref).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefExists(id))
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

        // POST: api/Refs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ref>> PostRef(Ref @ref)
        {
            _context.Refs.Add(@ref);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RefExists(@ref.Idno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRef", new { id = @ref.Idno }, @ref);
        }

        // DELETE: api/Refs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRef(string id)
        {
            var @ref = await _context.Refs.FindAsync(id);
            if (@ref == null)
            {
                return NotFound();
            }

            _context.Refs.Remove(@ref);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RefExists(string id)
        {
            return _context.Refs.Any(e => e.Idno == id);
        }
    }
}

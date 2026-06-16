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
    public class PgroupsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public PgroupsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Pgroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pgroup>>> GetPgroups()
        {
            return await _context.Pgroups.ToListAsync();
        }

        // GET: api/Pgroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pgroup>> GetPgroup(string id)
        {
            var pgroup = await _context.Pgroups.FindAsync(id);

            if (pgroup == null)
            {
                return NotFound();
            }

            return pgroup;
        }

        // PUT: api/Pgroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPgroup(string id, Pgroup pgroup)
        {
            if (id != pgroup.Ncode)
            {
                return BadRequest();
            }

            _context.Entry(pgroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PgroupExists(id))
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

        // POST: api/Pgroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pgroup>> PostPgroup(Pgroup pgroup)
        {
            _context.Pgroups.Add(pgroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PgroupExists(pgroup.Ncode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPgroup", new { id = pgroup.Ncode }, pgroup);
        }

        // DELETE: api/Pgroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePgroup(string id)
        {
            var pgroup = await _context.Pgroups.FindAsync(id);
            if (pgroup == null)
            {
                return NotFound();
            }

            _context.Pgroups.Remove(pgroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PgroupExists(string id)
        {
            return _context.Pgroups.Any(e => e.Ncode == id);
        }
    }
}

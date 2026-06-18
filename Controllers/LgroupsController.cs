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
    public class LgroupsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public LgroupsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Lgroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lgroup>>> GetLgroups()
        {
            return await _context.Lgroups.ToListAsync();
        }

        // GET: api/Lgroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lgroup>> GetLgroup(string id)
        {
            var lgroup = await _context.Lgroups.FindAsync(id);

            if (lgroup == null)
            {
                return NotFound();
            }

            return lgroup;
        }

        // PUT: api/Lgroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLgroup(string id, Lgroup lgroup)
        {
            if (id != lgroup.Ncode)
            {
                return BadRequest();
            }

            _context.Entry(lgroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LgroupExists(id))
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

        // POST: api/Lgroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lgroup>> PostLgroup(Lgroup lgroup)
        {
            _context.Lgroups.Add(lgroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LgroupExists(lgroup.Ncode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLgroup", new { id = lgroup.Ncode }, lgroup);
        }

        // DELETE: api/Lgroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLgroup(string id)
        {
            var lgroup = await _context.Lgroups.FindAsync(id);
            if (lgroup == null)
            {
                return NotFound();
            }

            _context.Lgroups.Remove(lgroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LgroupExists(string id)
        {
            return _context.Lgroups.Any(e => e.Ncode == id);
        }
    }
}

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
    public class NeedsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public NeedsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Needs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Need>>> GetNeeds()
        {
            return await _context.Needs.ToListAsync();
        }

        // GET: api/Needs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Need>> GetNeed(string id)
        {
            var need = await _context.Needs.FindAsync(id);

            if (need == null)
            {
                return NotFound();
            }

            return need;
        }

        // PUT: api/Needs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNeed(string id, Need need)
        {
            if (id != need.Ccode)
            {
                return BadRequest();
            }

            _context.Entry(need).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NeedExists(id))
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

        // POST: api/Needs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Need>> PostNeed(Need need)
        {
            _context.Needs.Add(need);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NeedExists(need.Ccode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNeed", new { id = need.Ccode }, need);
        }

        // DELETE: api/Needs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNeed(string id)
        {
            var need = await _context.Needs.FindAsync(id);
            if (need == null)
            {
                return NotFound();
            }

            _context.Needs.Remove(need);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NeedExists(string id)
        {
            return _context.Needs.Any(e => e.Ccode == id);
        }
    }
}

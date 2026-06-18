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
    public class NewNeedsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public NewNeedsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/NewNeeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewNeed>>> GetNewNeeds()
        {
            return await _context.NewNeeds.ToListAsync();
        }

        // GET: api/NewNeeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewNeed>> GetNewNeed(string id)
        {
            var newNeed = await _context.NewNeeds.FindAsync(id);

            if (newNeed == null)
            {
                return NotFound();
            }

            return newNeed;
        }

        // PUT: api/NewNeeds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewNeed(string id, NewNeed newNeed)
        {
            if (id != newNeed.Nby)
            {
                return BadRequest();
            }

            _context.Entry(newNeed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewNeedExists(id))
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

        // POST: api/NewNeeds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NewNeed>> PostNewNeed(NewNeed newNeed)
        {
            _context.NewNeeds.Add(newNeed);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NewNeedExists(newNeed.Nby))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNewNeed", new { id = newNeed.Nby }, newNeed);
        }

        // DELETE: api/NewNeeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewNeed(string id)
        {
            var newNeed = await _context.NewNeeds.FindAsync(id);
            if (newNeed == null)
            {
                return NotFound();
            }

            _context.NewNeeds.Remove(newNeed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewNeedExists(string id)
        {
            return _context.NewNeeds.Any(e => e.Nby == id);
        }
    }
}

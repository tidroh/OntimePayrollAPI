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
    public class BonusController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public BonusController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Bonus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bonu>>> GetBonus()
        {
            return await _context.Bonus.ToListAsync();
        }

        // GET: api/Bonus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bonu>> GetBonu(decimal? id)
        {
            var bonu = await _context.Bonus.FindAsync(id);

            if (bonu == null)
            {
                return NotFound();
            }

            return bonu;
        }

        // PUT: api/Bonus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBonu(decimal? id, Bonu bonu)
        {
            if (id != bonu.Perc)
            {
                return BadRequest();
            }

            _context.Entry(bonu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BonuExists(id))
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

        // POST: api/Bonus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bonu>> PostBonu(Bonu bonu)
        {
            _context.Bonus.Add(bonu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BonuExists(bonu.Perc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBonu", new { id = bonu.Perc }, bonu);
        }

        // DELETE: api/Bonus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBonu(decimal? id)
        {
            var bonu = await _context.Bonus.FindAsync(id);
            if (bonu == null)
            {
                return NotFound();
            }

            _context.Bonus.Remove(bonu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BonuExists(decimal? id)
        {
            return _context.Bonus.Any(e => e.Perc == id);
        }
    }
}

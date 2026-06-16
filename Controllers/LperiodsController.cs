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
    public class LperiodsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public LperiodsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Lperiods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lperiod>>> GetLperiods()
        {
            return await _context.Lperiods.ToListAsync();
        }

        // GET: api/Lperiods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lperiod>> GetLperiod(decimal? id)
        {
            var lperiod = await _context.Lperiods.FindAsync(id);

            if (lperiod == null)
            {
                return NotFound();
            }

            return lperiod;
        }

        // PUT: api/Lperiods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLperiod(decimal? id, Lperiod lperiod)
        {
            if (id != lperiod.Marks)
            {
                return BadRequest();
            }

            _context.Entry(lperiod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LperiodExists(id))
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

        // POST: api/Lperiods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lperiod>> PostLperiod(Lperiod lperiod)
        {
            _context.Lperiods.Add(lperiod);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LperiodExists(lperiod.Marks))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLperiod", new { id = lperiod.Marks }, lperiod);
        }

        // DELETE: api/Lperiods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLperiod(decimal? id)
        {
            var lperiod = await _context.Lperiods.FindAsync(id);
            if (lperiod == null)
            {
                return NotFound();
            }

            _context.Lperiods.Remove(lperiod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LperiodExists(decimal? id)
        {
            return _context.Lperiods.Any(e => e.Marks == id);
        }
    }
}

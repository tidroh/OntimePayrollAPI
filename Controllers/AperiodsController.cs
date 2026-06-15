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
    public class AperiodsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public AperiodsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Aperiods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aperiod>>> GetAperiods()
        {
            return await _context.Aperiods.ToListAsync();
        }

        // GET: api/Aperiods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aperiod>> GetAperiod(decimal? id)
        {
            var aperiod = await _context.Aperiods.FindAsync(id);

            if (aperiod == null)
            {
                return NotFound();
            }

            return aperiod;
        }

        // PUT: api/Aperiods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAperiod(decimal? id, Aperiod aperiod)
        {
            if (id != aperiod.Marks)
            {
                return BadRequest();
            }

            _context.Entry(aperiod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AperiodExists(id))
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

        // POST: api/Aperiods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aperiod>> PostAperiod(Aperiod aperiod)
        {
            _context.Aperiods.Add(aperiod);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AperiodExists(aperiod.Marks))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAperiod", new { id = aperiod.Marks }, aperiod);
        }

        // DELETE: api/Aperiods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAperiod(decimal? id)
        {
            var aperiod = await _context.Aperiods.FindAsync(id);
            if (aperiod == null)
            {
                return NotFound();
            }

            _context.Aperiods.Remove(aperiod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AperiodExists(decimal? id)
        {
            return _context.Aperiods.Any(e => e.Marks == id);
        }
    }
}

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
    public class TblPeriodsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblPeriodsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblPeriods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPeriod>>> GetTblPeriods()
        {
            return await _context.TblPeriods.ToListAsync();
        }

        // GET: api/TblPeriods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPeriod>> GetTblPeriod(int id)
        {
            var tblPeriod = await _context.TblPeriods.FindAsync(id);

            if (tblPeriod == null)
            {
                return NotFound();
            }

            return tblPeriod;
        }

        // PUT: api/TblPeriods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPeriod(int id, TblPeriod tblPeriod)
        {
            if (id != tblPeriod.PeriodId)
            {
                return BadRequest();
            }

            _context.Entry(tblPeriod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPeriodExists(id))
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

        // POST: api/TblPeriods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPeriod>> PostTblPeriod(TblPeriod tblPeriod)
        {
            _context.TblPeriods.Add(tblPeriod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPeriod", new { id = tblPeriod.PeriodId }, tblPeriod);
        }

        // DELETE: api/TblPeriods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPeriod(int id)
        {
            var tblPeriod = await _context.TblPeriods.FindAsync(id);
            if (tblPeriod == null)
            {
                return NotFound();
            }

            _context.TblPeriods.Remove(tblPeriod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPeriodExists(int id)
        {
            return _context.TblPeriods.Any(e => e.PeriodId == id);
        }
    }
}

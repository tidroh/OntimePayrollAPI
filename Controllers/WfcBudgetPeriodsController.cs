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
    public class WfcBudgetPeriodsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public WfcBudgetPeriodsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/WfcBudgetPeriods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WfcBudgetPeriod>>> GetWfcBudgetPeriods()
        {
            return await _context.WfcBudgetPeriods.ToListAsync();
        }

        // GET: api/WfcBudgetPeriods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WfcBudgetPeriod>> GetWfcBudgetPeriod(long id)
        {
            var wfcBudgetPeriod = await _context.WfcBudgetPeriods.FindAsync(id);

            if (wfcBudgetPeriod == null)
            {
                return NotFound();
            }

            return wfcBudgetPeriod;
        }

        // PUT: api/WfcBudgetPeriods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWfcBudgetPeriod(long id, WfcBudgetPeriod wfcBudgetPeriod)
        {
            if (id != wfcBudgetPeriod.BudgetperiodId)
            {
                return BadRequest();
            }

            _context.Entry(wfcBudgetPeriod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WfcBudgetPeriodExists(id))
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

        // POST: api/WfcBudgetPeriods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WfcBudgetPeriod>> PostWfcBudgetPeriod(WfcBudgetPeriod wfcBudgetPeriod)
        {
            _context.WfcBudgetPeriods.Add(wfcBudgetPeriod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWfcBudgetPeriod", new { id = wfcBudgetPeriod.BudgetperiodId }, wfcBudgetPeriod);
        }

        // DELETE: api/WfcBudgetPeriods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWfcBudgetPeriod(long id)
        {
            var wfcBudgetPeriod = await _context.WfcBudgetPeriods.FindAsync(id);
            if (wfcBudgetPeriod == null)
            {
                return NotFound();
            }

            _context.WfcBudgetPeriods.Remove(wfcBudgetPeriod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WfcBudgetPeriodExists(long id)
        {
            return _context.WfcBudgetPeriods.Any(e => e.BudgetperiodId == id);
        }
    }
}

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
    public class TblPeriodTransactionsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblPeriodTransactionsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblPeriodTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPeriodTransaction>>> GetTblPeriodTransactions()
        {
            return await _context.TblPeriodTransactions.ToListAsync();
        }

        // GET: api/TblPeriodTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPeriodTransaction>> GetTblPeriodTransaction(long id)
        {
            var tblPeriodTransaction = await _context.TblPeriodTransactions.FindAsync(id);

            if (tblPeriodTransaction == null)
            {
                return NotFound();
            }

            return tblPeriodTransaction;
        }

        // PUT: api/TblPeriodTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPeriodTransaction(long id, TblPeriodTransaction tblPeriodTransaction)
        {
            if (id != tblPeriodTransaction.PayslipId)
            {
                return BadRequest();
            }

            _context.Entry(tblPeriodTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPeriodTransactionExists(id))
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

        // POST: api/TblPeriodTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPeriodTransaction>> PostTblPeriodTransaction(TblPeriodTransaction tblPeriodTransaction)
        {
            _context.TblPeriodTransactions.Add(tblPeriodTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPeriodTransaction", new { id = tblPeriodTransaction.PayslipId }, tblPeriodTransaction);
        }

        // DELETE: api/TblPeriodTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPeriodTransaction(long id)
        {
            var tblPeriodTransaction = await _context.TblPeriodTransactions.FindAsync(id);
            if (tblPeriodTransaction == null)
            {
                return NotFound();
            }

            _context.TblPeriodTransactions.Remove(tblPeriodTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPeriodTransactionExists(long id)
        {
            return _context.TblPeriodTransactions.Any(e => e.PayslipId == id);
        }
    }
}

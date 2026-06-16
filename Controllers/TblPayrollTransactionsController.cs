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
    public class TblPayrollTransactionsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblPayrollTransactionsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblPayrollTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPayrollTransaction>>> GetTblPayrollTransactions()
        {
            return await _context.TblPayrollTransactions.ToListAsync();
        }

        // GET: api/TblPayrollTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPayrollTransaction>> GetTblPayrollTransaction(int id)
        {
            var tblPayrollTransaction = await _context.TblPayrollTransactions.FindAsync(id);

            if (tblPayrollTransaction == null)
            {
                return NotFound();
            }

            return tblPayrollTransaction;
        }

        // PUT: api/TblPayrollTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPayrollTransaction(int id, TblPayrollTransaction tblPayrollTransaction)
        {
            if (id != tblPayrollTransaction.PtransactionId)
            {
                return BadRequest();
            }

            _context.Entry(tblPayrollTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPayrollTransactionExists(id))
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

        // POST: api/TblPayrollTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPayrollTransaction>> PostTblPayrollTransaction(TblPayrollTransaction tblPayrollTransaction)
        {
            _context.TblPayrollTransactions.Add(tblPayrollTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPayrollTransaction", new { id = tblPayrollTransaction.PtransactionId }, tblPayrollTransaction);
        }

        // DELETE: api/TblPayrollTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPayrollTransaction(int id)
        {
            var tblPayrollTransaction = await _context.TblPayrollTransactions.FindAsync(id);
            if (tblPayrollTransaction == null)
            {
                return NotFound();
            }

            _context.TblPayrollTransactions.Remove(tblPayrollTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPayrollTransactionExists(int id)
        {
            return _context.TblPayrollTransactions.Any(e => e.PtransactionId == id);
        }
    }
}

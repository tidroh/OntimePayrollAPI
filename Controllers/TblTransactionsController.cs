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
    public class TblTransactionsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblTransactionsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTransaction>>> GetTblTransactions()
        {
            return await _context.TblTransactions.ToListAsync();
        }

        // GET: api/TblTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTransaction>> GetTblTransaction(int id)
        {
            var tblTransaction = await _context.TblTransactions.FindAsync(id);

            if (tblTransaction == null)
            {
                return NotFound();
            }

            return tblTransaction;
        }

        // PUT: api/TblTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTransaction(int id, TblTransaction tblTransaction)
        {
            if (id != tblTransaction.TransId)
            {
                return BadRequest();
            }

            _context.Entry(tblTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTransactionExists(id))
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

        // POST: api/TblTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblTransaction>> PostTblTransaction(TblTransaction tblTransaction)
        {
            _context.TblTransactions.Add(tblTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTransaction", new { id = tblTransaction.TransId }, tblTransaction);
        }

        // DELETE: api/TblTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblTransaction(int id)
        {
            var tblTransaction = await _context.TblTransactions.FindAsync(id);
            if (tblTransaction == null)
            {
                return NotFound();
            }

            _context.TblTransactions.Remove(tblTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblTransactionExists(int id)
        {
            return _context.TblTransactions.Any(e => e.TransId == id);
        }
    }
}

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
    public class TblPeriodCompanyExpensesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblPeriodCompanyExpensesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblPeriodCompanyExpenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPeriodCompanyExpense>>> GetTblPeriodCompanyExpenses()
        {
            return await _context.TblPeriodCompanyExpenses.ToListAsync();
        }

        // GET: api/TblPeriodCompanyExpenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPeriodCompanyExpense>> GetTblPeriodCompanyExpense(int id)
        {
            var tblPeriodCompanyExpense = await _context.TblPeriodCompanyExpenses.FindAsync(id);

            if (tblPeriodCompanyExpense == null)
            {
                return NotFound();
            }

            return tblPeriodCompanyExpense;
        }

        // PUT: api/TblPeriodCompanyExpenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPeriodCompanyExpense(int id, TblPeriodCompanyExpense tblPeriodCompanyExpense)
        {
            if (id != tblPeriodCompanyExpense.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblPeriodCompanyExpense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPeriodCompanyExpenseExists(id))
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

        // POST: api/TblPeriodCompanyExpenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPeriodCompanyExpense>> PostTblPeriodCompanyExpense(TblPeriodCompanyExpense tblPeriodCompanyExpense)
        {
            _context.TblPeriodCompanyExpenses.Add(tblPeriodCompanyExpense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPeriodCompanyExpense", new { id = tblPeriodCompanyExpense.Id }, tblPeriodCompanyExpense);
        }

        // DELETE: api/TblPeriodCompanyExpenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPeriodCompanyExpense(int id)
        {
            var tblPeriodCompanyExpense = await _context.TblPeriodCompanyExpenses.FindAsync(id);
            if (tblPeriodCompanyExpense == null)
            {
                return NotFound();
            }

            _context.TblPeriodCompanyExpenses.Remove(tblPeriodCompanyExpense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPeriodCompanyExpenseExists(int id)
        {
            return _context.TblPeriodCompanyExpenses.Any(e => e.Id == id);
        }
    }
}

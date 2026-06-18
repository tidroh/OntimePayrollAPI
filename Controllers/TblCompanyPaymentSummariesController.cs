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
    public class TblCompanyPaymentSummariesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblCompanyPaymentSummariesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblCompanyPaymentSummaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCompanyPaymentSummary>>> GetTblCompanyPaymentSummaries()
        {
            return await _context.TblCompanyPaymentSummaries.ToListAsync();
        }

        // GET: api/TblCompanyPaymentSummaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCompanyPaymentSummary>> GetTblCompanyPaymentSummary(decimal id)
        {
            var tblCompanyPaymentSummary = await _context.TblCompanyPaymentSummaries.FindAsync(id);

            if (tblCompanyPaymentSummary == null)
            {
                return NotFound();
            }

            return tblCompanyPaymentSummary;
        }

        // PUT: api/TblCompanyPaymentSummaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCompanyPaymentSummary(decimal id, TblCompanyPaymentSummary tblCompanyPaymentSummary)
        {
            if (id != tblCompanyPaymentSummary.BankNumbers)
            {
                return BadRequest();
            }

            _context.Entry(tblCompanyPaymentSummary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCompanyPaymentSummaryExists(id))
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

        // POST: api/TblCompanyPaymentSummaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCompanyPaymentSummary>> PostTblCompanyPaymentSummary(TblCompanyPaymentSummary tblCompanyPaymentSummary)
        {
            _context.TblCompanyPaymentSummaries.Add(tblCompanyPaymentSummary);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblCompanyPaymentSummaryExists(tblCompanyPaymentSummary.BankNumbers))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblCompanyPaymentSummary", new { id = tblCompanyPaymentSummary.BankNumbers }, tblCompanyPaymentSummary);
        }

        // DELETE: api/TblCompanyPaymentSummaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCompanyPaymentSummary(decimal id)
        {
            var tblCompanyPaymentSummary = await _context.TblCompanyPaymentSummaries.FindAsync(id);
            if (tblCompanyPaymentSummary == null)
            {
                return NotFound();
            }

            _context.TblCompanyPaymentSummaries.Remove(tblCompanyPaymentSummary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCompanyPaymentSummaryExists(decimal id)
        {
            return _context.TblCompanyPaymentSummaries.Any(e => e.BankNumbers == id);
        }
    }
}

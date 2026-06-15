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
    public class BankDetailsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public BankDetailsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/BankDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankDetail>>> GetBankDetails()
        {
            return await _context.BankDetails.ToListAsync();
        }

        // GET: api/BankDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankDetail>> GetBankDetail(string id)
        {
            var bankDetail = await _context.BankDetails.FindAsync(id);

            if (bankDetail == null)
            {
                return NotFound();
            }

            return bankDetail;
        }

        // PUT: api/BankDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankDetail(string id, BankDetail bankDetail)
        {
            if (id != bankDetail.Code)
            {
                return BadRequest();
            }

            _context.Entry(bankDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankDetailExists(id))
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

        // POST: api/BankDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BankDetail>> PostBankDetail(BankDetail bankDetail)
        {
            _context.BankDetails.Add(bankDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BankDetailExists(bankDetail.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBankDetail", new { id = bankDetail.Code }, bankDetail);
        }

        // DELETE: api/BankDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankDetail(string id)
        {
            var bankDetail = await _context.BankDetails.FindAsync(id);
            if (bankDetail == null)
            {
                return NotFound();
            }

            _context.BankDetails.Remove(bankDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BankDetailExists(string id)
        {
            return _context.BankDetails.Any(e => e.Code == id);
        }
    }
}

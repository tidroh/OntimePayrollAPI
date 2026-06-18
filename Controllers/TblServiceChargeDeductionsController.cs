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
    public class TblServiceChargeDeductionsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblServiceChargeDeductionsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblServiceChargeDeductions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblServiceChargeDeduction>>> GetTblServiceChargeDeductions()
        {
            return await _context.TblServiceChargeDeductions.ToListAsync();
        }

        // GET: api/TblServiceChargeDeductions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblServiceChargeDeduction>> GetTblServiceChargeDeduction(int id)
        {
            var tblServiceChargeDeduction = await _context.TblServiceChargeDeductions.FindAsync(id);

            if (tblServiceChargeDeduction == null)
            {
                return NotFound();
            }

            return tblServiceChargeDeduction;
        }

        // PUT: api/TblServiceChargeDeductions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblServiceChargeDeduction(int id, TblServiceChargeDeduction tblServiceChargeDeduction)
        {
            if (id != tblServiceChargeDeduction.ServicechargeId)
            {
                return BadRequest();
            }

            _context.Entry(tblServiceChargeDeduction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblServiceChargeDeductionExists(id))
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

        // POST: api/TblServiceChargeDeductions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblServiceChargeDeduction>> PostTblServiceChargeDeduction(TblServiceChargeDeduction tblServiceChargeDeduction)
        {
            _context.TblServiceChargeDeductions.Add(tblServiceChargeDeduction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblServiceChargeDeduction", new { id = tblServiceChargeDeduction.ServicechargeId }, tblServiceChargeDeduction);
        }

        // DELETE: api/TblServiceChargeDeductions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblServiceChargeDeduction(int id)
        {
            var tblServiceChargeDeduction = await _context.TblServiceChargeDeductions.FindAsync(id);
            if (tblServiceChargeDeduction == null)
            {
                return NotFound();
            }

            _context.TblServiceChargeDeductions.Remove(tblServiceChargeDeduction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblServiceChargeDeductionExists(int id)
        {
            return _context.TblServiceChargeDeductions.Any(e => e.ServicechargeId == id);
        }
    }
}

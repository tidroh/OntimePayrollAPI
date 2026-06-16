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
    public class TblServiceChargesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblServiceChargesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblServiceCharges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblServiceCharge>>> GetTblServiceCharges()
        {
            return await _context.TblServiceCharges.ToListAsync();
        }

        // GET: api/TblServiceCharges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblServiceCharge>> GetTblServiceCharge(int id)
        {
            var tblServiceCharge = await _context.TblServiceCharges.FindAsync(id);

            if (tblServiceCharge == null)
            {
                return NotFound();
            }

            return tblServiceCharge;
        }

        // PUT: api/TblServiceCharges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblServiceCharge(int id, TblServiceCharge tblServiceCharge)
        {
            if (id != tblServiceCharge.ServiceId)
            {
                return BadRequest();
            }

            _context.Entry(tblServiceCharge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblServiceChargeExists(id))
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

        // POST: api/TblServiceCharges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblServiceCharge>> PostTblServiceCharge(TblServiceCharge tblServiceCharge)
        {
            _context.TblServiceCharges.Add(tblServiceCharge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblServiceCharge", new { id = tblServiceCharge.ServiceId }, tblServiceCharge);
        }

        // DELETE: api/TblServiceCharges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblServiceCharge(int id)
        {
            var tblServiceCharge = await _context.TblServiceCharges.FindAsync(id);
            if (tblServiceCharge == null)
            {
                return NotFound();
            }

            _context.TblServiceCharges.Remove(tblServiceCharge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblServiceChargeExists(int id)
        {
            return _context.TblServiceCharges.Any(e => e.ServiceId == id);
        }
    }
}

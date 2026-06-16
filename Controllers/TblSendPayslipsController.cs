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
    public class TblSendPayslipsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblSendPayslipsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblSendPayslips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSendPayslip>>> GetTblSendPayslips()
        {
            return await _context.TblSendPayslips.ToListAsync();
        }

        // GET: api/TblSendPayslips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSendPayslip>> GetTblSendPayslip(DateTime? id)
        {
            var tblSendPayslip = await _context.TblSendPayslips.FindAsync(id);

            if (tblSendPayslip == null)
            {
                return NotFound();
            }

            return tblSendPayslip;
        }

        // PUT: api/TblSendPayslips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSendPayslip(DateTime? id, TblSendPayslip tblSendPayslip)
        {
            if (id != tblSendPayslip.CreatedOn)
            {
                return BadRequest();
            }

            _context.Entry(tblSendPayslip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSendPayslipExists(id))
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

        // POST: api/TblSendPayslips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblSendPayslip>> PostTblSendPayslip(TblSendPayslip tblSendPayslip)
        {
            _context.TblSendPayslips.Add(tblSendPayslip);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblSendPayslipExists(tblSendPayslip.CreatedOn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblSendPayslip", new { id = tblSendPayslip.CreatedOn }, tblSendPayslip);
        }

        // DELETE: api/TblSendPayslips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSendPayslip(DateTime? id)
        {
            var tblSendPayslip = await _context.TblSendPayslips.FindAsync(id);
            if (tblSendPayslip == null)
            {
                return NotFound();
            }

            _context.TblSendPayslips.Remove(tblSendPayslip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblSendPayslipExists(DateTime? id)
        {
            return _context.TblSendPayslips.Any(e => e.CreatedOn == id);
        }
    }
}

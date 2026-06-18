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
    public class TblPayslipsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblPayslipsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblPayslips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPayslip>>> GetTblPayslips()
        {
            return await _context.TblPayslips.ToListAsync();
        }

        // GET: api/TblPayslips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPayslip>> GetTblPayslip(int id)
        {
            var tblPayslip = await _context.TblPayslips.FindAsync(id);

            if (tblPayslip == null)
            {
                return NotFound();
            }

            return tblPayslip;
        }

        // PUT: api/TblPayslips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPayslip(int id, TblPayslip tblPayslip)
        {
            if (id != tblPayslip.PayslipId)
            {
                return BadRequest();
            }

            _context.Entry(tblPayslip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPayslipExists(id))
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

        // POST: api/TblPayslips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPayslip>> PostTblPayslip(TblPayslip tblPayslip)
        {
            _context.TblPayslips.Add(tblPayslip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPayslip", new { id = tblPayslip.PayslipId }, tblPayslip);
        }

        // DELETE: api/TblPayslips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPayslip(int id)
        {
            var tblPayslip = await _context.TblPayslips.FindAsync(id);
            if (tblPayslip == null)
            {
                return NotFound();
            }

            _context.TblPayslips.Remove(tblPayslip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPayslipExists(int id)
        {
            return _context.TblPayslips.Any(e => e.PayslipId == id);
        }
    }
}

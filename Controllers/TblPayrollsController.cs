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
    public class TblPayrollsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblPayrollsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblPayrolls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPayroll>>> GetTblPayrolls()
        {
            return await _context.TblPayrolls.ToListAsync();
        }

        // GET: api/TblPayrolls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPayroll>> GetTblPayroll(int id)
        {
            var tblPayroll = await _context.TblPayrolls.FindAsync(id);

            if (tblPayroll == null)
            {
                return NotFound();
            }

            return tblPayroll;
        }

        // PUT: api/TblPayrolls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPayroll(int id, TblPayroll tblPayroll)
        {
            if (id != tblPayroll.PayrollId)
            {
                return BadRequest();
            }

            _context.Entry(tblPayroll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPayrollExists(id))
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

        // POST: api/TblPayrolls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPayroll>> PostTblPayroll(TblPayroll tblPayroll)
        {
            _context.TblPayrolls.Add(tblPayroll);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPayroll", new { id = tblPayroll.PayrollId }, tblPayroll);
        }

        // DELETE: api/TblPayrolls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPayroll(int id)
        {
            var tblPayroll = await _context.TblPayrolls.FindAsync(id);
            if (tblPayroll == null)
            {
                return NotFound();
            }

            _context.TblPayrolls.Remove(tblPayroll);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPayrollExists(int id)
        {
            return _context.TblPayrolls.Any(e => e.PayrollId == id);
        }
    }
}

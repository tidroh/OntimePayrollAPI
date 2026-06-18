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
    public class TblVarTrsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblVarTrsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblVarTrs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblVarTr>>> GetTblVarTrs()
        {
            return await _context.TblVarTrs.ToListAsync();
        }

        // GET: api/TblVarTrs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblVarTr>> GetTblVarTr(long id)
        {
            var tblVarTr = await _context.TblVarTrs.FindAsync(id);

            if (tblVarTr == null)
            {
                return NotFound();
            }

            return tblVarTr;
        }

        // PUT: api/TblVarTrs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblVarTr(long id, TblVarTr tblVarTr)
        {
            if (id != tblVarTr.PayslipId)
            {
                return BadRequest();
            }

            _context.Entry(tblVarTr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblVarTrExists(id))
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

        // POST: api/TblVarTrs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblVarTr>> PostTblVarTr(TblVarTr tblVarTr)
        {
            _context.TblVarTrs.Add(tblVarTr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblVarTr", new { id = tblVarTr.PayslipId }, tblVarTr);
        }

        // DELETE: api/TblVarTrs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblVarTr(long id)
        {
            var tblVarTr = await _context.TblVarTrs.FindAsync(id);
            if (tblVarTr == null)
            {
                return NotFound();
            }

            _context.TblVarTrs.Remove(tblVarTr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblVarTrExists(long id)
        {
            return _context.TblVarTrs.Any(e => e.PayslipId == id);
        }
    }
}

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
    public class TblTimeSheetsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblTimeSheetsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblTimeSheets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTimeSheet>>> GetTblTimeSheets()
        {
            return await _context.TblTimeSheets.ToListAsync();
        }

        // GET: api/TblTimeSheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTimeSheet>> GetTblTimeSheet(int id)
        {
            var tblTimeSheet = await _context.TblTimeSheets.FindAsync(id);

            if (tblTimeSheet == null)
            {
                return NotFound();
            }

            return tblTimeSheet;
        }

        // PUT: api/TblTimeSheets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTimeSheet(int id, TblTimeSheet tblTimeSheet)
        {
            if (id != tblTimeSheet.TimesheetId)
            {
                return BadRequest();
            }

            _context.Entry(tblTimeSheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTimeSheetExists(id))
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

        // POST: api/TblTimeSheets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblTimeSheet>> PostTblTimeSheet(TblTimeSheet tblTimeSheet)
        {
            _context.TblTimeSheets.Add(tblTimeSheet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTimeSheet", new { id = tblTimeSheet.TimesheetId }, tblTimeSheet);
        }

        // DELETE: api/TblTimeSheets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblTimeSheet(int id)
        {
            var tblTimeSheet = await _context.TblTimeSheets.FindAsync(id);
            if (tblTimeSheet == null)
            {
                return NotFound();
            }

            _context.TblTimeSheets.Remove(tblTimeSheet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblTimeSheetExists(int id)
        {
            return _context.TblTimeSheets.Any(e => e.TimesheetId == id);
        }
    }
}

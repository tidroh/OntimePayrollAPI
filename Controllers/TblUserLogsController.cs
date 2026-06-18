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
    public class TblUserLogsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblUserLogsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblUserLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUserLog>>> GetTblUserLogs()
        {
            return await _context.TblUserLogs.ToListAsync();
        }

        // GET: api/TblUserLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUserLog>> GetTblUserLog(int id)
        {
            var tblUserLog = await _context.TblUserLogs.FindAsync(id);

            if (tblUserLog == null)
            {
                return NotFound();
            }

            return tblUserLog;
        }

        // PUT: api/TblUserLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUserLog(int id, TblUserLog tblUserLog)
        {
            if (id != tblUserLog.LogId)
            {
                return BadRequest();
            }

            _context.Entry(tblUserLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserLogExists(id))
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

        // POST: api/TblUserLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblUserLog>> PostTblUserLog(TblUserLog tblUserLog)
        {
            _context.TblUserLogs.Add(tblUserLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUserLog", new { id = tblUserLog.LogId }, tblUserLog);
        }

        // DELETE: api/TblUserLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblUserLog(int id)
        {
            var tblUserLog = await _context.TblUserLogs.FindAsync(id);
            if (tblUserLog == null)
            {
                return NotFound();
            }

            _context.TblUserLogs.Remove(tblUserLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblUserLogExists(int id)
        {
            return _context.TblUserLogs.Any(e => e.LogId == id);
        }
    }
}

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
    public class TblStatementCodesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblStatementCodesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblStatementCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblStatementCode>>> GetTblStatementCodes()
        {
            return await _context.TblStatementCodes.ToListAsync();
        }

        // GET: api/TblStatementCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblStatementCode>> GetTblStatementCode(int id)
        {
            var tblStatementCode = await _context.TblStatementCodes.FindAsync(id);

            if (tblStatementCode == null)
            {
                return NotFound();
            }

            return tblStatementCode;
        }

        // PUT: api/TblStatementCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblStatementCode(int id, TblStatementCode tblStatementCode)
        {
            if (id != tblStatementCode.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblStatementCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblStatementCodeExists(id))
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

        // POST: api/TblStatementCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblStatementCode>> PostTblStatementCode(TblStatementCode tblStatementCode)
        {
            _context.TblStatementCodes.Add(tblStatementCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblStatementCode", new { id = tblStatementCode.Id }, tblStatementCode);
        }

        // DELETE: api/TblStatementCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblStatementCode(int id)
        {
            var tblStatementCode = await _context.TblStatementCodes.FindAsync(id);
            if (tblStatementCode == null)
            {
                return NotFound();
            }

            _context.TblStatementCodes.Remove(tblStatementCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblStatementCodeExists(int id)
        {
            return _context.TblStatementCodes.Any(e => e.Id == id);
        }
    }
}

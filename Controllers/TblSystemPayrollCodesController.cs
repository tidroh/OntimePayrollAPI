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
    public class TblSystemPayrollCodesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblSystemPayrollCodesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblSystemPayrollCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSystemPayrollCode>>> GetTblSystemPayrollCodes()
        {
            return await _context.TblSystemPayrollCodes.ToListAsync();
        }

        // GET: api/TblSystemPayrollCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSystemPayrollCode>> GetTblSystemPayrollCode(int id)
        {
            var tblSystemPayrollCode = await _context.TblSystemPayrollCodes.FindAsync(id);

            if (tblSystemPayrollCode == null)
            {
                return NotFound();
            }

            return tblSystemPayrollCode;
        }

        // PUT: api/TblSystemPayrollCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSystemPayrollCode(int id, TblSystemPayrollCode tblSystemPayrollCode)
        {
            if (id != tblSystemPayrollCode.SystemCodeId)
            {
                return BadRequest();
            }

            _context.Entry(tblSystemPayrollCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSystemPayrollCodeExists(id))
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

        // POST: api/TblSystemPayrollCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblSystemPayrollCode>> PostTblSystemPayrollCode(TblSystemPayrollCode tblSystemPayrollCode)
        {
            _context.TblSystemPayrollCodes.Add(tblSystemPayrollCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblSystemPayrollCode", new { id = tblSystemPayrollCode.SystemCodeId }, tblSystemPayrollCode);
        }

        // DELETE: api/TblSystemPayrollCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSystemPayrollCode(int id)
        {
            var tblSystemPayrollCode = await _context.TblSystemPayrollCodes.FindAsync(id);
            if (tblSystemPayrollCode == null)
            {
                return NotFound();
            }

            _context.TblSystemPayrollCodes.Remove(tblSystemPayrollCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblSystemPayrollCodeExists(int id)
        {
            return _context.TblSystemPayrollCodes.Any(e => e.SystemCodeId == id);
        }
    }
}

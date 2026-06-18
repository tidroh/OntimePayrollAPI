using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

namespace OntimePayrollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblPayrollCodesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblPayrollCodesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // 1. GET: api/TblPayrollCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPayrollCode>>> GetTblPayrollCodes()
        {
            return await _context.TblPayrollCodes.ToListAsync();
        }

        // 2. GET: api/TblPayrollCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPayrollCode>> GetTblPayrollCode(int id)
        {
            var tblPayrollCode = await _context.TblPayrollCodes.FindAsync(id);

            if (tblPayrollCode == null)
            {
                return NotFound();
            }

            return tblPayrollCode;
        }

        // 3. POST: api/TblPayrollCodes
        [HttpPost]
        public async Task<ActionResult<TblPayrollCode>> PostTblPayrollCode(TblPayrollCode tblPayrollCode)
        {
            _context.TblPayrollCodes.Add(tblPayrollCode);
            await _context.SaveChangesAsync();

            // FIXED: Changed PayrollCodeId to PayrollId
            return CreatedAtAction(nameof(GetTblPayrollCode), new { id = tblPayrollCode.PayrollcodeId }, tblPayrollCode);
        }

        // 4. PUT: api/TblPayrollCodes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPayrollCode(int id, TblPayrollCode tblPayrollCode)
        {
            // FIXED: Changed PayrollCodeId to PayrollId
            if (id != tblPayrollCode.PayrollcodeId)
            {
                return BadRequest("ID in URL path does not match ID in request body.");
            }

            _context.Entry(tblPayrollCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPayrollCodeExists(id))
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

        // 5. DELETE: api/TblPayrollCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPayrollCode(int id)
        {
            var tblPayrollCode = await _context.TblPayrollCodes.FindAsync(id);
            if (tblPayrollCode == null)
            {
                return NotFound();
            }

            _context.TblPayrollCodes.Remove(tblPayrollCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPayrollCodeExists(int id)
        {
            // FIXED: Changed PayrollCodeId to PayrollId
            return _context.TblPayrollCodes.Any(e => e.PayrollcodeId == id);
        }
    }
}
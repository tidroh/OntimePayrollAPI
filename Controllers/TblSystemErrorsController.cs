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
    public class TblSystemErrorsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblSystemErrorsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblSystemErrors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSystemError>>> GetTblSystemErrors()
        {
            return await _context.TblSystemErrors.ToListAsync();
        }

        // GET: api/TblSystemErrors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSystemError>> GetTblSystemError(int id)
        {
            var tblSystemError = await _context.TblSystemErrors.FindAsync(id);

            if (tblSystemError == null)
            {
                return NotFound();
            }

            return tblSystemError;
        }

        // PUT: api/TblSystemErrors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSystemError(int id, TblSystemError tblSystemError)
        {
            if (id != tblSystemError.ErrorId)
            {
                return BadRequest();
            }

            _context.Entry(tblSystemError).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSystemErrorExists(id))
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

        // POST: api/TblSystemErrors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblSystemError>> PostTblSystemError(TblSystemError tblSystemError)
        {
            _context.TblSystemErrors.Add(tblSystemError);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblSystemError", new { id = tblSystemError.ErrorId }, tblSystemError);
        }

        // DELETE: api/TblSystemErrors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSystemError(int id)
        {
            var tblSystemError = await _context.TblSystemErrors.FindAsync(id);
            if (tblSystemError == null)
            {
                return NotFound();
            }

            _context.TblSystemErrors.Remove(tblSystemError);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblSystemErrorExists(int id)
        {
            return _context.TblSystemErrors.Any(e => e.ErrorId == id);
        }
    }
}

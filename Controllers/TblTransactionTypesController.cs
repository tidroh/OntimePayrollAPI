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
    public class TblTransactionTypesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblTransactionTypesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblTransactionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTransactionType>>> GetTblTransactionTypes()
        {
            return await _context.TblTransactionTypes.ToListAsync();
        }

        // GET: api/TblTransactionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTransactionType>> GetTblTransactionType(int id)
        {
            var tblTransactionType = await _context.TblTransactionTypes.FindAsync(id);

            if (tblTransactionType == null)
            {
                return NotFound();
            }

            return tblTransactionType;
        }

        // PUT: api/TblTransactionTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTransactionType(int id, TblTransactionType tblTransactionType)
        {
            if (id != tblTransactionType.TtypeId)
            {
                return BadRequest();
            }

            _context.Entry(tblTransactionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTransactionTypeExists(id))
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

        // POST: api/TblTransactionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblTransactionType>> PostTblTransactionType(TblTransactionType tblTransactionType)
        {
            _context.TblTransactionTypes.Add(tblTransactionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTransactionType", new { id = tblTransactionType.TtypeId }, tblTransactionType);
        }

        // DELETE: api/TblTransactionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblTransactionType(int id)
        {
            var tblTransactionType = await _context.TblTransactionTypes.FindAsync(id);
            if (tblTransactionType == null)
            {
                return NotFound();
            }

            _context.TblTransactionTypes.Remove(tblTransactionType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblTransactionTypeExists(int id)
        {
            return _context.TblTransactionTypes.Any(e => e.TtypeId == id);
        }
    }
}

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
    public class TblServantsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblServantsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblServants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblServant>>> GetTblServants()
        {
            return await _context.TblServants.ToListAsync();
        }

        // GET: api/TblServants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblServant>> GetTblServant(long id)
        {
            var tblServant = await _context.TblServants.FindAsync(id);

            if (tblServant == null)
            {
                return NotFound();
            }

            return tblServant;
        }

        // PUT: api/TblServants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblServant(long id, TblServant tblServant)
        {
            if (id != tblServant.ServantsId)
            {
                return BadRequest();
            }

            _context.Entry(tblServant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblServantExists(id))
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

        // POST: api/TblServants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblServant>> PostTblServant(TblServant tblServant)
        {
            _context.TblServants.Add(tblServant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblServant", new { id = tblServant.ServantsId }, tblServant);
        }

        // DELETE: api/TblServants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblServant(long id)
        {
            var tblServant = await _context.TblServants.FindAsync(id);
            if (tblServant == null)
            {
                return NotFound();
            }

            _context.TblServants.Remove(tblServant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblServantExists(long id)
        {
            return _context.TblServants.Any(e => e.ServantsId == id);
        }
    }
}

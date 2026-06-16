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
    public class TblRemunerationsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblRemunerationsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblRemunerations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblRemuneration>>> GetTblRemunerations()
        {
            return await _context.TblRemunerations.ToListAsync();
        }

        // GET: api/TblRemunerations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblRemuneration>> GetTblRemuneration(int id)
        {
            var tblRemuneration = await _context.TblRemunerations.FindAsync(id);

            if (tblRemuneration == null)
            {
                return NotFound();
            }

            return tblRemuneration;
        }

        // PUT: api/TblRemunerations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblRemuneration(int id, TblRemuneration tblRemuneration)
        {
            if (id != tblRemuneration.RemunerationId)
            {
                return BadRequest();
            }

            _context.Entry(tblRemuneration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblRemunerationExists(id))
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

        // POST: api/TblRemunerations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblRemuneration>> PostTblRemuneration(TblRemuneration tblRemuneration)
        {
            _context.TblRemunerations.Add(tblRemuneration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblRemuneration", new { id = tblRemuneration.RemunerationId }, tblRemuneration);
        }

        // DELETE: api/TblRemunerations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblRemuneration(int id)
        {
            var tblRemuneration = await _context.TblRemunerations.FindAsync(id);
            if (tblRemuneration == null)
            {
                return NotFound();
            }

            _context.TblRemunerations.Remove(tblRemuneration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblRemunerationExists(int id)
        {
            return _context.TblRemunerations.Any(e => e.RemunerationId == id);
        }
    }
}

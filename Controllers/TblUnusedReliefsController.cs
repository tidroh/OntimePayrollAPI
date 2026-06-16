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
    public class TblUnusedReliefsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblUnusedReliefsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblUnusedReliefs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUnusedRelief>>> GetTblUnusedReliefs()
        {
            return await _context.TblUnusedReliefs.ToListAsync();
        }

        // GET: api/TblUnusedReliefs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUnusedRelief>> GetTblUnusedRelief(int id)
        {
            var tblUnusedRelief = await _context.TblUnusedReliefs.FindAsync(id);

            if (tblUnusedRelief == null)
            {
                return NotFound();
            }

            return tblUnusedRelief;
        }

        // PUT: api/TblUnusedReliefs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUnusedRelief(int id, TblUnusedRelief tblUnusedRelief)
        {
            if (id != tblUnusedRelief.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblUnusedRelief).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUnusedReliefExists(id))
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

        // POST: api/TblUnusedReliefs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblUnusedRelief>> PostTblUnusedRelief(TblUnusedRelief tblUnusedRelief)
        {
            _context.TblUnusedReliefs.Add(tblUnusedRelief);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUnusedRelief", new { id = tblUnusedRelief.Id }, tblUnusedRelief);
        }

        // DELETE: api/TblUnusedReliefs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblUnusedRelief(int id)
        {
            var tblUnusedRelief = await _context.TblUnusedReliefs.FindAsync(id);
            if (tblUnusedRelief == null)
            {
                return NotFound();
            }

            _context.TblUnusedReliefs.Remove(tblUnusedRelief);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblUnusedReliefExists(int id)
        {
            return _context.TblUnusedReliefs.Any(e => e.Id == id);
        }
    }
}

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
    public class TblReliefsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblReliefsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblReliefs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblRelief>>> GetTblReliefs()
        {
            return await _context.TblReliefs.ToListAsync();
        }

        // GET: api/TblReliefs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblRelief>> GetTblRelief(int id)
        {
            var tblRelief = await _context.TblReliefs.FindAsync(id);

            if (tblRelief == null)
            {
                return NotFound();
            }

            return tblRelief;
        }

        // PUT: api/TblReliefs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblRelief(int id, TblRelief tblRelief)
        {
            if (id != tblRelief.ReliefId)
            {
                return BadRequest();
            }

            _context.Entry(tblRelief).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblReliefExists(id))
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

        // POST: api/TblReliefs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblRelief>> PostTblRelief(TblRelief tblRelief)
        {
            _context.TblReliefs.Add(tblRelief);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblRelief", new { id = tblRelief.ReliefId }, tblRelief);
        }

        // DELETE: api/TblReliefs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblRelief(int id)
        {
            var tblRelief = await _context.TblReliefs.FindAsync(id);
            if (tblRelief == null)
            {
                return NotFound();
            }

            _context.TblReliefs.Remove(tblRelief);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblReliefExists(int id)
        {
            return _context.TblReliefs.Any(e => e.ReliefId == id);
        }
    }
}

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
    public class TblProtimesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblProtimesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblProtimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProtime>>> GetTblProtimes()
        {
            return await _context.TblProtimes.ToListAsync();
        }

        // GET: api/TblProtimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblProtime>> GetTblProtime(int id)
        {
            var tblProtime = await _context.TblProtimes.FindAsync(id);

            if (tblProtime == null)
            {
                return NotFound();
            }

            return tblProtime;
        }

        // PUT: api/TblProtimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProtime(int id, TblProtime tblProtime)
        {
            if (id != tblProtime.Protimeid)
            {
                return BadRequest();
            }

            _context.Entry(tblProtime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProtimeExists(id))
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

        // POST: api/TblProtimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblProtime>> PostTblProtime(TblProtime tblProtime)
        {
            _context.TblProtimes.Add(tblProtime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblProtime", new { id = tblProtime.Protimeid }, tblProtime);
        }

        // DELETE: api/TblProtimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblProtime(int id)
        {
            var tblProtime = await _context.TblProtimes.FindAsync(id);
            if (tblProtime == null)
            {
                return NotFound();
            }

            _context.TblProtimes.Remove(tblProtime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblProtimeExists(int id)
        {
            return _context.TblProtimes.Any(e => e.Protimeid == id);
        }
    }
}

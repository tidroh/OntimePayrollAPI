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
    public class TblUser1Controller : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblUser1Controller(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblUser1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUser1>>> GetTblUser1s()
        {
            return await _context.TblUser1s.ToListAsync();
        }

        // GET: api/TblUser1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUser1>> GetTblUser1(int id)
        {
            var tblUser1 = await _context.TblUser1s.FindAsync(id);

            if (tblUser1 == null)
            {
                return NotFound();
            }

            return tblUser1;
        }

        // PUT: api/TblUser1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUser1(int id, TblUser1 tblUser1)
        {
            if (id != tblUser1.UserId)
            {
                return BadRequest();
            }

            _context.Entry(tblUser1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUser1Exists(id))
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

        // POST: api/TblUser1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblUser1>> PostTblUser1(TblUser1 tblUser1)
        {
            _context.TblUser1s.Add(tblUser1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUser1", new { id = tblUser1.UserId }, tblUser1);
        }

        // DELETE: api/TblUser1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblUser1(int id)
        {
            var tblUser1 = await _context.TblUser1s.FindAsync(id);
            if (tblUser1 == null)
            {
                return NotFound();
            }

            _context.TblUser1s.Remove(tblUser1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblUser1Exists(int id)
        {
            return _context.TblUser1s.Any(e => e.UserId == id);
        }
    }
}

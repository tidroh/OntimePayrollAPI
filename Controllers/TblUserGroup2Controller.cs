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
    public class TblUserGroup2Controller : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblUserGroup2Controller(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblUserGroup2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUserGroup2>>> GetTblUserGroup2s()
        {
            return await _context.TblUserGroup2s.ToListAsync();
        }

        // GET: api/TblUserGroup2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUserGroup2>> GetTblUserGroup2(string id)
        {
            var tblUserGroup2 = await _context.TblUserGroup2s.FindAsync(id);

            if (tblUserGroup2 == null)
            {
                return NotFound();
            }

            return tblUserGroup2;
        }

        // PUT: api/TblUserGroup2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUserGroup2(string id, TblUserGroup2 tblUserGroup2)
        {
            if (id != tblUserGroup2.GroupCode)
            {
                return BadRequest();
            }

            _context.Entry(tblUserGroup2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserGroup2Exists(id))
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

        // POST: api/TblUserGroup2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblUserGroup2>> PostTblUserGroup2(TblUserGroup2 tblUserGroup2)
        {
            _context.TblUserGroup2s.Add(tblUserGroup2);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblUserGroup2Exists(tblUserGroup2.GroupCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblUserGroup2", new { id = tblUserGroup2.GroupCode }, tblUserGroup2);
        }

        // DELETE: api/TblUserGroup2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblUserGroup2(string id)
        {
            var tblUserGroup2 = await _context.TblUserGroup2s.FindAsync(id);
            if (tblUserGroup2 == null)
            {
                return NotFound();
            }

            _context.TblUserGroup2s.Remove(tblUserGroup2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblUserGroup2Exists(string id)
        {
            return _context.TblUserGroup2s.Any(e => e.GroupCode == id);
        }
    }
}

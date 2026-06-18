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
    public class TblUserGroup1Controller : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblUserGroup1Controller(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblUserGroup1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUserGroup1>>> GetTblUserGroup1s()
        {
            return await _context.TblUserGroup1s.ToListAsync();
        }

        // GET: api/TblUserGroup1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUserGroup1>> GetTblUserGroup1(int id)
        {
            var tblUserGroup1 = await _context.TblUserGroup1s.FindAsync(id);

            if (tblUserGroup1 == null)
            {
                return NotFound();
            }

            return tblUserGroup1;
        }

        // PUT: api/TblUserGroup1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUserGroup1(int id, TblUserGroup1 tblUserGroup1)
        {
            if (id != tblUserGroup1.GroupId)
            {
                return BadRequest();
            }

            _context.Entry(tblUserGroup1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserGroup1Exists(id))
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

        // POST: api/TblUserGroup1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblUserGroup1>> PostTblUserGroup1(TblUserGroup1 tblUserGroup1)
        {
            _context.TblUserGroup1s.Add(tblUserGroup1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUserGroup1", new { id = tblUserGroup1.GroupId }, tblUserGroup1);
        }

        // DELETE: api/TblUserGroup1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblUserGroup1(int id)
        {
            var tblUserGroup1 = await _context.TblUserGroup1s.FindAsync(id);
            if (tblUserGroup1 == null)
            {
                return NotFound();
            }

            _context.TblUserGroup1s.Remove(tblUserGroup1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblUserGroup1Exists(int id)
        {
            return _context.TblUserGroup1s.Any(e => e.GroupId == id);
        }
    }
}

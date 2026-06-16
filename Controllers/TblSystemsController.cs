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
    public class TblSystemsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblSystemsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblSystems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSystem>>> GetTblSystems()
        {
            return await _context.TblSystems.ToListAsync();
        }

        // GET: api/TblSystems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSystem>> GetTblSystem(int id)
        {
            var tblSystem = await _context.TblSystems.FindAsync(id);

            if (tblSystem == null)
            {
                return NotFound();
            }

            return tblSystem;
        }

        // PUT: api/TblSystems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSystem(int id, TblSystem tblSystem)
        {
            if (id != tblSystem.SystemId)
            {
                return BadRequest();
            }

            _context.Entry(tblSystem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSystemExists(id))
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

        // POST: api/TblSystems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblSystem>> PostTblSystem(TblSystem tblSystem)
        {
            _context.TblSystems.Add(tblSystem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblSystem", new { id = tblSystem.SystemId }, tblSystem);
        }

        // DELETE: api/TblSystems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSystem(int id)
        {
            var tblSystem = await _context.TblSystems.FindAsync(id);
            if (tblSystem == null)
            {
                return NotFound();
            }

            _context.TblSystems.Remove(tblSystem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblSystemExists(int id)
        {
            return _context.TblSystems.Any(e => e.SystemId == id);
        }
    }
}

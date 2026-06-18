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
    public class CstructuresController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public CstructuresController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Cstructures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cstructure>>> GetCstructures()
        {
            return await _context.Cstructures.ToListAsync();
        }

        // GET: api/Cstructures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cstructure>> GetCstructure(int id)
        {
            var cstructure = await _context.Cstructures.FindAsync(id);

            if (cstructure == null)
            {
                return NotFound();
            }

            return cstructure;
        }

        // PUT: api/Cstructures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCstructure(int id, Cstructure cstructure)
        {
            if (id != cstructure.CstructureId)
            {
                return BadRequest();
            }

            _context.Entry(cstructure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CstructureExists(id))
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

        // POST: api/Cstructures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cstructure>> PostCstructure(Cstructure cstructure)
        {
            _context.Cstructures.Add(cstructure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCstructure", new { id = cstructure.CstructureId }, cstructure);
        }

        // DELETE: api/Cstructures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCstructure(int id)
        {
            var cstructure = await _context.Cstructures.FindAsync(id);
            if (cstructure == null)
            {
                return NotFound();
            }

            _context.Cstructures.Remove(cstructure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CstructureExists(int id)
        {
            return _context.Cstructures.Any(e => e.CstructureId == id);
        }
    }
}

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
    public class OriginalSalsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public OriginalSalsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/OriginalSals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OriginalSal>>> GetOriginalSals()
        {
            return await _context.OriginalSals.ToListAsync();
        }

        // GET: api/OriginalSals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OriginalSal>> GetOriginalSal(long? id)
        {
            var originalSal = await _context.OriginalSals.FindAsync(id);

            if (originalSal == null)
            {
                return NotFound();
            }

            return originalSal;
        }

        // PUT: api/OriginalSals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOriginalSal(long? id, OriginalSal originalSal)
        {
            if (id != originalSal.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(originalSal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OriginalSalExists(id))
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

        // POST: api/OriginalSals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OriginalSal>> PostOriginalSal(OriginalSal originalSal)
        {
            _context.OriginalSals.Add(originalSal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOriginalSal", new { id = originalSal.EmployeeId }, originalSal);
        }

        // DELETE: api/OriginalSals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOriginalSal(long? id)
        {
            var originalSal = await _context.OriginalSals.FindAsync(id);
            if (originalSal == null)
            {
                return NotFound();
            }

            _context.OriginalSals.Remove(originalSal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OriginalSalExists(long? id)
        {
            return _context.OriginalSals.Any(e => e.EmployeeId == id);
        }
    }
}

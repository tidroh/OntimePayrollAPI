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
    public class PdSalaryChangesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public PdSalaryChangesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/PdSalaryChanges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PdSalaryChange>>> GetPdSalaryChanges()
        {
            return await _context.PdSalaryChanges.ToListAsync();
        }

        // GET: api/PdSalaryChanges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PdSalaryChange>> GetPdSalaryChange(int id)
        {
            var pdSalaryChange = await _context.PdSalaryChanges.FindAsync(id);

            if (pdSalaryChange == null)
            {
                return NotFound();
            }

            return pdSalaryChange;
        }

        // PUT: api/PdSalaryChanges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPdSalaryChange(int id, PdSalaryChange pdSalaryChange)
        {
            if (id != pdSalaryChange.Id)
            {
                return BadRequest();
            }

            _context.Entry(pdSalaryChange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PdSalaryChangeExists(id))
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

        // POST: api/PdSalaryChanges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PdSalaryChange>> PostPdSalaryChange(PdSalaryChange pdSalaryChange)
        {
            _context.PdSalaryChanges.Add(pdSalaryChange);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPdSalaryChange", new { id = pdSalaryChange.Id }, pdSalaryChange);
        }

        // DELETE: api/PdSalaryChanges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePdSalaryChange(int id)
        {
            var pdSalaryChange = await _context.PdSalaryChanges.FindAsync(id);
            if (pdSalaryChange == null)
            {
                return NotFound();
            }

            _context.PdSalaryChanges.Remove(pdSalaryChange);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PdSalaryChangeExists(int id)
        {
            return _context.PdSalaryChanges.Any(e => e.Id == id);
        }
    }
}

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
    public class EmpdivisionsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public EmpdivisionsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Empdivisions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empdivision>>> GetEmpdivisions()
        {
            return await _context.Empdivisions.ToListAsync();
        }

        // GET: api/Empdivisions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empdivision>> GetEmpdivision(int? id)
        {
            var empdivision = await _context.Empdivisions.FindAsync(id);

            if (empdivision == null)
            {
                return NotFound();
            }

            return empdivision;
        }

        // PUT: api/Empdivisions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpdivision(int? id, Empdivision empdivision)
        {
            if (id != empdivision.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(empdivision).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpdivisionExists(id))
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

        // POST: api/Empdivisions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empdivision>> PostEmpdivision(Empdivision empdivision)
        {
            _context.Empdivisions.Add(empdivision);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpdivision", new { id = empdivision.EmployeeId }, empdivision);
        }

        // DELETE: api/Empdivisions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpdivision(int? id)
        {
            var empdivision = await _context.Empdivisions.FindAsync(id);
            if (empdivision == null)
            {
                return NotFound();
            }

            _context.Empdivisions.Remove(empdivision);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpdivisionExists(int? id)
        {
            return _context.Empdivisions.Any(e => e.EmployeeId == id);
        }
    }
}

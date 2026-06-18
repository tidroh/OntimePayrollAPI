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
    public class EmploymentsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public EmploymentsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Employments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employment>>> GetEmployments()
        {
            return await _context.Employments.ToListAsync();
        }

        // GET: api/Employments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employment>> GetEmployment(long id)
        {
            var employment = await _context.Employments.FindAsync(id);

            if (employment == null)
            {
                return NotFound();
            }

            return employment;
        }

        // PUT: api/Employments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployment(long id, Employment employment)
        {
            if (id != employment.Id)
            {
                return BadRequest();
            }

            _context.Entry(employment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentExists(id))
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

        // POST: api/Employments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employment>> PostEmployment(Employment employment)
        {
            _context.Employments.Add(employment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployment", new { id = employment.Id }, employment);
        }

        // DELETE: api/Employments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployment(long id)
        {
            var employment = await _context.Employments.FindAsync(id);
            if (employment == null)
            {
                return NotFound();
            }

            _context.Employments.Remove(employment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmploymentExists(long id)
        {
            return _context.Employments.Any(e => e.Id == id);
        }
    }
}

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
    public class EdusController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public EdusController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Edus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Edu>>> GetEdus()
        {
            return await _context.Edus.ToListAsync();
        }

        // GET: api/Edus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Edu>> GetEdu(int? id)
        {
            var edu = await _context.Edus.FindAsync(id);

            if (edu == null)
            {
                return NotFound();
            }

            return edu;
        }

        // PUT: api/Edus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEdu(int? id, Edu edu)
        {
            if (id != edu.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(edu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EduExists(id))
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

        // POST: api/Edus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Edu>> PostEdu(Edu edu)
        {
            _context.Edus.Add(edu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEdu", new { id = edu.EmployeeId }, edu);
        }

        // DELETE: api/Edus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEdu(int? id)
        {
            var edu = await _context.Edus.FindAsync(id);
            if (edu == null)
            {
                return NotFound();
            }

            _context.Edus.Remove(edu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EduExists(int? id)
        {
            return _context.Edus.Any(e => e.EmployeeId == id);
        }
    }
}

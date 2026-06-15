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
    public class BiosController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public BiosController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Bios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bio>>> GetBios()
        {
            return await _context.Bios.ToListAsync();
        }

        // GET: api/Bios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bio>> GetBio(long? id)
        {
            var bio = await _context.Bios.FindAsync(id);

            if (bio == null)
            {
                return NotFound();
            }

            return bio;
        }

        // PUT: api/Bios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBio(long? id, Bio bio)
        {
            if (id != bio.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(bio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BioExists(id))
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

        // POST: api/Bios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bio>> PostBio(Bio bio)
        {
            _context.Bios.Add(bio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBio", new { id = bio.EmployeeId }, bio);
        }

        // DELETE: api/Bios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBio(long? id)
        {
            var bio = await _context.Bios.FindAsync(id);
            if (bio == null)
            {
                return NotFound();
            }

            _context.Bios.Remove(bio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BioExists(long? id)
        {
            return _context.Bios.Any(e => e.EmployeeId == id);
        }
    }
}

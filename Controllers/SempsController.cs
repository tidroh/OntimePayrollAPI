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
    public class SempsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public SempsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Semps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Semp>>> GetSemps()
        {
            return await _context.Semps.ToListAsync();
        }

        // GET: api/Semps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Semp>> GetSemp(int id)
        {
            var semp = await _context.Semps.FindAsync(id);

            if (semp == null)
            {
                return NotFound();
            }

            return semp;
        }

        // PUT: api/Semps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSemp(int id, Semp semp)
        {
            if (id != semp.Id)
            {
                return BadRequest();
            }

            _context.Entry(semp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SempExists(id))
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

        // POST: api/Semps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Semp>> PostSemp(Semp semp)
        {
            _context.Semps.Add(semp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSemp", new { id = semp.Id }, semp);
        }

        // DELETE: api/Semps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemp(int id)
        {
            var semp = await _context.Semps.FindAsync(id);
            if (semp == null)
            {
                return NotFound();
            }

            _context.Semps.Remove(semp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SempExists(int id)
        {
            return _context.Semps.Any(e => e.Id == id);
        }
    }
}

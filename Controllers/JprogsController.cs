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
    public class JprogsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public JprogsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Jprogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jprog>>> GetJprogs()
        {
            return await _context.Jprogs.ToListAsync();
        }

        // GET: api/Jprogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jprog>> GetJprog(int id)
        {
            var jprog = await _context.Jprogs.FindAsync(id);

            if (jprog == null)
            {
                return NotFound();
            }

            return jprog;
        }

        // PUT: api/Jprogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJprog(int id, Jprog jprog)
        {
            if (id != jprog.Id)
            {
                return BadRequest();
            }

            _context.Entry(jprog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JprogExists(id))
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

        // POST: api/Jprogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jprog>> PostJprog(Jprog jprog)
        {
            _context.Jprogs.Add(jprog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJprog", new { id = jprog.Id }, jprog);
        }

        // DELETE: api/Jprogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJprog(int id)
        {
            var jprog = await _context.Jprogs.FindAsync(id);
            if (jprog == null)
            {
                return NotFound();
            }

            _context.Jprogs.Remove(jprog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JprogExists(int id)
        {
            return _context.Jprogs.Any(e => e.Id == id);
        }
    }
}

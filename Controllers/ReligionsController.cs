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
    public class ReligionsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public ReligionsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Religions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Religion>>> GetReligions()
        {
            return await _context.Religions.ToListAsync();
        }

        // GET: api/Religions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Religion>> GetReligion(int id)
        {
            var religion = await _context.Religions.FindAsync(id);

            if (religion == null)
            {
                return NotFound();
            }

            return religion;
        }

        // PUT: api/Religions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReligion(int id, Religion religion)
        {
            if (id != religion.Id)
            {
                return BadRequest();
            }

            _context.Entry(religion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReligionExists(id))
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

        // POST: api/Religions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Religion>> PostReligion(Religion religion)
        {
            _context.Religions.Add(religion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReligion", new { id = religion.Id }, religion);
        }

        // DELETE: api/Religions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReligion(int id)
        {
            var religion = await _context.Religions.FindAsync(id);
            if (religion == null)
            {
                return NotFound();
            }

            _context.Religions.Remove(religion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReligionExists(int id)
        {
            return _context.Religions.Any(e => e.Id == id);
        }
    }
}

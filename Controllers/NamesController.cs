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
    public class NamesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public NamesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Names
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Name>>> GetNames()
        {
            return await _context.Names.ToListAsync();
        }

        // GET: api/Names/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Name>> GetName(string id)
        {
            var name = await _context.Names.FindAsync(id);

            if (name == null)
            {
                return NotFound();
            }

            return name;
        }

        // PUT: api/Names/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutName(string id, Name name)
        {
            if (id != name.Idnumber)
            {
                return BadRequest();
            }

            _context.Entry(name).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NameExists(id))
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

        // POST: api/Names
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Name>> PostName(Name name)
        {
            _context.Names.Add(name);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NameExists(name.Idnumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetName", new { id = name.Idnumber }, name);
        }

        // DELETE: api/Names/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteName(string id)
        {
            var name = await _context.Names.FindAsync(id);
            if (name == null)
            {
                return NotFound();
            }

            _context.Names.Remove(name);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NameExists(string id)
        {
            return _context.Names.Any(e => e.Idnumber == id);
        }
    }
}

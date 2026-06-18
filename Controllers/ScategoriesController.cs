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
    public class ScategoriesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public ScategoriesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Scategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scategory>>> GetScategories()
        {
            return await _context.Scategories.ToListAsync();
        }

        // GET: api/Scategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scategory>> GetScategory(string id)
        {
            var scategory = await _context.Scategories.FindAsync(id);

            if (scategory == null)
            {
                return NotFound();
            }

            return scategory;
        }

        // PUT: api/Scategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScategory(string id, Scategory scategory)
        {
            if (id != scategory.Acode)
            {
                return BadRequest();
            }

            _context.Entry(scategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScategoryExists(id))
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

        // POST: api/Scategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Scategory>> PostScategory(Scategory scategory)
        {
            _context.Scategories.Add(scategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ScategoryExists(scategory.Acode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetScategory", new { id = scategory.Acode }, scategory);
        }

        // DELETE: api/Scategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScategory(string id)
        {
            var scategory = await _context.Scategories.FindAsync(id);
            if (scategory == null)
            {
                return NotFound();
            }

            _context.Scategories.Remove(scategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScategoryExists(string id)
        {
            return _context.Scategories.Any(e => e.Acode == id);
        }
    }
}

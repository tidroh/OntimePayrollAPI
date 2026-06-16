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
    public class LscategoriesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public LscategoriesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Lscategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lscategory>>> GetLscategories()
        {
            return await _context.Lscategories.ToListAsync();
        }

        // GET: api/Lscategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lscategory>> GetLscategory(string id)
        {
            var lscategory = await _context.Lscategories.FindAsync(id);

            if (lscategory == null)
            {
                return NotFound();
            }

            return lscategory;
        }

        // PUT: api/Lscategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLscategory(string id, Lscategory lscategory)
        {
            if (id != lscategory.Acode)
            {
                return BadRequest();
            }

            _context.Entry(lscategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LscategoryExists(id))
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

        // POST: api/Lscategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lscategory>> PostLscategory(Lscategory lscategory)
        {
            _context.Lscategories.Add(lscategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LscategoryExists(lscategory.Acode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLscategory", new { id = lscategory.Acode }, lscategory);
        }

        // DELETE: api/Lscategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLscategory(string id)
        {
            var lscategory = await _context.Lscategories.FindAsync(id);
            if (lscategory == null)
            {
                return NotFound();
            }

            _context.Lscategories.Remove(lscategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LscategoryExists(string id)
        {
            return _context.Lscategories.Any(e => e.Acode == id);
        }
    }
}

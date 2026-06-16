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
    public class EcategoriesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public EcategoriesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Ecategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ecategory>>> GetEcategories()
        {
            return await _context.Ecategories.ToListAsync();
        }

        // GET: api/Ecategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ecategory>> GetEcategory(int id)
        {
            var ecategory = await _context.Ecategories.FindAsync(id);

            if (ecategory == null)
            {
                return NotFound();
            }

            return ecategory;
        }

        // PUT: api/Ecategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEcategory(int id, Ecategory ecategory)
        {
            if (id != ecategory.EcategoryId)
            {
                return BadRequest();
            }

            _context.Entry(ecategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EcategoryExists(id))
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

        // POST: api/Ecategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ecategory>> PostEcategory(Ecategory ecategory)
        {
            _context.Ecategories.Add(ecategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEcategory", new { id = ecategory.EcategoryId }, ecategory);
        }

        // DELETE: api/Ecategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEcategory(int id)
        {
            var ecategory = await _context.Ecategories.FindAsync(id);
            if (ecategory == null)
            {
                return NotFound();
            }

            _context.Ecategories.Remove(ecategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EcategoryExists(int id)
        {
            return _context.Ecategories.Any(e => e.EcategoryId == id);
        }
    }
}

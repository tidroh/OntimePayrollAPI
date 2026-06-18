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
    public class AcategoriesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public AcategoriesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Acategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acategory>>> GetAcategories()
        {
            return await _context.Acategories.ToListAsync();
        }

        // GET: api/Acategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acategory>> GetAcategory(string id)
        {
            var acategory = await _context.Acategories.FindAsync(id);

            if (acategory == null)
            {
                return NotFound();
            }

            return acategory;
        }

        // PUT: api/Acategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcategory(string id, Acategory acategory)
        {
            if (id != acategory.Acode)
            {
                return BadRequest();
            }

            _context.Entry(acategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcategoryExists(id))
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

        // POST: api/Acategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acategory>> PostAcategory(Acategory acategory)
        {
            _context.Acategories.Add(acategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AcategoryExists(acategory.Acode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAcategory", new { id = acategory.Acode }, acategory);
        }

        // DELETE: api/Acategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcategory(string id)
        {
            var acategory = await _context.Acategories.FindAsync(id);
            if (acategory == null)
            {
                return NotFound();
            }

            _context.Acategories.Remove(acategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcategoryExists(string id)
        {
            return _context.Acategories.Any(e => e.Acode == id);
        }
    }
}

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
    public class LcategoriesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public LcategoriesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Lcategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lcategory>>> GetLcategories()
        {
            return await _context.Lcategories.ToListAsync();
        }

        // GET: api/Lcategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lcategory>> GetLcategory(string id)
        {
            var lcategory = await _context.Lcategories.FindAsync(id);

            if (lcategory == null)
            {
                return NotFound();
            }

            return lcategory;
        }

        // PUT: api/Lcategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLcategory(string id, Lcategory lcategory)
        {
            if (id != lcategory.Acode)
            {
                return BadRequest();
            }

            _context.Entry(lcategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LcategoryExists(id))
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

        // POST: api/Lcategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lcategory>> PostLcategory(Lcategory lcategory)
        {
            _context.Lcategories.Add(lcategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LcategoryExists(lcategory.Acode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLcategory", new { id = lcategory.Acode }, lcategory);
        }

        // DELETE: api/Lcategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLcategory(string id)
        {
            var lcategory = await _context.Lcategories.FindAsync(id);
            if (lcategory == null)
            {
                return NotFound();
            }

            _context.Lcategories.Remove(lcategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LcategoryExists(string id)
        {
            return _context.Lcategories.Any(e => e.Acode == id);
        }
    }
}

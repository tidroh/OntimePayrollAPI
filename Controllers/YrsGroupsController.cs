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
    public class YrsGroupsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public YrsGroupsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/YrsGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YrsGroup>>> GetYrsGroups()
        {
            return await _context.YrsGroups.ToListAsync();
        }

        // GET: api/YrsGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YrsGroup>> GetYrsGroup(long id)
        {
            var yrsGroup = await _context.YrsGroups.FindAsync(id);

            if (yrsGroup == null)
            {
                return NotFound();
            }

            return yrsGroup;
        }

        // PUT: api/YrsGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYrsGroup(long id, YrsGroup yrsGroup)
        {
            if (id != yrsGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(yrsGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YrsGroupExists(id))
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

        // POST: api/YrsGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<YrsGroup>> PostYrsGroup(YrsGroup yrsGroup)
        {
            _context.YrsGroups.Add(yrsGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYrsGroup", new { id = yrsGroup.Id }, yrsGroup);
        }

        // DELETE: api/YrsGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYrsGroup(long id)
        {
            var yrsGroup = await _context.YrsGroups.FindAsync(id);
            if (yrsGroup == null)
            {
                return NotFound();
            }

            _context.YrsGroups.Remove(yrsGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YrsGroupExists(long id)
        {
            return _context.YrsGroups.Any(e => e.Id == id);
        }
    }
}

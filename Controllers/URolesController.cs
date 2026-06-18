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
    public class URolesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public URolesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/URoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<URole>>> GetURoles()
        {
            return await _context.URoles.ToListAsync();
        }

        // GET: api/URoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<URole>> GetURole(int id)
        {
            var uRole = await _context.URoles.FindAsync(id);

            if (uRole == null)
            {
                return NotFound();
            }

            return uRole;
        }

        // PUT: api/URoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutURole(int id, URole uRole)
        {
            if (id != uRole.Roleid)
            {
                return BadRequest();
            }

            _context.Entry(uRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!URoleExists(id))
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

        // POST: api/URoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<URole>> PostURole(URole uRole)
        {
            _context.URoles.Add(uRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetURole", new { id = uRole.Roleid }, uRole);
        }

        // DELETE: api/URoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteURole(int id)
        {
            var uRole = await _context.URoles.FindAsync(id);
            if (uRole == null)
            {
                return NotFound();
            }

            _context.URoles.Remove(uRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool URoleExists(int id)
        {
            return _context.URoles.Any(e => e.Roleid == id);
        }
    }
}

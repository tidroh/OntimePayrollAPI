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
    public class URolerightsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public URolerightsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/URolerights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<URoleright>>> GetURolerights()
        {
            return await _context.URolerights.ToListAsync();
        }

        // GET: api/URolerights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<URoleright>> GetURoleright(string id)
        {
            var uRoleright = await _context.URolerights.FindAsync(id);

            if (uRoleright == null)
            {
                return NotFound();
            }

            return uRoleright;
        }

        // PUT: api/URolerights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutURoleright(string id, URoleright uRoleright)
        {
            if (id != uRoleright.Rolecode)
            {
                return BadRequest();
            }

            _context.Entry(uRoleright).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!URolerightExists(id))
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

        // POST: api/URolerights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<URoleright>> PostURoleright(URoleright uRoleright)
        {
            _context.URolerights.Add(uRoleright);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (URolerightExists(uRoleright.Rolecode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetURoleright", new { id = uRoleright.Rolecode }, uRoleright);
        }

        // DELETE: api/URolerights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteURoleright(string id)
        {
            var uRoleright = await _context.URolerights.FindAsync(id);
            if (uRoleright == null)
            {
                return NotFound();
            }

            _context.URolerights.Remove(uRoleright);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool URolerightExists(string id)
        {
            return _context.URolerights.Any(e => e.Rolecode == id);
        }
    }
}

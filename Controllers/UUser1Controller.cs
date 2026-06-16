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
    public class UUser1Controller : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public UUser1Controller(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/UUser1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UUser1>>> GetUUsers1()
        {
            return await _context.UUsers1.ToListAsync();
        }

        // GET: api/UUser1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UUser1>> GetUUser1(string id)
        {
            var uUser1 = await _context.UUsers1.FindAsync(id);

            if (uUser1 == null)
            {
                return NotFound();
            }

            return uUser1;
        }

        // PUT: api/UUser1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUUser1(string id, UUser1 uUser1)
        {
            if (id != uUser1.Rolecode)
            {
                return BadRequest();
            }

            _context.Entry(uUser1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UUser1Exists(id))
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

        // POST: api/UUser1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UUser1>> PostUUser1(UUser1 uUser1)
        {
            _context.UUsers1.Add(uUser1);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UUser1Exists(uUser1.Rolecode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUUser1", new { id = uUser1.Rolecode }, uUser1);
        }

        // DELETE: api/UUser1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUUser1(string id)
        {
            var uUser1 = await _context.UUsers1.FindAsync(id);
            if (uUser1 == null)
            {
                return NotFound();
            }

            _context.UUsers1.Remove(uUser1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UUser1Exists(string id)
        {
            return _context.UUsers1.Any(e => e.Rolecode == id);
        }
    }
}

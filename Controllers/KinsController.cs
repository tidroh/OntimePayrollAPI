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
    public class KinsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public KinsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Kins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kin>>> GetKins()
        {
            return await _context.Kins.ToListAsync();
        }

        // GET: api/Kins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kin>> GetKin(long id)
        {
            var kin = await _context.Kins.FindAsync(id);

            if (kin == null)
            {
                return NotFound();
            }

            return kin;
        }

        // PUT: api/Kins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKin(long id, Kin kin)
        {
            if (id != kin.Id)
            {
                return BadRequest();
            }

            _context.Entry(kin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KinExists(id))
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

        // POST: api/Kins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kin>> PostKin(Kin kin)
        {
            _context.Kins.Add(kin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKin", new { id = kin.Id }, kin);
        }

        // DELETE: api/Kins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKin(long id)
        {
            var kin = await _context.Kins.FindAsync(id);
            if (kin == null)
            {
                return NotFound();
            }

            _context.Kins.Remove(kin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KinExists(long id)
        {
            return _context.Kins.Any(e => e.Id == id);
        }
    }
}

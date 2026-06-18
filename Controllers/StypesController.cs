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
    public class StypesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public StypesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Stypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stype>>> GetStypes()
        {
            return await _context.Stypes.ToListAsync();
        }

        // GET: api/Stypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stype>> GetStype(int id)
        {
            var stype = await _context.Stypes.FindAsync(id);

            if (stype == null)
            {
                return NotFound();
            }

            return stype;
        }

        // PUT: api/Stypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStype(int id, Stype stype)
        {
            if (id != stype.Id)
            {
                return BadRequest();
            }

            _context.Entry(stype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StypeExists(id))
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

        // POST: api/Stypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stype>> PostStype(Stype stype)
        {
            _context.Stypes.Add(stype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStype", new { id = stype.Id }, stype);
        }

        // DELETE: api/Stypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStype(int id)
        {
            var stype = await _context.Stypes.FindAsync(id);
            if (stype == null)
            {
                return NotFound();
            }

            _context.Stypes.Remove(stype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StypeExists(int id)
        {
            return _context.Stypes.Any(e => e.Id == id);
        }
    }
}

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
    public class AtypesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public AtypesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Atypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atype>>> GetAtypes()
        {
            return await _context.Atypes.ToListAsync();
        }

        // GET: api/Atypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atype>> GetAtype(decimal? id)
        {
            var atype = await _context.Atypes.FindAsync(id);

            if (atype == null)
            {
                return NotFound();
            }

            return atype;
        }

        // PUT: api/Atypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtype(decimal? id, Atype atype)
        {
            if (id != atype.Marks)
            {
                return BadRequest();
            }

            _context.Entry(atype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtypeExists(id))
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

        // POST: api/Atypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Atype>> PostAtype(Atype atype)
        {
            _context.Atypes.Add(atype);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AtypeExists(atype.Marks))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAtype", new { id = atype.Marks }, atype);
        }

        // DELETE: api/Atypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtype(decimal? id)
        {
            var atype = await _context.Atypes.FindAsync(id);
            if (atype == null)
            {
                return NotFound();
            }

            _context.Atypes.Remove(atype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtypeExists(decimal? id)
        {
            return _context.Atypes.Any(e => e.Marks == id);
        }
    }
}

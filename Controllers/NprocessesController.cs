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
    public class NprocessesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public NprocessesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Nprocesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nprocess>>> GetNprocesses()
        {
            return await _context.Nprocesses.ToListAsync();
        }

        // GET: api/Nprocesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nprocess>> GetNprocess(string id)
        {
            var nprocess = await _context.Nprocesses.FindAsync(id);

            if (nprocess == null)
            {
                return NotFound();
            }

            return nprocess;
        }

        // PUT: api/Nprocesses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNprocess(string id, Nprocess nprocess)
        {
            if (id != nprocess.Ugroup)
            {
                return BadRequest();
            }

            _context.Entry(nprocess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NprocessExists(id))
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

        // POST: api/Nprocesses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nprocess>> PostNprocess(Nprocess nprocess)
        {
            _context.Nprocesses.Add(nprocess);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NprocessExists(nprocess.Ugroup))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNprocess", new { id = nprocess.Ugroup }, nprocess);
        }

        // DELETE: api/Nprocesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNprocess(string id)
        {
            var nprocess = await _context.Nprocesses.FindAsync(id);
            if (nprocess == null)
            {
                return NotFound();
            }

            _context.Nprocesses.Remove(nprocess);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NprocessExists(string id)
        {
            return _context.Nprocesses.Any(e => e.Ugroup == id);
        }
    }
}

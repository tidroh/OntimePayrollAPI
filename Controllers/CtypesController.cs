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
    public class CtypesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public CtypesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Ctypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ctype>>> GetCtypes()
        {
            return await _context.Ctypes.ToListAsync();
        }

        // GET: api/Ctypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ctype>> GetCtype(long id)
        {
            var ctype = await _context.Ctypes.FindAsync(id);

            if (ctype == null)
            {
                return NotFound();
            }

            return ctype;
        }

        // PUT: api/Ctypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCtype(long id, Ctype ctype)
        {
            if (id != ctype.Id)
            {
                return BadRequest();
            }

            _context.Entry(ctype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CtypeExists(id))
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

        // POST: api/Ctypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ctype>> PostCtype(Ctype ctype)
        {
            _context.Ctypes.Add(ctype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCtype", new { id = ctype.Id }, ctype);
        }

        // DELETE: api/Ctypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCtype(long id)
        {
            var ctype = await _context.Ctypes.FindAsync(id);
            if (ctype == null)
            {
                return NotFound();
            }

            _context.Ctypes.Remove(ctype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CtypeExists(long id)
        {
            return _context.Ctypes.Any(e => e.Id == id);
        }
    }
}

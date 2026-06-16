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
    public class BtypesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public BtypesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Btypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Btype>>> GetBtypes()
        {
            return await _context.Btypes.ToListAsync();
        }

        // GET: api/Btypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Btype>> GetBtype(long id)
        {
            var btype = await _context.Btypes.FindAsync(id);

            if (btype == null)
            {
                return NotFound();
            }

            return btype;
        }

        // PUT: api/Btypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBtype(long id, Btype btype)
        {
            if (id != btype.Id)
            {
                return BadRequest();
            }

            _context.Entry(btype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BtypeExists(id))
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

        // POST: api/Btypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Btype>> PostBtype(Btype btype)
        {
            _context.Btypes.Add(btype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBtype", new { id = btype.Id }, btype);
        }

        // DELETE: api/Btypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBtype(long id)
        {
            var btype = await _context.Btypes.FindAsync(id);
            if (btype == null)
            {
                return NotFound();
            }

            _context.Btypes.Remove(btype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BtypeExists(long id)
        {
            return _context.Btypes.Any(e => e.Id == id);
        }
    }
}

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
    public class TempAddsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TempAddsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TempAdds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TempAdd>>> GetTempAdds()
        {
            return await _context.TempAdds.ToListAsync();
        }

        // GET: api/TempAdds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TempAdd>> GetTempAdd(DateTime? id)
        {
            var tempAdd = await _context.TempAdds.FindAsync(id);

            if (tempAdd == null)
            {
                return NotFound();
            }

            return tempAdd;
        }

        // PUT: api/TempAdds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTempAdd(DateTime? id, TempAdd tempAdd)
        {
            if (id != tempAdd.Demp)
            {
                return BadRequest();
            }

            _context.Entry(tempAdd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TempAddExists(id))
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

        // POST: api/TempAdds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TempAdd>> PostTempAdd(TempAdd tempAdd)
        {
            _context.TempAdds.Add(tempAdd);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TempAddExists(tempAdd.Demp))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTempAdd", new { id = tempAdd.Demp }, tempAdd);
        }

        // DELETE: api/TempAdds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTempAdd(DateTime? id)
        {
            var tempAdd = await _context.TempAdds.FindAsync(id);
            if (tempAdd == null)
            {
                return NotFound();
            }

            _context.TempAdds.Remove(tempAdd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TempAddExists(DateTime? id)
        {
            return _context.TempAdds.Any(e => e.Demp == id);
        }
    }
}

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
    public class AcommentsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public AcommentsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Acomments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acomment>>> GetAcomments()
        {
            return await _context.Acomments.ToListAsync();
        }

        // GET: api/Acomments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acomment>> GetAcomment(decimal? id)
        {
            var acomment = await _context.Acomments.FindAsync(id);

            if (acomment == null)
            {
                return NotFound();
            }

            return acomment;
        }

        // PUT: api/Acomments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcomment(decimal? id, Acomment acomment)
        {
            if (id != acomment.Marks)
            {
                return BadRequest();
            }

            _context.Entry(acomment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcommentExists(id))
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

        // POST: api/Acomments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acomment>> PostAcomment(Acomment acomment)
        {
            _context.Acomments.Add(acomment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AcommentExists(acomment.Marks))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAcomment", new { id = acomment.Marks }, acomment);
        }

        // DELETE: api/Acomments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcomment(decimal? id)
        {
            var acomment = await _context.Acomments.FindAsync(id);
            if (acomment == null)
            {
                return NotFound();
            }

            _context.Acomments.Remove(acomment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcommentExists(decimal? id)
        {
            return _context.Acomments.Any(e => e.Marks == id);
        }
    }
}

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
    public class CasualsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public CasualsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Casuals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Casual>>> GetCasuals()
        {
            return await _context.Casuals.ToListAsync();
        }

        // GET: api/Casuals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Casual>> GetCasual(DateTime? id)
        {
            var casual = await _context.Casuals.FindAsync(id);

            if (casual == null)
            {
                return NotFound();
            }

            return casual;
        }

        // PUT: api/Casuals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCasual(DateTime? id, Casual casual)
        {
            if (id != casual.Cfrom)
            {
                return BadRequest();
            }

            _context.Entry(casual).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasualExists(id))
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

        // POST: api/Casuals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Casual>> PostCasual(Casual casual)
        {
            _context.Casuals.Add(casual);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CasualExists(casual.Cfrom))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCasual", new { id = casual.Cfrom }, casual);
        }

        // DELETE: api/Casuals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCasual(DateTime? id)
        {
            var casual = await _context.Casuals.FindAsync(id);
            if (casual == null)
            {
                return NotFound();
            }

            _context.Casuals.Remove(casual);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CasualExists(DateTime? id)
        {
            return _context.Casuals.Any(e => e.Cfrom == id);
        }
    }
}

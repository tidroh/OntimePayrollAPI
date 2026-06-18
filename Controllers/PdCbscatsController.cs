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
    public class PdCbscatsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public PdCbscatsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/PdCbscats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PdCbscat>>> GetPdCbscats()
        {
            return await _context.PdCbscats.ToListAsync();
        }

        // GET: api/PdCbscats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PdCbscat>> GetPdCbscat(string id)
        {
            var pdCbscat = await _context.PdCbscats.FindAsync(id);

            if (pdCbscat == null)
            {
                return NotFound();
            }

            return pdCbscat;
        }

        // PUT: api/PdCbscats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPdCbscat(string id, PdCbscat pdCbscat)
        {
            if (id != pdCbscat.Code)
            {
                return BadRequest();
            }

            _context.Entry(pdCbscat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PdCbscatExists(id))
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

        // POST: api/PdCbscats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PdCbscat>> PostPdCbscat(PdCbscat pdCbscat)
        {
            _context.PdCbscats.Add(pdCbscat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PdCbscatExists(pdCbscat.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPdCbscat", new { id = pdCbscat.Code }, pdCbscat);
        }

        // DELETE: api/PdCbscats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePdCbscat(string id)
        {
            var pdCbscat = await _context.PdCbscats.FindAsync(id);
            if (pdCbscat == null)
            {
                return NotFound();
            }

            _context.PdCbscats.Remove(pdCbscat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PdCbscatExists(string id)
        {
            return _context.PdCbscats.Any(e => e.Code == id);
        }
    }
}

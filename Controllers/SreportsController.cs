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
    public class SreportsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public SreportsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Sreports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sreport>>> GetSreports()
        {
            return await _context.Sreports.ToListAsync();
        }

        // GET: api/Sreports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sreport>> GetSreport(string id)
        {
            var sreport = await _context.Sreports.FindAsync(id);

            if (sreport == null)
            {
                return NotFound();
            }

            return sreport;
        }

        // PUT: api/Sreports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSreport(string id, Sreport sreport)
        {
            if (id != sreport.ObjectId)
            {
                return BadRequest();
            }

            _context.Entry(sreport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SreportExists(id))
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

        // POST: api/Sreports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sreport>> PostSreport(Sreport sreport)
        {
            _context.Sreports.Add(sreport);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SreportExists(sreport.ObjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSreport", new { id = sreport.ObjectId }, sreport);
        }

        // DELETE: api/Sreports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSreport(string id)
        {
            var sreport = await _context.Sreports.FindAsync(id);
            if (sreport == null)
            {
                return NotFound();
            }

            _context.Sreports.Remove(sreport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SreportExists(string id)
        {
            return _context.Sreports.Any(e => e.ObjectId == id);
        }
    }
}

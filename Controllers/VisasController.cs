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
    public class VisasController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public VisasController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Visas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visa>>> GetVisas()
        {
            return await _context.Visas.ToListAsync();
        }

        // GET: api/Visas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visa>> GetVisa(long id)
        {
            var visa = await _context.Visas.FindAsync(id);

            if (visa == null)
            {
                return NotFound();
            }

            return visa;
        }

        // PUT: api/Visas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisa(long id, Visa visa)
        {
            if (id != visa.Id)
            {
                return BadRequest();
            }

            _context.Entry(visa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisaExists(id))
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

        // POST: api/Visas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Visa>> PostVisa(Visa visa)
        {
            _context.Visas.Add(visa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisa", new { id = visa.Id }, visa);
        }

        // DELETE: api/Visas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisa(long id)
        {
            var visa = await _context.Visas.FindAsync(id);
            if (visa == null)
            {
                return NotFound();
            }

            _context.Visas.Remove(visa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisaExists(long id)
        {
            return _context.Visas.Any(e => e.Id == id);
        }
    }
}

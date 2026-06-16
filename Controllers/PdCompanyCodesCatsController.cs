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
    public class PdCompanyCodesCatsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public PdCompanyCodesCatsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/PdCompanyCodesCats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PdCompanyCodesCat>>> GetPdCompanyCodesCats()
        {
            return await _context.PdCompanyCodesCats.ToListAsync();
        }

        // GET: api/PdCompanyCodesCats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PdCompanyCodesCat>> GetPdCompanyCodesCat(string id)
        {
            var pdCompanyCodesCat = await _context.PdCompanyCodesCats.FindAsync(id);

            if (pdCompanyCodesCat == null)
            {
                return NotFound();
            }

            return pdCompanyCodesCat;
        }

        // PUT: api/PdCompanyCodesCats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPdCompanyCodesCat(string id, PdCompanyCodesCat pdCompanyCodesCat)
        {
            if (id != pdCompanyCodesCat.Code)
            {
                return BadRequest();
            }

            _context.Entry(pdCompanyCodesCat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PdCompanyCodesCatExists(id))
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

        // POST: api/PdCompanyCodesCats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PdCompanyCodesCat>> PostPdCompanyCodesCat(PdCompanyCodesCat pdCompanyCodesCat)
        {
            _context.PdCompanyCodesCats.Add(pdCompanyCodesCat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PdCompanyCodesCatExists(pdCompanyCodesCat.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPdCompanyCodesCat", new { id = pdCompanyCodesCat.Code }, pdCompanyCodesCat);
        }

        // DELETE: api/PdCompanyCodesCats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePdCompanyCodesCat(string id)
        {
            var pdCompanyCodesCat = await _context.PdCompanyCodesCats.FindAsync(id);
            if (pdCompanyCodesCat == null)
            {
                return NotFound();
            }

            _context.PdCompanyCodesCats.Remove(pdCompanyCodesCat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PdCompanyCodesCatExists(string id)
        {
            return _context.PdCompanyCodesCats.Any(e => e.Code == id);
        }
    }
}

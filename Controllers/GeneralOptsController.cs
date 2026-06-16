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
    public class GeneralOptsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public GeneralOptsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/GeneralOpts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralOpt>>> GetGeneralOpts()
        {
            return await _context.GeneralOpts.ToListAsync();
        }

        // GET: api/GeneralOpts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralOpt>> GetGeneralOpt(long id)
        {
            var generalOpt = await _context.GeneralOpts.FindAsync(id);

            if (generalOpt == null)
            {
                return NotFound();
            }

            return generalOpt;
        }

        // PUT: api/GeneralOpts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralOpt(long id, GeneralOpt generalOpt)
        {
            if (id != generalOpt.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalOpt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralOptExists(id))
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

        // POST: api/GeneralOpts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeneralOpt>> PostGeneralOpt(GeneralOpt generalOpt)
        {
            _context.GeneralOpts.Add(generalOpt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralOpt", new { id = generalOpt.Id }, generalOpt);
        }

        // DELETE: api/GeneralOpts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneralOpt(long id)
        {
            var generalOpt = await _context.GeneralOpts.FindAsync(id);
            if (generalOpt == null)
            {
                return NotFound();
            }

            _context.GeneralOpts.Remove(generalOpt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeneralOptExists(long id)
        {
            return _context.GeneralOpts.Any(e => e.Id == id);
        }
    }
}

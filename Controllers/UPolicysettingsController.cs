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
    public class UPolicysettingsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public UPolicysettingsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/UPolicysettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UPolicysetting>>> GetUPolicysettings()
        {
            return await _context.UPolicysettings.ToListAsync();
        }

        // GET: api/UPolicysettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UPolicysetting>> GetUPolicysetting(int? id)
        {
            var uPolicysetting = await _context.UPolicysettings.FindAsync(id);

            if (uPolicysetting == null)
            {
                return NotFound();
            }

            return uPolicysetting;
        }

        // PUT: api/UPolicysettings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUPolicysetting(int? id, UPolicysetting uPolicysetting)
        {
            if (id != uPolicysetting.Pwdminage)
            {
                return BadRequest();
            }

            _context.Entry(uPolicysetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UPolicysettingExists(id))
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

        // POST: api/UPolicysettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UPolicysetting>> PostUPolicysetting(UPolicysetting uPolicysetting)
        {
            _context.UPolicysettings.Add(uPolicysetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUPolicysetting", new { id = uPolicysetting.Pwdminage }, uPolicysetting);
        }

        // DELETE: api/UPolicysettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUPolicysetting(int? id)
        {
            var uPolicysetting = await _context.UPolicysettings.FindAsync(id);
            if (uPolicysetting == null)
            {
                return NotFound();
            }

            _context.UPolicysettings.Remove(uPolicysetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UPolicysettingExists(int? id)
        {
            return _context.UPolicysettings.Any(e => e.Pwdminage == id);
        }
    }
}

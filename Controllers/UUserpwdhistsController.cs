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
    public class UUserpwdhistsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public UUserpwdhistsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/UUserpwdhists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UUserpwdhist>>> GetUUserpwdhists()
        {
            return await _context.UUserpwdhists.ToListAsync();
        }

        // GET: api/UUserpwdhists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UUserpwdhist>> GetUUserpwdhist(string id)
        {
            var uUserpwdhist = await _context.UUserpwdhists.FindAsync(id);

            if (uUserpwdhist == null)
            {
                return NotFound();
            }

            return uUserpwdhist;
        }

        // PUT: api/UUserpwdhists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUUserpwdhist(string id, UUserpwdhist uUserpwdhist)
        {
            if (id != uUserpwdhist.Usercode)
            {
                return BadRequest();
            }

            _context.Entry(uUserpwdhist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UUserpwdhistExists(id))
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

        // POST: api/UUserpwdhists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UUserpwdhist>> PostUUserpwdhist(UUserpwdhist uUserpwdhist)
        {
            _context.UUserpwdhists.Add(uUserpwdhist);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UUserpwdhistExists(uUserpwdhist.Usercode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUUserpwdhist", new { id = uUserpwdhist.Usercode }, uUserpwdhist);
        }

        // DELETE: api/UUserpwdhists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUUserpwdhist(string id)
        {
            var uUserpwdhist = await _context.UUserpwdhists.FindAsync(id);
            if (uUserpwdhist == null)
            {
                return NotFound();
            }

            _context.UUserpwdhists.Remove(uUserpwdhist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UUserpwdhistExists(string id)
        {
            return _context.UUserpwdhists.Any(e => e.Usercode == id);
        }
    }
}

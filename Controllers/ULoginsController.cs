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
    public class ULoginsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public ULoginsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/ULogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ULogin>>> GetULogins()
        {
            return await _context.ULogins.ToListAsync();
        }

        // GET: api/ULogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ULogin>> GetULogin(int id)
        {
            var uLogin = await _context.ULogins.FindAsync(id);

            if (uLogin == null)
            {
                return NotFound();
            }

            return uLogin;
        }

        // PUT: api/ULogins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutULogin(int id, ULogin uLogin)
        {
            if (id != uLogin.Logid)
            {
                return BadRequest();
            }

            _context.Entry(uLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ULoginExists(id))
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

        // POST: api/ULogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ULogin>> PostULogin(ULogin uLogin)
        {
            _context.ULogins.Add(uLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetULogin", new { id = uLogin.Logid }, uLogin);
        }

        // DELETE: api/ULogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteULogin(int id)
        {
            var uLogin = await _context.ULogins.FindAsync(id);
            if (uLogin == null)
            {
                return NotFound();
            }

            _context.ULogins.Remove(uLogin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ULoginExists(int id)
        {
            return _context.ULogins.Any(e => e.Logid == id);
        }
    }
}

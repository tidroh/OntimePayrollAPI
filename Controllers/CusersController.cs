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
    public class CusersController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public CusersController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Cusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuser>>> GetCusers()
        {
            return await _context.Cusers.ToListAsync();
        }

        // GET: api/Cusers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuser>> GetCuser(string id)
        {
            var cuser = await _context.Cusers.FindAsync(id);

            if (cuser == null)
            {
                return NotFound();
            }

            return cuser;
        }

        // PUT: api/Cusers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuser(string id, Cuser cuser)
        {
            if (id != cuser.Uname)
            {
                return BadRequest();
            }

            _context.Entry(cuser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuserExists(id))
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

        // POST: api/Cusers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuser>> PostCuser(Cuser cuser)
        {
            _context.Cusers.Add(cuser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CuserExists(cuser.Uname))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCuser", new { id = cuser.Uname }, cuser);
        }

        // DELETE: api/Cusers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuser(string id)
        {
            var cuser = await _context.Cusers.FindAsync(id);
            if (cuser == null)
            {
                return NotFound();
            }

            _context.Cusers.Remove(cuser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuserExists(string id)
        {
            return _context.Cusers.Any(e => e.Uname == id);
        }
    }
}

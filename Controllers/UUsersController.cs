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
    public class UUsersController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public UUsersController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/UUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UUser>>> GetUUsers()
        {
            return await _context.UUsers.ToListAsync();
        }

        // GET: api/UUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UUser>> GetUUser(int? id)
        {
            var uUser = await _context.UUsers.FindAsync(id);

            if (uUser == null)
            {
                return NotFound();
            }

            return uUser;
        }

        // PUT: api/UUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUUser(int? id, UUser uUser)
        {
            if (id != uUser.Userid)
            {
                return BadRequest();
            }

            _context.Entry(uUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UUserExists(id))
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

        // POST: api/UUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UUser>> PostUUser(UUser uUser)
        {
            _context.UUsers.Add(uUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUUser", new { id = uUser.Userid }, uUser);
        }

        // DELETE: api/UUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUUser(int? id)
        {
            var uUser = await _context.UUsers.FindAsync(id);
            if (uUser == null)
            {
                return NotFound();
            }

            _context.UUsers.Remove(uUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UUserExists(int? id)
        {
            return _context.UUsers.Any(e => e.Userid == id);
        }
    }
}

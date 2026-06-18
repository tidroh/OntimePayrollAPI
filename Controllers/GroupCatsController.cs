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
    public class GroupCatsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public GroupCatsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/GroupCats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupCat>>> GetGroupCats()
        {
            return await _context.GroupCats.ToListAsync();
        }

        // GET: api/GroupCats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupCat>> GetGroupCat(string id)
        {
            var groupCat = await _context.GroupCats.FindAsync(id);

            if (groupCat == null)
            {
                return NotFound();
            }

            return groupCat;
        }

        // PUT: api/GroupCats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupCat(string id, GroupCat groupCat)
        {
            if (id != groupCat.Gno)
            {
                return BadRequest();
            }

            _context.Entry(groupCat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupCatExists(id))
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

        // POST: api/GroupCats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupCat>> PostGroupCat(GroupCat groupCat)
        {
            _context.GroupCats.Add(groupCat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GroupCatExists(groupCat.Gno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGroupCat", new { id = groupCat.Gno }, groupCat);
        }

        // DELETE: api/GroupCats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupCat(string id)
        {
            var groupCat = await _context.GroupCats.FindAsync(id);
            if (groupCat == null)
            {
                return NotFound();
            }

            _context.GroupCats.Remove(groupCat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupCatExists(string id)
        {
            return _context.GroupCats.Any(e => e.Gno == id);
        }
    }
}

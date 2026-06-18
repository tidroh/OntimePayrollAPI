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
    public class GroupModulesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public GroupModulesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/GroupModules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupModule>>> GetGroupModules()
        {
            return await _context.GroupModules.ToListAsync();
        }

        // GET: api/GroupModules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupModule>> GetGroupModule(string id)
        {
            var groupModule = await _context.GroupModules.FindAsync(id);

            if (groupModule == null)
            {
                return NotFound();
            }

            return groupModule;
        }

        // PUT: api/GroupModules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupModule(string id, GroupModule groupModule)
        {
            if (id != groupModule.Gno)
            {
                return BadRequest();
            }

            _context.Entry(groupModule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupModuleExists(id))
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

        // POST: api/GroupModules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupModule>> PostGroupModule(GroupModule groupModule)
        {
            _context.GroupModules.Add(groupModule);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GroupModuleExists(groupModule.Gno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGroupModule", new { id = groupModule.Gno }, groupModule);
        }

        // DELETE: api/GroupModules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupModule(string id)
        {
            var groupModule = await _context.GroupModules.FindAsync(id);
            if (groupModule == null)
            {
                return NotFound();
            }

            _context.GroupModules.Remove(groupModule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupModuleExists(string id)
        {
            return _context.GroupModules.Any(e => e.Gno == id);
        }
    }
}

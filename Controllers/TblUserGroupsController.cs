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
    public class TblUserGroupsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblUserGroupsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblUserGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUserGroup>>> GetTblUserGroups()
        {
            return await _context.TblUserGroups.ToListAsync();
        }

        // GET: api/TblUserGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUserGroup>> GetTblUserGroup(int id)
        {
            var tblUserGroup = await _context.TblUserGroups.FindAsync(id);

            if (tblUserGroup == null)
            {
                return NotFound();
            }

            return tblUserGroup;
        }

        // PUT: api/TblUserGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUserGroup(int id, TblUserGroup tblUserGroup)
        {
            if (id != tblUserGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblUserGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserGroupExists(id))
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

        // POST: api/TblUserGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblUserGroup>> PostTblUserGroup(TblUserGroup tblUserGroup)
        {
            _context.TblUserGroups.Add(tblUserGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUserGroup", new { id = tblUserGroup.Id }, tblUserGroup);
        }

        // DELETE: api/TblUserGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblUserGroup(int id)
        {
            var tblUserGroup = await _context.TblUserGroups.FindAsync(id);
            if (tblUserGroup == null)
            {
                return NotFound();
            }

            _context.TblUserGroups.Remove(tblUserGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblUserGroupExists(int id)
        {
            return _context.TblUserGroups.Any(e => e.Id == id);
        }
    }
}

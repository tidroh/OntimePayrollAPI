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
    public class LevelTypesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public LevelTypesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/LevelTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LevelType>>> GetLevelTypes()
        {
            return await _context.LevelTypes.ToListAsync();
        }

        // GET: api/LevelTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LevelType>> GetLevelType(string id)
        {
            var levelType = await _context.LevelTypes.FindAsync(id);

            if (levelType == null)
            {
                return NotFound();
            }

            return levelType;
        }

        // PUT: api/LevelTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevelType(string id, LevelType levelType)
        {
            if (id != levelType.Lcode)
            {
                return BadRequest();
            }

            _context.Entry(levelType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelTypeExists(id))
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

        // POST: api/LevelTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LevelType>> PostLevelType(LevelType levelType)
        {
            _context.LevelTypes.Add(levelType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LevelTypeExists(levelType.Lcode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLevelType", new { id = levelType.Lcode }, levelType);
        }

        // DELETE: api/LevelTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLevelType(string id)
        {
            var levelType = await _context.LevelTypes.FindAsync(id);
            if (levelType == null)
            {
                return NotFound();
            }

            _context.LevelTypes.Remove(levelType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LevelTypeExists(string id)
        {
            return _context.LevelTypes.Any(e => e.Lcode == id);
        }
    }
}

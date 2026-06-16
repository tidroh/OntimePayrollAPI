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
    public class PositionRequirementsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public PositionRequirementsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/PositionRequirements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionRequirement>>> GetPositionRequirements()
        {
            return await _context.PositionRequirements.ToListAsync();
        }

        // GET: api/PositionRequirements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionRequirement>> GetPositionRequirement(int id)
        {
            var positionRequirement = await _context.PositionRequirements.FindAsync(id);

            if (positionRequirement == null)
            {
                return NotFound();
            }

            return positionRequirement;
        }

        // PUT: api/PositionRequirements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPositionRequirement(int id, PositionRequirement positionRequirement)
        {
            if (id != positionRequirement.PositionRequirementsId)
            {
                return BadRequest();
            }

            _context.Entry(positionRequirement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionRequirementExists(id))
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

        // POST: api/PositionRequirements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PositionRequirement>> PostPositionRequirement(PositionRequirement positionRequirement)
        {
            _context.PositionRequirements.Add(positionRequirement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPositionRequirement", new { id = positionRequirement.PositionRequirementsId }, positionRequirement);
        }

        // DELETE: api/PositionRequirements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePositionRequirement(int id)
        {
            var positionRequirement = await _context.PositionRequirements.FindAsync(id);
            if (positionRequirement == null)
            {
                return NotFound();
            }

            _context.PositionRequirements.Remove(positionRequirement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PositionRequirementExists(int id)
        {
            return _context.PositionRequirements.Any(e => e.PositionRequirementsId == id);
        }
    }
}

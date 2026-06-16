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
    public class PositionRequirementsValuesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public PositionRequirementsValuesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/PositionRequirementsValues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionRequirementsValue>>> GetPositionRequirementsValues()
        {
            return await _context.PositionRequirementsValues.ToListAsync();
        }

        // GET: api/PositionRequirementsValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionRequirementsValue>> GetPositionRequirementsValue(int? id)
        {
            var positionRequirementsValue = await _context.PositionRequirementsValues.FindAsync(id);

            if (positionRequirementsValue == null)
            {
                return NotFound();
            }

            return positionRequirementsValue;
        }

        // PUT: api/PositionRequirementsValues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPositionRequirementsValue(int? id, PositionRequirementsValue positionRequirementsValue)
        {
            if (id != positionRequirementsValue.PositionId)
            {
                return BadRequest();
            }

            _context.Entry(positionRequirementsValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionRequirementsValueExists(id))
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

        // POST: api/PositionRequirementsValues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PositionRequirementsValue>> PostPositionRequirementsValue(PositionRequirementsValue positionRequirementsValue)
        {
            _context.PositionRequirementsValues.Add(positionRequirementsValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPositionRequirementsValue", new { id = positionRequirementsValue.PositionId }, positionRequirementsValue);
        }

        // DELETE: api/PositionRequirementsValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePositionRequirementsValue(int? id)
        {
            var positionRequirementsValue = await _context.PositionRequirementsValues.FindAsync(id);
            if (positionRequirementsValue == null)
            {
                return NotFound();
            }

            _context.PositionRequirementsValues.Remove(positionRequirementsValue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PositionRequirementsValueExists(int? id)
        {
            return _context.PositionRequirementsValues.Any(e => e.PositionId == id);
        }
    }
}

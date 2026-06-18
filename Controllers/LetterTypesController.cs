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
    public class LetterTypesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public LetterTypesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/LetterTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LetterType>>> GetLetterTypes()
        {
            return await _context.LetterTypes.ToListAsync();
        }

        // GET: api/LetterTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LetterType>> GetLetterType(int? id)
        {
            var letterType = await _context.LetterTypes.FindAsync(id);

            if (letterType == null)
            {
                return NotFound();
            }

            return letterType;
        }

        // PUT: api/LetterTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLetterType(int? id, LetterType letterType)
        {
            if (id != letterType.Eperiod)
            {
                return BadRequest();
            }

            _context.Entry(letterType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LetterTypeExists(id))
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

        // POST: api/LetterTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LetterType>> PostLetterType(LetterType letterType)
        {
            _context.LetterTypes.Add(letterType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLetterType", new { id = letterType.Eperiod }, letterType);
        }

        // DELETE: api/LetterTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLetterType(int? id)
        {
            var letterType = await _context.LetterTypes.FindAsync(id);
            if (letterType == null)
            {
                return NotFound();
            }

            _context.LetterTypes.Remove(letterType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LetterTypeExists(int? id)
        {
            return _context.LetterTypes.Any(e => e.Eperiod == id);
        }
    }
}

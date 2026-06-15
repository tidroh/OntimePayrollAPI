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
    public class DCaseRatingsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public DCaseRatingsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/DCaseRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCaseRating>>> GetDCaseRatings()
        {
            return await _context.DCaseRatings.ToListAsync();
        }

        // GET: api/DCaseRatings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DCaseRating>> GetDCaseRating(int id)
        {
            var dCaseRating = await _context.DCaseRatings.FindAsync(id);

            if (dCaseRating == null)
            {
                return NotFound();
            }

            return dCaseRating;
        }

        // PUT: api/DCaseRatings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCaseRating(int id, DCaseRating dCaseRating)
        {
            if (id != dCaseRating.RatingId)
            {
                return BadRequest();
            }

            _context.Entry(dCaseRating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCaseRatingExists(id))
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

        // POST: api/DCaseRatings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DCaseRating>> PostDCaseRating(DCaseRating dCaseRating)
        {
            _context.DCaseRatings.Add(dCaseRating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCaseRating", new { id = dCaseRating.RatingId }, dCaseRating);
        }

        // DELETE: api/DCaseRatings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDCaseRating(int id)
        {
            var dCaseRating = await _context.DCaseRatings.FindAsync(id);
            if (dCaseRating == null)
            {
                return NotFound();
            }

            _context.DCaseRatings.Remove(dCaseRating);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DCaseRatingExists(int id)
        {
            return _context.DCaseRatings.Any(e => e.RatingId == id);
        }
    }
}

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
    public class NewQualificationsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public NewQualificationsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/NewQualifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewQualification>>> GetNewQualifications()
        {
            return await _context.NewQualifications.ToListAsync();
        }

        // GET: api/NewQualifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewQualification>> GetNewQualification(string id)
        {
            var newQualification = await _context.NewQualifications.FindAsync(id);

            if (newQualification == null)
            {
                return NotFound();
            }

            return newQualification;
        }

        // PUT: api/NewQualifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewQualification(string id, NewQualification newQualification)
        {
            if (id != newQualification.MyReq)
            {
                return BadRequest();
            }

            _context.Entry(newQualification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewQualificationExists(id))
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

        // POST: api/NewQualifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NewQualification>> PostNewQualification(NewQualification newQualification)
        {
            _context.NewQualifications.Add(newQualification);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NewQualificationExists(newQualification.MyReq))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNewQualification", new { id = newQualification.MyReq }, newQualification);
        }

        // DELETE: api/NewQualifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewQualification(string id)
        {
            var newQualification = await _context.NewQualifications.FindAsync(id);
            if (newQualification == null)
            {
                return NotFound();
            }

            _context.NewQualifications.Remove(newQualification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewQualificationExists(string id)
        {
            return _context.NewQualifications.Any(e => e.MyReq == id);
        }
    }
}

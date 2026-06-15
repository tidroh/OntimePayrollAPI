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
    public class EditLettersController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public EditLettersController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/EditLetters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EditLetter>>> GetEditLetters()
        {
            return await _context.EditLetters.ToListAsync();
        }

        // GET: api/EditLetters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EditLetter>> GetEditLetter(string id)
        {
            var editLetter = await _context.EditLetters.FindAsync(id);

            if (editLetter == null)
            {
                return NotFound();
            }

            return editLetter;
        }

        // PUT: api/EditLetters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditLetter(string id, EditLetter editLetter)
        {
            if (id != editLetter.Ltype)
            {
                return BadRequest();
            }

            _context.Entry(editLetter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditLetterExists(id))
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

        // POST: api/EditLetters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EditLetter>> PostEditLetter(EditLetter editLetter)
        {
            _context.EditLetters.Add(editLetter);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EditLetterExists(editLetter.Ltype))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEditLetter", new { id = editLetter.Ltype }, editLetter);
        }

        // DELETE: api/EditLetters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditLetter(string id)
        {
            var editLetter = await _context.EditLetters.FindAsync(id);
            if (editLetter == null)
            {
                return NotFound();
            }

            _context.EditLetters.Remove(editLetter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EditLetterExists(string id)
        {
            return _context.EditLetters.Any(e => e.Ltype == id);
        }
    }
}

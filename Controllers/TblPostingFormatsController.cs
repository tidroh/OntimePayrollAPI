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
    public class TblPostingFormatsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblPostingFormatsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblPostingFormats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPostingFormat>>> GetTblPostingFormats()
        {
            return await _context.TblPostingFormats.ToListAsync();
        }

        // GET: api/TblPostingFormats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPostingFormat>> GetTblPostingFormat(int id)
        {
            var tblPostingFormat = await _context.TblPostingFormats.FindAsync(id);

            if (tblPostingFormat == null)
            {
                return NotFound();
            }

            return tblPostingFormat;
        }

        // PUT: api/TblPostingFormats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPostingFormat(int id, TblPostingFormat tblPostingFormat)
        {
            if (id != tblPostingFormat.PostingFormatId)
            {
                return BadRequest();
            }

            _context.Entry(tblPostingFormat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPostingFormatExists(id))
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

        // POST: api/TblPostingFormats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPostingFormat>> PostTblPostingFormat(TblPostingFormat tblPostingFormat)
        {
            _context.TblPostingFormats.Add(tblPostingFormat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPostingFormat", new { id = tblPostingFormat.PostingFormatId }, tblPostingFormat);
        }

        // DELETE: api/TblPostingFormats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPostingFormat(int id)
        {
            var tblPostingFormat = await _context.TblPostingFormats.FindAsync(id);
            if (tblPostingFormat == null)
            {
                return NotFound();
            }

            _context.TblPostingFormats.Remove(tblPostingFormat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPostingFormatExists(int id)
        {
            return _context.TblPostingFormats.Any(e => e.PostingFormatId == id);
        }
    }
}

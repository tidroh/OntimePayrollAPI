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
    public class TblPensionsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblPensionsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblPensions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPension>>> GetTblPensions()
        {
            return await _context.TblPensions.ToListAsync();
        }

        // GET: api/TblPensions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPension>> GetTblPension(int id)
        {
            var tblPension = await _context.TblPensions.FindAsync(id);

            if (tblPension == null)
            {
                return NotFound();
            }

            return tblPension;
        }

        // PUT: api/TblPensions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPension(int id, TblPension tblPension)
        {
            if (id != tblPension.PayrollcodeId)
            {
                return BadRequest();
            }

            _context.Entry(tblPension).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPensionExists(id))
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

        // POST: api/TblPensions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPension>> PostTblPension(TblPension tblPension)
        {
            _context.TblPensions.Add(tblPension);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPension", new { id = tblPension.PayrollcodeId }, tblPension);
        }

        // DELETE: api/TblPensions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPension(int id)
        {
            var tblPension = await _context.TblPensions.FindAsync(id);
            if (tblPension == null)
            {
                return NotFound();
            }

            _context.TblPensions.Remove(tblPension);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPensionExists(int id)
        {
            return _context.TblPensions.Any(e => e.PayrollcodeId == id);
        }
    }
}

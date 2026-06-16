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
    public class TblVariancesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblVariancesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblVariances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblVariance>>> GetTblVariances()
        {
            return await _context.TblVariances.ToListAsync();
        }

        // GET: api/TblVariances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblVariance>> GetTblVariance(int? id)
        {
            var tblVariance = await _context.TblVariances.FindAsync(id);

            if (tblVariance == null)
            {
                return NotFound();
            }

            return tblVariance;
        }

        // PUT: api/TblVariances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblVariance(int? id, TblVariance tblVariance)
        {
            if (id != tblVariance.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(tblVariance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblVarianceExists(id))
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

        // POST: api/TblVariances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblVariance>> PostTblVariance(TblVariance tblVariance)
        {
            _context.TblVariances.Add(tblVariance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblVariance", new { id = tblVariance.EmployeeId }, tblVariance);
        }

        // DELETE: api/TblVariances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblVariance(int? id)
        {
            var tblVariance = await _context.TblVariances.FindAsync(id);
            if (tblVariance == null)
            {
                return NotFound();
            }

            _context.TblVariances.Remove(tblVariance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblVarianceExists(int? id)
        {
            return _context.TblVariances.Any(e => e.EmployeeId == id);
        }
    }
}

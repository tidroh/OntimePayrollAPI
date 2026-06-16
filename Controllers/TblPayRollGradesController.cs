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
    public class TblPayRollGradesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblPayRollGradesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblPayRollGrades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPayRollGrade>>> GetTblPayRollGrades()
        {
            return await _context.TblPayRollGrades.ToListAsync();
        }

        // GET: api/TblPayRollGrades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPayRollGrade>> GetTblPayRollGrade(decimal? id)
        {
            var tblPayRollGrade = await _context.TblPayRollGrades.FindAsync(id);

            if (tblPayRollGrade == null)
            {
                return NotFound();
            }

            return tblPayRollGrade;
        }

        // PUT: api/TblPayRollGrades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPayRollGrade(decimal? id, TblPayRollGrade tblPayRollGrade)
        {
            if (id != tblPayRollGrade.BasicPayFrom)
            {
                return BadRequest();
            }

            _context.Entry(tblPayRollGrade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPayRollGradeExists(id))
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

        // POST: api/TblPayRollGrades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPayRollGrade>> PostTblPayRollGrade(TblPayRollGrade tblPayRollGrade)
        {
            _context.TblPayRollGrades.Add(tblPayRollGrade);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblPayRollGradeExists(tblPayRollGrade.BasicPayFrom))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblPayRollGrade", new { id = tblPayRollGrade.BasicPayFrom }, tblPayRollGrade);
        }

        // DELETE: api/TblPayRollGrades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPayRollGrade(decimal? id)
        {
            var tblPayRollGrade = await _context.TblPayRollGrades.FindAsync(id);
            if (tblPayRollGrade == null)
            {
                return NotFound();
            }

            _context.TblPayRollGrades.Remove(tblPayRollGrade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPayRollGradeExists(decimal? id)
        {
            return _context.TblPayRollGrades.Any(e => e.BasicPayFrom == id);
        }
    }
}

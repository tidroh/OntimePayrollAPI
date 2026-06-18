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
    public class EmpTermsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public EmpTermsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/EmpTerms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpTerm>>> GetEmpTerms()
        {
            return await _context.EmpTerms.ToListAsync();
        }

        // GET: api/EmpTerms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpTerm>> GetEmpTerm(int id)
        {
            var empTerm = await _context.EmpTerms.FindAsync(id);

            if (empTerm == null)
            {
                return NotFound();
            }

            return empTerm;
        }

        // PUT: api/EmpTerms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpTerm(int id, EmpTerm empTerm)
        {
            if (id != empTerm.TermsId)
            {
                return BadRequest();
            }

            _context.Entry(empTerm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpTermExists(id))
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

        // POST: api/EmpTerms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpTerm>> PostEmpTerm(EmpTerm empTerm)
        {
            _context.EmpTerms.Add(empTerm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpTerm", new { id = empTerm.TermsId }, empTerm);
        }

        // DELETE: api/EmpTerms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpTerm(int id)
        {
            var empTerm = await _context.EmpTerms.FindAsync(id);
            if (empTerm == null)
            {
                return NotFound();
            }

            _context.EmpTerms.Remove(empTerm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpTermExists(int id)
        {
            return _context.EmpTerms.Any(e => e.TermsId == id);
        }
    }
}

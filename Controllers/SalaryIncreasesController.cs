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
    public class SalaryIncreasesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public SalaryIncreasesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/SalaryIncreases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaryIncrease>>> GetSalaryIncreases()
        {
            return await _context.SalaryIncreases.ToListAsync();
        }

        // GET: api/SalaryIncreases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryIncrease>> GetSalaryIncrease(long id)
        {
            var salaryIncrease = await _context.SalaryIncreases.FindAsync(id);

            if (salaryIncrease == null)
            {
                return NotFound();
            }

            return salaryIncrease;
        }

        // PUT: api/SalaryIncreases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaryIncrease(long id, SalaryIncrease salaryIncrease)
        {
            if (id != salaryIncrease.Id)
            {
                return BadRequest();
            }

            _context.Entry(salaryIncrease).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryIncreaseExists(id))
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

        // POST: api/SalaryIncreases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalaryIncrease>> PostSalaryIncrease(SalaryIncrease salaryIncrease)
        {
            _context.SalaryIncreases.Add(salaryIncrease);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalaryIncrease", new { id = salaryIncrease.Id }, salaryIncrease);
        }

        // DELETE: api/SalaryIncreases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalaryIncrease(long id)
        {
            var salaryIncrease = await _context.SalaryIncreases.FindAsync(id);
            if (salaryIncrease == null)
            {
                return NotFound();
            }

            _context.SalaryIncreases.Remove(salaryIncrease);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryIncreaseExists(long id)
        {
            return _context.SalaryIncreases.Any(e => e.Id == id);
        }
    }
}

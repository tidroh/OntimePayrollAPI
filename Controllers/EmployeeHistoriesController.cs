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
    public class EmployeeHistoriesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public EmployeeHistoriesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeHistory>>> GetEmployeeHistories()
        {
            return await _context.EmployeeHistories.ToListAsync();
        }

        // GET: api/EmployeeHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeHistory>> GetEmployeeHistory(long id)
        {
            var employeeHistory = await _context.EmployeeHistories.FindAsync(id);

            if (employeeHistory == null)
            {
                return NotFound();
            }

            return employeeHistory;
        }

        // PUT: api/EmployeeHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeHistory(long id, EmployeeHistory employeeHistory)
        {
            if (id != employeeHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeHistoryExists(id))
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

        // POST: api/EmployeeHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeHistory>> PostEmployeeHistory(EmployeeHistory employeeHistory)
        {
            _context.EmployeeHistories.Add(employeeHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeHistory", new { id = employeeHistory.Id }, employeeHistory);
        }

        // DELETE: api/EmployeeHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeHistory(long id)
        {
            var employeeHistory = await _context.EmployeeHistories.FindAsync(id);
            if (employeeHistory == null)
            {
                return NotFound();
            }

            _context.EmployeeHistories.Remove(employeeHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeHistoryExists(long id)
        {
            return _context.EmployeeHistories.Any(e => e.Id == id);
        }
    }
}

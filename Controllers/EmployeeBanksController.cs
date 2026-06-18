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
    public class EmployeeBanksController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public EmployeeBanksController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeBanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeBank>>> GetEmployeeBanks()
        {
            return await _context.EmployeeBanks.ToListAsync();
        }

        // GET: api/EmployeeBanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeBank>> GetEmployeeBank(int id)
        {
            var employeeBank = await _context.EmployeeBanks.FindAsync(id);

            if (employeeBank == null)
            {
                return NotFound();
            }

            return employeeBank;
        }

        // PUT: api/EmployeeBanks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeBank(int id, EmployeeBank employeeBank)
        {
            if (id != employeeBank.Employeebankid)
            {
                return BadRequest();
            }

            _context.Entry(employeeBank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeBankExists(id))
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

        // POST: api/EmployeeBanks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeBank>> PostEmployeeBank(EmployeeBank employeeBank)
        {
            _context.EmployeeBanks.Add(employeeBank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeBank", new { id = employeeBank.Employeebankid }, employeeBank);
        }

        // DELETE: api/EmployeeBanks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeBank(int id)
        {
            var employeeBank = await _context.EmployeeBanks.FindAsync(id);
            if (employeeBank == null)
            {
                return NotFound();
            }

            _context.EmployeeBanks.Remove(employeeBank);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeBankExists(int id)
        {
            return _context.EmployeeBanks.Any(e => e.Employeebankid == id);
        }
    }
}

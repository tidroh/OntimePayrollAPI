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
    public class TblServiceEmployeesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblServiceEmployeesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblServiceEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblServiceEmployee>>> GetTblServiceEmployees()
        {
            return await _context.TblServiceEmployees.ToListAsync();
        }

        // GET: api/TblServiceEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblServiceEmployee>> GetTblServiceEmployee(int id)
        {
            var tblServiceEmployee = await _context.TblServiceEmployees.FindAsync(id);

            if (tblServiceEmployee == null)
            {
                return NotFound();
            }

            return tblServiceEmployee;
        }

        // PUT: api/TblServiceEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblServiceEmployee(int id, TblServiceEmployee tblServiceEmployee)
        {
            if (id != tblServiceEmployee.EmployeeserviceId)
            {
                return BadRequest();
            }

            _context.Entry(tblServiceEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblServiceEmployeeExists(id))
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

        // POST: api/TblServiceEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblServiceEmployee>> PostTblServiceEmployee(TblServiceEmployee tblServiceEmployee)
        {
            _context.TblServiceEmployees.Add(tblServiceEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblServiceEmployee", new { id = tblServiceEmployee.EmployeeserviceId }, tblServiceEmployee);
        }

        // DELETE: api/TblServiceEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblServiceEmployee(int id)
        {
            var tblServiceEmployee = await _context.TblServiceEmployees.FindAsync(id);
            if (tblServiceEmployee == null)
            {
                return NotFound();
            }

            _context.TblServiceEmployees.Remove(tblServiceEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblServiceEmployeeExists(int id)
        {
            return _context.TblServiceEmployees.Any(e => e.EmployeeserviceId == id);
        }
    }
}

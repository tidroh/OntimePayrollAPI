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
    public class EmpacctsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public EmpacctsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Empaccts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empacct>>> GetEmpaccts()
        {
            return await _context.Empaccts.ToListAsync();
        }

        // GET: api/Empaccts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empacct>> GetEmpacct(long id)
        {
            var empacct = await _context.Empaccts.FindAsync(id);

            if (empacct == null)
            {
                return NotFound();
            }

            return empacct;
        }

        // PUT: api/Empaccts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpacct(long id, Empacct empacct)
        {
            if (id != empacct.Id)
            {
                return BadRequest();
            }

            _context.Entry(empacct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpacctExists(id))
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

        // POST: api/Empaccts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empacct>> PostEmpacct(Empacct empacct)
        {
            _context.Empaccts.Add(empacct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpacct", new { id = empacct.Id }, empacct);
        }

        // DELETE: api/Empaccts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpacct(long id)
        {
            var empacct = await _context.Empaccts.FindAsync(id);
            if (empacct == null)
            {
                return NotFound();
            }

            _context.Empaccts.Remove(empacct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpacctExists(long id)
        {
            return _context.Empaccts.Any(e => e.Id == id);
        }
    }
}

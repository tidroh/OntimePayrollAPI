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
    public class EmpDetsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public EmpDetsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/EmpDets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpDet>>> GetEmpDets()
        {
            return await _context.EmpDets.ToListAsync();
        }

        // GET: api/EmpDets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpDet>> GetEmpDet(string id)
        {
            var empDet = await _context.EmpDets.FindAsync(id);

            if (empDet == null)
            {
                return NotFound();
            }

            return empDet;
        }

        // PUT: api/EmpDets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpDet(string id, EmpDet empDet)
        {
            if (id != empDet.AccountName)
            {
                return BadRequest();
            }

            _context.Entry(empDet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpDetExists(id))
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

        // POST: api/EmpDets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpDet>> PostEmpDet(EmpDet empDet)
        {
            _context.EmpDets.Add(empDet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpDetExists(empDet.AccountName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpDet", new { id = empDet.AccountName }, empDet);
        }

        // DELETE: api/EmpDets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpDet(string id)
        {
            var empDet = await _context.EmpDets.FindAsync(id);
            if (empDet == null)
            {
                return NotFound();
            }

            _context.EmpDets.Remove(empDet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpDetExists(string id)
        {
            return _context.EmpDets.Any(e => e.AccountName == id);
        }
    }
}

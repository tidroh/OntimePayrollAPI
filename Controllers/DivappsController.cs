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
    public class DivappsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public DivappsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Divapps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Divapp>>> GetDivapps()
        {
            return await _context.Divapps.ToListAsync();
        }

        // GET: api/Divapps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Divapp>> GetDivapp(int? id)
        {
            var divapp = await _context.Divapps.FindAsync(id);

            if (divapp == null)
            {
                return NotFound();
            }

            return divapp;
        }

        // PUT: api/Divapps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDivapp(int? id, Divapp divapp)
        {
            if (id != divapp.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(divapp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DivappExists(id))
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

        // POST: api/Divapps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Divapp>> PostDivapp(Divapp divapp)
        {
            _context.Divapps.Add(divapp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDivapp", new { id = divapp.EmployeeId }, divapp);
        }

        // DELETE: api/Divapps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDivapp(int? id)
        {
            var divapp = await _context.Divapps.FindAsync(id);
            if (divapp == null)
            {
                return NotFound();
            }

            _context.Divapps.Remove(divapp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DivappExists(int? id)
        {
            return _context.Divapps.Any(e => e.EmployeeId == id);
        }
    }
}

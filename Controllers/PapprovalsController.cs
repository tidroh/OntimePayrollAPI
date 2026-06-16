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
    public class PapprovalsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public PapprovalsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/Papprovals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Papproval>>> GetPapprovals()
        {
            return await _context.Papprovals.ToListAsync();
        }

        // GET: api/Papprovals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Papproval>> GetPapproval(int? id)
        {
            var papproval = await _context.Papprovals.FindAsync(id);

            if (papproval == null)
            {
                return NotFound();
            }

            return papproval;
        }

        // PUT: api/Papprovals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPapproval(int? id, Papproval papproval)
        {
            if (id != papproval.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(papproval).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PapprovalExists(id))
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

        // POST: api/Papprovals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Papproval>> PostPapproval(Papproval papproval)
        {
            _context.Papprovals.Add(papproval);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPapproval", new { id = papproval.EmployeeId }, papproval);
        }

        // DELETE: api/Papprovals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePapproval(int? id)
        {
            var papproval = await _context.Papprovals.FindAsync(id);
            if (papproval == null)
            {
                return NotFound();
            }

            _context.Papprovals.Remove(papproval);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PapprovalExists(int? id)
        {
            return _context.Papprovals.Any(e => e.EmployeeId == id);
        }
    }
}

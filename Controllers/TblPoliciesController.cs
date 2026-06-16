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
    public class TblPoliciesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblPoliciesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblPolicies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPolicy>>> GetTblPolicies()
        {
            return await _context.TblPolicies.ToListAsync();
        }

        // GET: api/TblPolicies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPolicy>> GetTblPolicy(int id)
        {
            var tblPolicy = await _context.TblPolicies.FindAsync(id);

            if (tblPolicy == null)
            {
                return NotFound();
            }

            return tblPolicy;
        }

        // PUT: api/TblPolicies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPolicy(int id, TblPolicy tblPolicy)
        {
            if (id != tblPolicy.PolicyId)
            {
                return BadRequest();
            }

            _context.Entry(tblPolicy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPolicyExists(id))
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

        // POST: api/TblPolicies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPolicy>> PostTblPolicy(TblPolicy tblPolicy)
        {
            _context.TblPolicies.Add(tblPolicy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPolicy", new { id = tblPolicy.PolicyId }, tblPolicy);
        }

        // DELETE: api/TblPolicies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPolicy(int id)
        {
            var tblPolicy = await _context.TblPolicies.FindAsync(id);
            if (tblPolicy == null)
            {
                return NotFound();
            }

            _context.TblPolicies.Remove(tblPolicy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPolicyExists(int id)
        {
            return _context.TblPolicies.Any(e => e.PolicyId == id);
        }
    }
}

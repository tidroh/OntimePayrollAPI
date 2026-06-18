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
    public class CompanyAssetIssuesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public CompanyAssetIssuesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/CompanyAssetIssues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyAssetIssue>>> GetCompanyAssetIssues()
        {
            return await _context.CompanyAssetIssues.ToListAsync();
        }

        // GET: api/CompanyAssetIssues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyAssetIssue>> GetCompanyAssetIssue(long id)
        {
            var companyAssetIssue = await _context.CompanyAssetIssues.FindAsync(id);

            if (companyAssetIssue == null)
            {
                return NotFound();
            }

            return companyAssetIssue;
        }

        // PUT: api/CompanyAssetIssues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyAssetIssue(long id, CompanyAssetIssue companyAssetIssue)
        {
            if (id != companyAssetIssue.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyAssetIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyAssetIssueExists(id))
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

        // POST: api/CompanyAssetIssues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyAssetIssue>> PostCompanyAssetIssue(CompanyAssetIssue companyAssetIssue)
        {
            _context.CompanyAssetIssues.Add(companyAssetIssue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyAssetIssue", new { id = companyAssetIssue.Id }, companyAssetIssue);
        }

        // DELETE: api/CompanyAssetIssues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyAssetIssue(long id)
        {
            var companyAssetIssue = await _context.CompanyAssetIssues.FindAsync(id);
            if (companyAssetIssue == null)
            {
                return NotFound();
            }

            _context.CompanyAssetIssues.Remove(companyAssetIssue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyAssetIssueExists(long id)
        {
            return _context.CompanyAssetIssues.Any(e => e.Id == id);
        }
    }
}

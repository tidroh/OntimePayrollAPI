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
    public class CompanyAssetsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public CompanyAssetsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/CompanyAssets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyAsset>>> GetCompanyAssets()
        {
            return await _context.CompanyAssets.ToListAsync();
        }

        // GET: api/CompanyAssets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyAsset>> GetCompanyAsset(long id)
        {
            var companyAsset = await _context.CompanyAssets.FindAsync(id);

            if (companyAsset == null)
            {
                return NotFound();
            }

            return companyAsset;
        }

        // PUT: api/CompanyAssets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyAsset(long id, CompanyAsset companyAsset)
        {
            if (id != companyAsset.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyAsset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyAssetExists(id))
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

        // POST: api/CompanyAssets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyAsset>> PostCompanyAsset(CompanyAsset companyAsset)
        {
            _context.CompanyAssets.Add(companyAsset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyAsset", new { id = companyAsset.Id }, companyAsset);
        }

        // DELETE: api/CompanyAssets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyAsset(long id)
        {
            var companyAsset = await _context.CompanyAssets.FindAsync(id);
            if (companyAsset == null)
            {
                return NotFound();
            }

            _context.CompanyAssets.Remove(companyAsset);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyAssetExists(long id)
        {
            return _context.CompanyAssets.Any(e => e.Id == id);
        }
    }
}

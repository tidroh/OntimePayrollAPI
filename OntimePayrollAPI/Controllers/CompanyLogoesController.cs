using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

namespace OntimePayrollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyLogosController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public CompanyLogosController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/CompanyLogos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyLogo>>> GetCompanyLogos()
        {
            return await _context.CompanyLogos.ToListAsync();
        }

        // POST: api/CompanyLogos
        [HttpPost]
        public async Task<ActionResult<CompanyLogo>> PostCompanyLogo(CompanyLogo companyLogo)
        {
            _context.CompanyLogos.Add(companyLogo);
            await _context.SaveChangesAsync();

            return Ok(companyLogo);
        }
    }
}
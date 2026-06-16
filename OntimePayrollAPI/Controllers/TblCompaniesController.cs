using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblCompaniesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblCompaniesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblCompany
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblCompany>>> GetTblCompany()
    {
        return await _context.TblCompanies.ToListAsync();
    }

    // GET: api/TblCompany/5
    [HttpGet("{companyid}")]
    public async Task<ActionResult<TblCompany>> GetTblCompany(int companyid)
    {
        var tblcompany = await _context.TblCompanies.FindAsync(companyid);

        if (tblcompany == null)
        {
            return NotFound();
        }

        return tblcompany;
    }

    // PUT: api/TblCompany/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{companyid}")]
    public async Task<IActionResult> PutTblCompany(int? companyid, TblCompany tblcompany)
    {
        if (companyid != tblcompany.CompanyId)
        {
            return BadRequest();
        }

        _context.Entry(tblcompany).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblCompanyExists(companyid))
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

    // POST: api/TblCompany
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblCompany>> PostTblCompany(TblCompany tblcompany)
    {
        _context.TblCompanies.Add(tblcompany);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblCompany", new { companyid = tblcompany.CompanyId }, tblcompany);
    }

    // DELETE: api/TblCompany/5
    [HttpDelete("{companyid}")]
    public async Task<IActionResult> DeleteTblCompany(int? companyid)
    {
        var tblcompany = await _context.TblCompanies.FindAsync(companyid);
        if (tblcompany == null)
        {
            return NotFound();
        }

        _context.TblCompanies.Remove(tblcompany);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblCompanyExists(int? companyid)
    {
        return _context.TblCompanies.Any(e => e.CompanyId == companyid);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblInsuranceCompaniesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblInsuranceCompaniesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblInsuranceCompany
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblInsuranceCompany>>> GetTblInsuranceCompany()
    {
        return await _context.TblInsuranceCompanies.ToListAsync();
    }

    // GET: api/TblInsuranceCompany/5
    [HttpGet("{insid}")]
    public async Task<ActionResult<TblInsuranceCompany>> GetTblInsuranceCompany(int insid)
    {
        var tblinsurancecompany = await _context.TblInsuranceCompanies.FindAsync(insid);

        if (tblinsurancecompany == null)
        {
            return NotFound();
        }

        return tblinsurancecompany;
    }

    // PUT: api/TblInsuranceCompany/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{insid}")]
    public async Task<IActionResult> PutTblInsuranceCompany(int? insid, TblInsuranceCompany tblinsurancecompany)
    {
        if (insid != tblinsurancecompany.InsId)
        {
            return BadRequest();
        }

        _context.Entry(tblinsurancecompany).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblInsuranceCompanyExists(insid))
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

    // POST: api/TblInsuranceCompany
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblInsuranceCompany>> PostTblInsuranceCompany(TblInsuranceCompany tblinsurancecompany)
    {
        _context.TblInsuranceCompanies.Add(tblinsurancecompany);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblInsuranceCompany", new { insid = tblinsurancecompany.InsId }, tblinsurancecompany);
    }

    // DELETE: api/TblInsuranceCompany/5
    [HttpDelete("{insid}")]
    public async Task<IActionResult> DeleteTblInsuranceCompany(int? insid)
    {
        var tblinsurancecompany = await _context.TblInsuranceCompanies.FindAsync(insid);
        if (tblinsurancecompany == null)
        {
            return NotFound();
        }

        _context.TblInsuranceCompanies.Remove(tblinsurancecompany);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblInsuranceCompanyExists(int? insid)
    {
        return _context.TblInsuranceCompanies.Any(e => e.InsId == insid);
    }
}

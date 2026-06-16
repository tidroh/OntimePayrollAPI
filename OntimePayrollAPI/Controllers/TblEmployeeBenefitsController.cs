using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeBenefitsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeBenefitsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeBenefit
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeBenefit>>> GetTblEmployeeBenefit()
    {
        return await _context.TblEmployeeBenefits.ToListAsync();
    }

    // GET: api/TblEmployeeBenefit/5
    [HttpGet("{employeetransid}")]
    public async Task<ActionResult<TblEmployeeBenefit>> GetTblEmployeeBenefit(int employeetransid)
    {
        var tblemployeebenefit = await _context.TblEmployeeBenefits.FindAsync(employeetransid);

        if (tblemployeebenefit == null)
        {
            return NotFound();
        }

        return tblemployeebenefit;
    }

    // PUT: api/TblEmployeeBenefit/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{employeetransid}")]
    public async Task<IActionResult> PutTblEmployeeBenefit(int? employeetransid, TblEmployeeBenefit tblemployeebenefit)
    {
        if (employeetransid != tblemployeebenefit.EmployeetransId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeebenefit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeBenefitExists(employeetransid))
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

    // POST: api/TblEmployeeBenefit
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeBenefit>> PostTblEmployeeBenefit(TblEmployeeBenefit tblemployeebenefit)
    {
        _context.TblEmployeeBenefits.Add(tblemployeebenefit);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeBenefit", new { employeetransid = tblemployeebenefit.EmployeetransId }, tblemployeebenefit);
    }

    // DELETE: api/TblEmployeeBenefit/5
    [HttpDelete("{employeetransid}")]
    public async Task<IActionResult> DeleteTblEmployeeBenefit(int? employeetransid)
    {
        var tblemployeebenefit = await _context.TblEmployeeBenefits.FindAsync(employeetransid);
        if (tblemployeebenefit == null)
        {
            return NotFound();
        }

        _context.TblEmployeeBenefits.Remove(tblemployeebenefit);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeBenefitExists(int? employeetransid)
    {
        return _context.TblEmployeeBenefits.Any(e => e.EmployeetransId == employeetransid);
    }
}

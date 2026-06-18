using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeDefinedBenefitsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeDefinedBenefitsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeDefinedBenefit
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeDefinedBenefit>>> GetTblEmployeeDefinedBenefit()
    {
        return await _context.TblEmployeeDefinedBenefits.ToListAsync();
    }

    // GET: api/TblEmployeeDefinedBenefit/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblEmployeeDefinedBenefit>> GetTblEmployeeDefinedBenefit(int id)
    {
        var tblemployeedefinedbenefit = await _context.TblEmployeeDefinedBenefits.FindAsync(id);

        if (tblemployeedefinedbenefit == null)
        {
            return NotFound();
        }

        return tblemployeedefinedbenefit;
    }

    // PUT: api/TblEmployeeDefinedBenefit/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblEmployeeDefinedBenefit(int? id, TblEmployeeDefinedBenefit tblemployeedefinedbenefit)
    {
        if (id != tblemployeedefinedbenefit.Id)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeedefinedbenefit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeDefinedBenefitExists(id))
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

    // POST: api/TblEmployeeDefinedBenefit
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeDefinedBenefit>> PostTblEmployeeDefinedBenefit(TblEmployeeDefinedBenefit tblemployeedefinedbenefit)
    {
        _context.TblEmployeeDefinedBenefits.Add(tblemployeedefinedbenefit);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeDefinedBenefit", new { id = tblemployeedefinedbenefit.Id }, tblemployeedefinedbenefit);
    }

    // DELETE: api/TblEmployeeDefinedBenefit/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblEmployeeDefinedBenefit(int? id)
    {
        var tblemployeedefinedbenefit = await _context.TblEmployeeDefinedBenefits.FindAsync(id);
        if (tblemployeedefinedbenefit == null)
        {
            return NotFound();
        }

        _context.TblEmployeeDefinedBenefits.Remove(tblemployeedefinedbenefit);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeDefinedBenefitExists(int? id)
    {
        return _context.TblEmployeeDefinedBenefits.Any(e => e.Id == id);
    }
}

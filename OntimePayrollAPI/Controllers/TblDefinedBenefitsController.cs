using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblDefinedBenefitsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblDefinedBenefitsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblDefinedBenefit
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblDefinedBenefit>>> GetTblDefinedBenefit()
    {
        return await _context.TblDefinedBenefits.ToListAsync();
    }

    // GET: api/TblDefinedBenefit/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblDefinedBenefit>> GetTblDefinedBenefit(int id)
    {
        var tbldefinedbenefit = await _context.TblDefinedBenefits.FindAsync(id);

        if (tbldefinedbenefit == null)
        {
            return NotFound();
        }

        return tbldefinedbenefit;
    }

    // PUT: api/TblDefinedBenefit/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblDefinedBenefit(int? id, TblDefinedBenefit tbldefinedbenefit)
    {
        if (id != tbldefinedbenefit.Id)
        {
            return BadRequest();
        }

        _context.Entry(tbldefinedbenefit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblDefinedBenefitExists(id))
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

    // POST: api/TblDefinedBenefit
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblDefinedBenefit>> PostTblDefinedBenefit(TblDefinedBenefit tbldefinedbenefit)
    {
        _context.TblDefinedBenefits.Add(tbldefinedbenefit);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblDefinedBenefit", new { id = tbldefinedbenefit.Id }, tbldefinedbenefit);
    }

    // DELETE: api/TblDefinedBenefit/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblDefinedBenefit(int? id)
    {
        var tbldefinedbenefit = await _context.TblDefinedBenefits.FindAsync(id);
        if (tbldefinedbenefit == null)
        {
            return NotFound();
        }

        _context.TblDefinedBenefits.Remove(tbldefinedbenefit);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblDefinedBenefitExists(int? id)
    {
        return _context.TblDefinedBenefits.Any(e => e.Id == id);
    }
}

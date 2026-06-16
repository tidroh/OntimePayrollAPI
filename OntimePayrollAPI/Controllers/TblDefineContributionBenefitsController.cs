using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblDefineContributionBenefitsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblDefineContributionBenefitsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblDefineContributionBenefit
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblDefineContributionBenefit>>> GetTblDefineContributionBenefit()
    {
        return await _context.TblDefineContributionBenefits.ToListAsync();
    }

    // GET: api/TblDefineContributionBenefit/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblDefineContributionBenefit>> GetTblDefineContributionBenefit(int id)
    {
        var tbldefinecontributionbenefit = await _context.TblDefineContributionBenefits.FindAsync(id);

        if (tbldefinecontributionbenefit == null)
        {
            return NotFound();
        }

        return tbldefinecontributionbenefit;
    }

    // PUT: api/TblDefineContributionBenefit/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblDefineContributionBenefit(int? id, TblDefineContributionBenefit tbldefinecontributionbenefit)
    {
        if (id != tbldefinecontributionbenefit.Id)
        {
            return BadRequest();
        }

        _context.Entry(tbldefinecontributionbenefit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblDefineContributionBenefitExists(id))
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

    // POST: api/TblDefineContributionBenefit
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblDefineContributionBenefit>> PostTblDefineContributionBenefit(TblDefineContributionBenefit tbldefinecontributionbenefit)
    {
        _context.TblDefineContributionBenefits.Add(tbldefinecontributionbenefit);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblDefineContributionBenefit", new { id = tbldefinecontributionbenefit.Id }, tbldefinecontributionbenefit);
    }

    // DELETE: api/TblDefineContributionBenefit/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblDefineContributionBenefit(int? id)
    {
        var tbldefinecontributionbenefit = await _context.TblDefineContributionBenefits.FindAsync(id);
        if (tbldefinecontributionbenefit == null)
        {
            return NotFound();
        }

        _context.TblDefineContributionBenefits.Remove(tbldefinecontributionbenefit);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblDefineContributionBenefitExists(int? id)
    {
        return _context.TblDefineContributionBenefits.Any(e => e.Id == id);
    }
}

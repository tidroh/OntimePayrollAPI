using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblDefineCintributionBenefitsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblDefineCintributionBenefitsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblDefineCintributionBenefit
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblDefineCintributionBenefit>>> GetTblDefineCintributionBenefit()
    {
        return await _context.TblDefineCintributionBenefits.ToListAsync();
    }

    // GET: api/TblDefineCintributionBenefit/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblDefineCintributionBenefit>> GetTblDefineCintributionBenefit(int id)
    {
        var tbldefinecintributionbenefit = await _context.TblDefineCintributionBenefits.FindAsync(id);

        if (tbldefinecintributionbenefit == null)
        {
            return NotFound();
        }

        return tbldefinecintributionbenefit;
    }

    // PUT: api/TblDefineCintributionBenefit/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblDefineCintributionBenefit(int? id, TblDefineCintributionBenefit tbldefinecintributionbenefit)
    {
        if (id != tbldefinecintributionbenefit.Id)
        {
            return BadRequest();
        }

        _context.Entry(tbldefinecintributionbenefit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblDefineCintributionBenefitExists(id))
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

    // POST: api/TblDefineCintributionBenefit
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblDefineCintributionBenefit>> PostTblDefineCintributionBenefit(TblDefineCintributionBenefit tbldefinecintributionbenefit)
    {
        _context.TblDefineCintributionBenefits.Add(tbldefinecintributionbenefit);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblDefineCintributionBenefit", new { id = tbldefinecintributionbenefit.Id }, tbldefinecintributionbenefit);
    }

    // DELETE: api/TblDefineCintributionBenefit/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblDefineCintributionBenefit(int? id)
    {
        var tbldefinecintributionbenefit = await _context.TblDefineCintributionBenefits.FindAsync(id);
        if (tbldefinecintributionbenefit == null)
        {
            return NotFound();
        }

        _context.TblDefineCintributionBenefits.Remove(tbldefinecintributionbenefit);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblDefineCintributionBenefitExists(int? id)
    {
        return _context.TblDefineCintributionBenefits.Any(e => e.Id == id);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblCasualPaymentCriterionsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblCasualPaymentCriterionsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblCasualPaymentCriterion
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblCasualPaymentCriterion>>> GetTblCasualPaymentCriterion()
    {
        return await _context.TblCasualPaymentCriteria.ToListAsync();
    }

    // GET: api/TblCasualPaymentCriterion/5
    [HttpGet("{criteriaid}")]
    public async Task<ActionResult<TblCasualPaymentCriterion>> GetTblCasualPaymentCriterion(int criteriaid)
    {
        var tblcasualpaymentcriterion = await _context.TblCasualPaymentCriteria.FindAsync(criteriaid);

        if (tblcasualpaymentcriterion == null)
        {
            return NotFound();
        }

        return tblcasualpaymentcriterion;
    }

    // PUT: api/TblCasualPaymentCriterion/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{criteriaid}")]
    public async Task<IActionResult> PutTblCasualPaymentCriterion(int? criteriaid, TblCasualPaymentCriterion tblcasualpaymentcriterion)
    {
        if (criteriaid != tblcasualpaymentcriterion.CriteriaId)
        {
            return BadRequest();
        }

        _context.Entry(tblcasualpaymentcriterion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblCasualPaymentCriterionExists(criteriaid))
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

    // POST: api/TblCasualPaymentCriterion
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblCasualPaymentCriterion>> PostTblCasualPaymentCriterion(TblCasualPaymentCriterion tblcasualpaymentcriterion)
    {
        _context.TblCasualPaymentCriteria.Add(tblcasualpaymentcriterion);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblCasualPaymentCriterion", new { criteriaid = tblcasualpaymentcriterion.CriteriaId }, tblcasualpaymentcriterion);
    }

    // DELETE: api/TblCasualPaymentCriterion/5
    [HttpDelete("{criteriaid}")]
    public async Task<IActionResult> DeleteTblCasualPaymentCriterion(int? criteriaid)
    {
        var tblcasualpaymentcriterion = await _context.TblCasualPaymentCriteria.FindAsync(criteriaid);
        if (tblcasualpaymentcriterion == null)
        {
            return NotFound();
        }

        _context.TblCasualPaymentCriteria.Remove(tblcasualpaymentcriterion);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblCasualPaymentCriterionExists(int? criteriaid)
    {
        return _context.TblCasualPaymentCriteria.Any(e => e.CriteriaId == criteriaid);
    }
}

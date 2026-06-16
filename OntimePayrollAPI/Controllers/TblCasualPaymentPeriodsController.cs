using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblCasualPaymentPeriodsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblCasualPaymentPeriodsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblCasualPaymentPeriod
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblCasualPaymentPeriod>>> GetTblCasualPaymentPeriod()
    {
        return await _context.TblCasualPaymentPeriods.ToListAsync();
    }

    // GET: api/TblCasualPaymentPeriod/5
    [HttpGet("{periodid}")]
    public async Task<ActionResult<TblCasualPaymentPeriod>> GetTblCasualPaymentPeriod(int periodid)
    {
        var tblcasualpaymentperiod = await _context.TblCasualPaymentPeriods.FindAsync(periodid);

        if (tblcasualpaymentperiod == null)
        {
            return NotFound();
        }

        return tblcasualpaymentperiod;
    }

    // PUT: api/TblCasualPaymentPeriod/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{periodid}")]
    public async Task<IActionResult> PutTblCasualPaymentPeriod(int? periodid, TblCasualPaymentPeriod tblcasualpaymentperiod)
    {
        if (periodid != tblcasualpaymentperiod.PeriodId)
        {
            return BadRequest();
        }

        _context.Entry(tblcasualpaymentperiod).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblCasualPaymentPeriodExists(periodid))
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

    // POST: api/TblCasualPaymentPeriod
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblCasualPaymentPeriod>> PostTblCasualPaymentPeriod(TblCasualPaymentPeriod tblcasualpaymentperiod)
    {
        _context.TblCasualPaymentPeriods.Add(tblcasualpaymentperiod);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblCasualPaymentPeriod", new { periodid = tblcasualpaymentperiod.PeriodId }, tblcasualpaymentperiod);
    }

    // DELETE: api/TblCasualPaymentPeriod/5
    [HttpDelete("{periodid}")]
    public async Task<IActionResult> DeleteTblCasualPaymentPeriod(int? periodid)
    {
        var tblcasualpaymentperiod = await _context.TblCasualPaymentPeriods.FindAsync(periodid);
        if (tblcasualpaymentperiod == null)
        {
            return NotFound();
        }

        _context.TblCasualPaymentPeriods.Remove(tblcasualpaymentperiod);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblCasualPaymentPeriodExists(int? periodid)
    {
        return _context.TblCasualPaymentPeriods.Any(e => e.PeriodId == periodid);
    }
}

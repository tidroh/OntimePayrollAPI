using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblLoanAdjustmentsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblLoanAdjustmentsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblLoanAdjustment
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblLoanAdjustment>>> GetTblLoanAdjustment()
    {
        return await _context.TblLoanAdjustments.ToListAsync();
    }

    // GET: api/TblLoanAdjustment/5
    [HttpGet("{loanadjustmentid}")]
    public async Task<ActionResult<TblLoanAdjustment>> GetTblLoanAdjustment(int loanadjustmentid)
    {
        var tblloanadjustment = await _context.TblLoanAdjustments.FindAsync(loanadjustmentid);

        if (tblloanadjustment == null)
        {
            return NotFound();
        }

        return tblloanadjustment;
    }

    // PUT: api/TblLoanAdjustment/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{loanadjustmentid}")]
    public async Task<IActionResult> PutTblLoanAdjustment(int? loanadjustmentid, TblLoanAdjustment tblloanadjustment)
    {
        if (loanadjustmentid != tblloanadjustment.LoanAdjustmentId)
        {
            return BadRequest();
        }

        _context.Entry(tblloanadjustment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblLoanAdjustmentExists(loanadjustmentid))
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

    // POST: api/TblLoanAdjustment
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblLoanAdjustment>> PostTblLoanAdjustment(TblLoanAdjustment tblloanadjustment)
    {
        _context.TblLoanAdjustments.Add(tblloanadjustment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblLoanAdjustment", new { loanadjustmentid = tblloanadjustment.LoanAdjustmentId }, tblloanadjustment);
    }

    // DELETE: api/TblLoanAdjustment/5
    [HttpDelete("{loanadjustmentid}")]
    public async Task<IActionResult> DeleteTblLoanAdjustment(int? loanadjustmentid)
    {
        var tblloanadjustment = await _context.TblLoanAdjustments.FindAsync(loanadjustmentid);
        if (tblloanadjustment == null)
        {
            return NotFound();
        }

        _context.TblLoanAdjustments.Remove(tblloanadjustment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblLoanAdjustmentExists(int? loanadjustmentid)
    {
        return _context.TblLoanAdjustments.Any(e => e.LoanAdjustmentId == loanadjustmentid);
    }
}

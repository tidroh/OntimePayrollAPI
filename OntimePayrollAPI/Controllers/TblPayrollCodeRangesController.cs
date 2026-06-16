using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblPayrollCodeRangesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblPayrollCodeRangesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblPayrollCodeRange
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblPayrollCodeRange>>> GetTblPayrollCodeRange()
    {
        return await _context.TblPayrollCodeRanges.ToListAsync();
    }

    // GET: api/TblPayrollCodeRange/5
    [HttpGet("{payrollcoderangeid}")]
    public async Task<ActionResult<TblPayrollCodeRange>> GetTblPayrollCodeRange(int payrollcoderangeid)
    {
        var tblpayrollcoderange = await _context.TblPayrollCodeRanges.FindAsync(payrollcoderangeid);

        if (tblpayrollcoderange == null)
        {
            return NotFound();
        }

        return tblpayrollcoderange;
    }

    // PUT: api/TblPayrollCodeRange/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{payrollcoderangeid}")]
    public async Task<IActionResult> PutTblPayrollCodeRange(int? payrollcoderangeid, TblPayrollCodeRange tblpayrollcoderange)
    {
        if (payrollcoderangeid != tblpayrollcoderange.PayrollcodeRangeId)
        {
            return BadRequest();
        }

        _context.Entry(tblpayrollcoderange).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblPayrollCodeRangeExists(payrollcoderangeid))
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

    // POST: api/TblPayrollCodeRange
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblPayrollCodeRange>> PostTblPayrollCodeRange(TblPayrollCodeRange tblpayrollcoderange)
    {
        _context.TblPayrollCodeRanges.Add(tblpayrollcoderange);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblPayrollCodeRange", new { payrollcoderangeid = tblpayrollcoderange.PayrollcodeRangeId }, tblpayrollcoderange);
    }

    // DELETE: api/TblPayrollCodeRange/5
    [HttpDelete("{payrollcoderangeid}")]
    public async Task<IActionResult> DeleteTblPayrollCodeRange(int? payrollcoderangeid)
    {
        var tblpayrollcoderange = await _context.TblPayrollCodeRanges.FindAsync(payrollcoderangeid);
        if (tblpayrollcoderange == null)
        {
            return NotFound();
        }

        _context.TblPayrollCodeRanges.Remove(tblpayrollcoderange);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblPayrollCodeRangeExists(int? payrollcoderangeid)
    {
        return _context.TblPayrollCodeRanges.Any(e => e.PayrollcodeRangeId == payrollcoderangeid);
    }
}

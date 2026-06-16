using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblPayrollsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblPayrollsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblPayroll
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblPayroll>>> GetTblPayroll()
    {
        return await _context.TblPayrolls.ToListAsync();
    }

    // GET: api/TblPayroll/5
    [HttpGet("{payrollid}")]
    public async Task<ActionResult<TblPayroll>> GetTblPayroll(int payrollid)
    {
        var tblpayroll = await _context.TblPayrolls.FindAsync(payrollid);

        if (tblpayroll == null)
        {
            return NotFound();
        }

        return tblpayroll;
    }

    // PUT: api/TblPayroll/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{payrollid}")]
    public async Task<IActionResult> PutTblPayroll(int? payrollid, TblPayroll tblpayroll)
    {
        if (payrollid != tblpayroll.PayrollId)
        {
            return BadRequest();
        }

        _context.Entry(tblpayroll).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblPayrollExists(payrollid))
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

    // POST: api/TblPayroll
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblPayroll>> PostTblPayroll(TblPayroll tblpayroll)
    {
        _context.TblPayrolls.Add(tblpayroll);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblPayroll", new { payrollid = tblpayroll.PayrollId }, tblpayroll);
    }

    // DELETE: api/TblPayroll/5
    [HttpDelete("{payrollid}")]
    public async Task<IActionResult> DeleteTblPayroll(int? payrollid)
    {
        var tblpayroll = await _context.TblPayrolls.FindAsync(payrollid);
        if (tblpayroll == null)
        {
            return NotFound();
        }

        _context.TblPayrolls.Remove(tblpayroll);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblPayrollExists(int? payrollid)
    {
        return _context.TblPayrolls.Any(e => e.PayrollId == payrollid);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblPayrollCodes1Controller : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblPayrollCodes1Controller(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblPayrollCode
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblPayrollCode>>> GetTblPayrollCode()
    {
        return await _context.TblPayrollCodes.ToListAsync();
    }

    // GET: api/TblPayrollCode/5
    [HttpGet("{payrollcodeid}")]
    public async Task<ActionResult<TblPayrollCode>> GetTblPayrollCode(int payrollcodeid)
    {
        var tblpayrollcode = await _context.TblPayrollCodes.FindAsync(payrollcodeid);

        if (tblpayrollcode == null)
        {
            return NotFound();
        }

        return tblpayrollcode;
    }

    // PUT: api/TblPayrollCode/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{payrollcodeid}")]
    public async Task<IActionResult> PutTblPayrollCode(int? payrollcodeid, TblPayrollCode tblpayrollcode)
    {
        if (payrollcodeid != tblpayrollcode.PayrollcodeId)
        {
            return BadRequest();
        }

        _context.Entry(tblpayrollcode).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblPayrollCodeExists(payrollcodeid))
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

    // POST: api/TblPayrollCode
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblPayrollCode>> PostTblPayrollCode(TblPayrollCode tblpayrollcode)
    {
        _context.TblPayrollCodes.Add(tblpayrollcode);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblPayrollCode", new { payrollcodeid = tblpayrollcode.PayrollcodeId }, tblpayrollcode);
    }

    // DELETE: api/TblPayrollCode/5
    [HttpDelete("{payrollcodeid}")]
    public async Task<IActionResult> DeleteTblPayrollCode(int? payrollcodeid)
    {
        var tblpayrollcode = await _context.TblPayrollCodes.FindAsync(payrollcodeid);
        if (tblpayrollcode == null)
        {
            return NotFound();
        }

        _context.TblPayrollCodes.Remove(tblpayrollcode);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblPayrollCodeExists(int? payrollcodeid)
    {
        return _context.TblPayrollCodes.Any(e => e.PayrollcodeId == payrollcodeid);
    }
}

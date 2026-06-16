using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeLoansController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeLoansController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeLoan
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeLoan>>> GetTblEmployeeLoan()
    {
        return await _context.TblEmployeeLoans.ToListAsync();
    }

    // GET: api/TblEmployeeLoan/5
    [HttpGet("{employeeloanid}")]
    public async Task<ActionResult<TblEmployeeLoan>> GetTblEmployeeLoan(int employeeloanid)
    {
        var tblemployeeloan = await _context.TblEmployeeLoans.FindAsync(employeeloanid);

        if (tblemployeeloan == null)
        {
            return NotFound();
        }

        return tblemployeeloan;
    }

    // PUT: api/TblEmployeeLoan/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{employeeloanid}")]
    public async Task<IActionResult> PutTblEmployeeLoan(int? employeeloanid, TblEmployeeLoan tblemployeeloan)
    {
        if (employeeloanid != tblemployeeloan.EmployeeloanId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeeloan).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeLoanExists(employeeloanid))
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

    // POST: api/TblEmployeeLoan
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeLoan>> PostTblEmployeeLoan(TblEmployeeLoan tblemployeeloan)
    {
        _context.TblEmployeeLoans.Add(tblemployeeloan);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeLoan", new { employeeloanid = tblemployeeloan.EmployeeloanId }, tblemployeeloan);
    }

    // DELETE: api/TblEmployeeLoan/5
    [HttpDelete("{employeeloanid}")]
    public async Task<IActionResult> DeleteTblEmployeeLoan(int? employeeloanid)
    {
        var tblemployeeloan = await _context.TblEmployeeLoans.FindAsync(employeeloanid);
        if (tblemployeeloan == null)
        {
            return NotFound();
        }

        _context.TblEmployeeLoans.Remove(tblemployeeloan);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeLoanExists(int? employeeloanid)
    {
        return _context.TblEmployeeLoans.Any(e => e.EmployeeloanId == employeeloanid);
    }
}

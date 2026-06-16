using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeAllowancesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeAllowancesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeAllowance
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeAllowance>>> GetTblEmployeeAllowance()
    {
        return await _context.TblEmployeeAllowances.ToListAsync();
    }

    // GET: api/TblEmployeeAllowance/5
    [HttpGet("{employeeallowanceid}")]
    public async Task<ActionResult<TblEmployeeAllowance>> GetTblEmployeeAllowance(int employeeallowanceid)
    {
        var tblemployeeallowance = await _context.TblEmployeeAllowances.FindAsync(employeeallowanceid);

        if (tblemployeeallowance == null)
        {
            return NotFound();
        }

        return tblemployeeallowance;
    }

    // PUT: api/TblEmployeeAllowance/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{employeeallowanceid}")]
    public async Task<IActionResult> PutTblEmployeeAllowance(int? employeeallowanceid, TblEmployeeAllowance tblemployeeallowance)
    {
        if (employeeallowanceid != tblemployeeallowance.EmployeeallowanceId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeeallowance).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeAllowanceExists(employeeallowanceid))
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

    // POST: api/TblEmployeeAllowance
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeAllowance>> PostTblEmployeeAllowance(TblEmployeeAllowance tblemployeeallowance)
    {
        _context.TblEmployeeAllowances.Add(tblemployeeallowance);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeAllowance", new { employeeallowanceid = tblemployeeallowance.EmployeeallowanceId }, tblemployeeallowance);
    }

    // DELETE: api/TblEmployeeAllowance/5
    [HttpDelete("{employeeallowanceid}")]
    public async Task<IActionResult> DeleteTblEmployeeAllowance(int? employeeallowanceid)
    {
        var tblemployeeallowance = await _context.TblEmployeeAllowances.FindAsync(employeeallowanceid);
        if (tblemployeeallowance == null)
        {
            return NotFound();
        }

        _context.TblEmployeeAllowances.Remove(tblemployeeallowance);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeAllowanceExists(int? employeeallowanceid)
    {
        return _context.TblEmployeeAllowances.Any(e => e.EmployeeallowanceId == employeeallowanceid);
    }
}

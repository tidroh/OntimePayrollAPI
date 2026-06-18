using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeBasicSalariesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeBasicSalariesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeBasicSalary
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeBasicSalary>>> GetTblEmployeeBasicSalary()
    {
        return await _context.TblEmployeeBasicSalaries.ToListAsync();
    }

    // GET: api/TblEmployeeBasicSalary/5
    [HttpGet("{basicsalaryid}")]
    public async Task<ActionResult<TblEmployeeBasicSalary>> GetTblEmployeeBasicSalary(int basicsalaryid)
    {
        var tblemployeebasicsalary = await _context.TblEmployeeBasicSalaries.FindAsync(basicsalaryid);

        if (tblemployeebasicsalary == null)
        {
            return NotFound();
        }

        return tblemployeebasicsalary;
    }

    // PUT: api/TblEmployeeBasicSalary/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{basicsalaryid}")]
    public async Task<IActionResult> PutTblEmployeeBasicSalary(int? basicsalaryid, TblEmployeeBasicSalary tblemployeebasicsalary)
    {
        if (basicsalaryid != tblemployeebasicsalary.BasicsalaryId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeebasicsalary).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeBasicSalaryExists(basicsalaryid))
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

    // POST: api/TblEmployeeBasicSalary
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeBasicSalary>> PostTblEmployeeBasicSalary(TblEmployeeBasicSalary tblemployeebasicsalary)
    {
        _context.TblEmployeeBasicSalaries.Add(tblemployeebasicsalary);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeBasicSalary", new { basicsalaryid = tblemployeebasicsalary.BasicsalaryId }, tblemployeebasicsalary);
    }

    // DELETE: api/TblEmployeeBasicSalary/5
    [HttpDelete("{basicsalaryid}")]
    public async Task<IActionResult> DeleteTblEmployeeBasicSalary(int? basicsalaryid)
    {
        var tblemployeebasicsalary = await _context.TblEmployeeBasicSalaries.FindAsync(basicsalaryid);
        if (tblemployeebasicsalary == null)
        {
            return NotFound();
        }

        _context.TblEmployeeBasicSalaries.Remove(tblemployeebasicsalary);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeBasicSalaryExists(int? basicsalaryid)
    {
        return _context.TblEmployeeBasicSalaries.Any(e => e.BasicsalaryId == basicsalaryid);
    }
}

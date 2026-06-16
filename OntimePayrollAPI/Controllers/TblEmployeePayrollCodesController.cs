using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeePayrollCodesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeePayrollCodesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeePayrollCode
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeePayrollCode>>> GetTblEmployeePayrollCode()
    {
        return await _context.TblEmployeePayrollCodes.ToListAsync();
    }

    // GET: api/TblEmployeePayrollCode/5
    [HttpGet("{employeecodeid}")]
    public async Task<ActionResult<TblEmployeePayrollCode>> GetTblEmployeePayrollCode(long employeecodeid)
    {
        var tblemployeepayrollcode = await _context.TblEmployeePayrollCodes.FindAsync(employeecodeid);

        if (tblemployeepayrollcode == null)
        {
            return NotFound();
        }

        return tblemployeepayrollcode;
    }

    // PUT: api/TblEmployeePayrollCode/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{employeecodeid}")]
    public async Task<IActionResult> PutTblEmployeePayrollCode(long? employeecodeid, TblEmployeePayrollCode tblemployeepayrollcode)
    {
        if (employeecodeid != tblemployeepayrollcode.EmployeecodeId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeepayrollcode).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeePayrollCodeExists(employeecodeid))
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

    // POST: api/TblEmployeePayrollCode
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeePayrollCode>> PostTblEmployeePayrollCode(TblEmployeePayrollCode tblemployeepayrollcode)
    {
        _context.TblEmployeePayrollCodes.Add(tblemployeepayrollcode);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeePayrollCode", new { employeecodeid = tblemployeepayrollcode.EmployeecodeId }, tblemployeepayrollcode);
    }

    // DELETE: api/TblEmployeePayrollCode/5
    [HttpDelete("{employeecodeid}")]
    public async Task<IActionResult> DeleteTblEmployeePayrollCode(long? employeecodeid)
    {
        var tblemployeepayrollcode = await _context.TblEmployeePayrollCodes.FindAsync(employeecodeid);
        if (tblemployeepayrollcode == null)
        {
            return NotFound();
        }

        _context.TblEmployeePayrollCodes.Remove(tblemployeepayrollcode);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeePayrollCodeExists(long? employeecodeid)
    {
        return _context.TblEmployeePayrollCodes.Any(e => e.EmployeecodeId == employeecodeid);
    }
}

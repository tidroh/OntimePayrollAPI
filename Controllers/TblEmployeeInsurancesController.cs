using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeInsurancesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeInsurancesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeInsurance
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeInsurance>>> GetTblEmployeeInsurance()
    {
        return await _context.TblEmployeeInsurances.ToListAsync();
    }

    // GET: api/TblEmployeeInsurance/5
    [HttpGet("{employeepolicyid}")]
    public async Task<ActionResult<TblEmployeeInsurance>> GetTblEmployeeInsurance(int employeepolicyid)
    {
        var tblemployeeinsurance = await _context.TblEmployeeInsurances.FindAsync(employeepolicyid);

        if (tblemployeeinsurance == null)
        {
            return NotFound();
        }

        return tblemployeeinsurance;
    }

    // PUT: api/TblEmployeeInsurance/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{employeepolicyid}")]
    public async Task<IActionResult> PutTblEmployeeInsurance(int? employeepolicyid, TblEmployeeInsurance tblemployeeinsurance)
    {
        if (employeepolicyid != tblemployeeinsurance.EmployeepolicyId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeeinsurance).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeInsuranceExists(employeepolicyid))
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

    // POST: api/TblEmployeeInsurance
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeInsurance>> PostTblEmployeeInsurance(TblEmployeeInsurance tblemployeeinsurance)
    {
        _context.TblEmployeeInsurances.Add(tblemployeeinsurance);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeInsurance", new { employeepolicyid = tblemployeeinsurance.EmployeepolicyId }, tblemployeeinsurance);
    }

    // DELETE: api/TblEmployeeInsurance/5
    [HttpDelete("{employeepolicyid}")]
    public async Task<IActionResult> DeleteTblEmployeeInsurance(int? employeepolicyid)
    {
        var tblemployeeinsurance = await _context.TblEmployeeInsurances.FindAsync(employeepolicyid);
        if (tblemployeeinsurance == null)
        {
            return NotFound();
        }

        _context.TblEmployeeInsurances.Remove(tblemployeeinsurance);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeInsuranceExists(int? employeepolicyid)
    {
        return _context.TblEmployeeInsurances.Any(e => e.EmployeepolicyId == employeepolicyid);
    }
}

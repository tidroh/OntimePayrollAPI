using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeBasicPayArrearsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeBasicPayArrearsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeBasicPayArrear
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeBasicPayArrear>>> GetTblEmployeeBasicPayArrear()
    {
        return await _context.TblEmployeeBasicPayArrears.ToListAsync();
    }

    // GET: api/TblEmployeeBasicPayArrear/5
    [HttpGet("{employeepayid}")]
    public async Task<ActionResult<TblEmployeeBasicPayArrear>> GetTblEmployeeBasicPayArrear(int employeepayid)
    {
        var tblemployeebasicpayarrear = await _context.TblEmployeeBasicPayArrears.FindAsync(employeepayid);

        if (tblemployeebasicpayarrear == null)
        {
            return NotFound();
        }

        return tblemployeebasicpayarrear;
    }

    // PUT: api/TblEmployeeBasicPayArrear/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{employeepayid}")]
    public async Task<IActionResult> PutTblEmployeeBasicPayArrear(int? employeepayid, TblEmployeeBasicPayArrear tblemployeebasicpayarrear)
    {
        if (employeepayid != tblemployeebasicpayarrear.EmployeepayId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeebasicpayarrear).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeBasicPayArrearExists(employeepayid))
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

    // POST: api/TblEmployeeBasicPayArrear
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeBasicPayArrear>> PostTblEmployeeBasicPayArrear(TblEmployeeBasicPayArrear tblemployeebasicpayarrear)
    {
        _context.TblEmployeeBasicPayArrears.Add(tblemployeebasicpayarrear);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeBasicPayArrear", new { employeepayid = tblemployeebasicpayarrear.EmployeepayId }, tblemployeebasicpayarrear);
    }

    // DELETE: api/TblEmployeeBasicPayArrear/5
    [HttpDelete("{employeepayid}")]
    public async Task<IActionResult> DeleteTblEmployeeBasicPayArrear(int? employeepayid)
    {
        var tblemployeebasicpayarrear = await _context.TblEmployeeBasicPayArrears.FindAsync(employeepayid);
        if (tblemployeebasicpayarrear == null)
        {
            return NotFound();
        }

        _context.TblEmployeeBasicPayArrears.Remove(tblemployeebasicpayarrear);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeBasicPayArrearExists(int? employeepayid)
    {
        return _context.TblEmployeeBasicPayArrears.Any(e => e.EmployeepayId == employeepayid);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeePeriodDetailsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeePeriodDetailsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeePeriodDetail
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeePeriodDetail>>> GetTblEmployeePeriodDetail()
    {
        return await _context.TblEmployeePeriodDetails.ToListAsync();
    }

    // GET: api/TblEmployeePeriodDetail/5
    [HttpGet("{employeepayid}")]
    public async Task<ActionResult<TblEmployeePeriodDetail>> GetTblEmployeePeriodDetail(int employeepayid)
    {
        var tblemployeeperioddetail = await _context.TblEmployeePeriodDetails.FindAsync(employeepayid);

        if (tblemployeeperioddetail == null)
        {
            return NotFound();
        }

        return tblemployeeperioddetail;
    }

    // PUT: api/TblEmployeePeriodDetail/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{employeepayid}")]
    public async Task<IActionResult> PutTblEmployeePeriodDetail(int? employeepayid, TblEmployeePeriodDetail tblemployeeperioddetail)
    {
        if (employeepayid != tblemployeeperioddetail.EmployeepayId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeeperioddetail).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeePeriodDetailExists(employeepayid))
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

    // POST: api/TblEmployeePeriodDetail
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeePeriodDetail>> PostTblEmployeePeriodDetail(TblEmployeePeriodDetail tblemployeeperioddetail)
    {
        _context.TblEmployeePeriodDetails.Add(tblemployeeperioddetail);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeePeriodDetail", new { employeepayid = tblemployeeperioddetail.EmployeepayId }, tblemployeeperioddetail);
    }

    // DELETE: api/TblEmployeePeriodDetail/5
    [HttpDelete("{employeepayid}")]
    public async Task<IActionResult> DeleteTblEmployeePeriodDetail(int? employeepayid)
    {
        var tblemployeeperioddetail = await _context.TblEmployeePeriodDetails.FindAsync(employeepayid);
        if (tblemployeeperioddetail == null)
        {
            return NotFound();
        }

        _context.TblEmployeePeriodDetails.Remove(tblemployeeperioddetail);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeePeriodDetailExists(int? employeepayid)
    {
        return _context.TblEmployeePeriodDetails.Any(e => e.EmployeepayId == employeepayid);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeDailyValuesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeDailyValuesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeDailyValue
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeDailyValue>>> GetTblEmployeeDailyValue()
    {
        return await _context.TblEmployeeDailyValues.ToListAsync();
    }

    // GET: api/TblEmployeeDailyValue/5
    [HttpGet("{employeedailyvalueid}")]
    public async Task<ActionResult<TblEmployeeDailyValue>> GetTblEmployeeDailyValue(int employeedailyvalueid)
    {
        var tblemployeedailyvalue = await _context.TblEmployeeDailyValues.FindAsync(employeedailyvalueid);

        if (tblemployeedailyvalue == null)
        {
            return NotFound();
        }

        return tblemployeedailyvalue;
    }

    // PUT: api/TblEmployeeDailyValue/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{employeedailyvalueid}")]
    public async Task<IActionResult> PutTblEmployeeDailyValue(int? employeedailyvalueid, TblEmployeeDailyValue tblemployeedailyvalue)
    {
        if (employeedailyvalueid != tblemployeedailyvalue.EmployeeDailyValueId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeedailyvalue).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeDailyValueExists(employeedailyvalueid))
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

    // POST: api/TblEmployeeDailyValue
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeDailyValue>> PostTblEmployeeDailyValue(TblEmployeeDailyValue tblemployeedailyvalue)
    {
        _context.TblEmployeeDailyValues.Add(tblemployeedailyvalue);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeDailyValue", new { employeedailyvalueid = tblemployeedailyvalue.EmployeeDailyValueId }, tblemployeedailyvalue);
    }

    // DELETE: api/TblEmployeeDailyValue/5
    [HttpDelete("{employeedailyvalueid}")]
    public async Task<IActionResult> DeleteTblEmployeeDailyValue(int? employeedailyvalueid)
    {
        var tblemployeedailyvalue = await _context.TblEmployeeDailyValues.FindAsync(employeedailyvalueid);
        if (tblemployeedailyvalue == null)
        {
            return NotFound();
        }

        _context.TblEmployeeDailyValues.Remove(tblemployeedailyvalue);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeDailyValueExists(int? employeedailyvalueid)
    {
        return _context.TblEmployeeDailyValues.Any(e => e.EmployeeDailyValueId == employeedailyvalueid);
    }
}

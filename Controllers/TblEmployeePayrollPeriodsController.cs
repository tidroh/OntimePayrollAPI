using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeePayrollPeriodsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeePayrollPeriodsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeePayrollPeriod
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeePayrollPeriod>>> GetTblEmployeePayrollPeriod()
    {
        return await _context.TblEmployeePayrollPeriods.ToListAsync();
    }

    // GET: api/TblEmployeePayrollPeriod/5
    [HttpGet("{processid}")]
    public async Task<ActionResult<TblEmployeePayrollPeriod>> GetTblEmployeePayrollPeriod(int processid)
    {
        var tblemployeepayrollperiod = await _context.TblEmployeePayrollPeriods.FindAsync(processid);

        if (tblemployeepayrollperiod == null)
        {
            return NotFound();
        }

        return tblemployeepayrollperiod;
    }

    // PUT: api/TblEmployeePayrollPeriod/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{processid}")]
    public async Task<IActionResult> PutTblEmployeePayrollPeriod(int? processid, TblEmployeePayrollPeriod tblemployeepayrollperiod)
    {
        if (processid != tblemployeepayrollperiod.ProcessId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeepayrollperiod).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeePayrollPeriodExists(processid))
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

    // POST: api/TblEmployeePayrollPeriod
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeePayrollPeriod>> PostTblEmployeePayrollPeriod(TblEmployeePayrollPeriod tblemployeepayrollperiod)
    {
        _context.TblEmployeePayrollPeriods.Add(tblemployeepayrollperiod);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeePayrollPeriod", new { processid = tblemployeepayrollperiod.ProcessId }, tblemployeepayrollperiod);
    }

    // DELETE: api/TblEmployeePayrollPeriod/5
    [HttpDelete("{processid}")]
    public async Task<IActionResult> DeleteTblEmployeePayrollPeriod(int? processid)
    {
        var tblemployeepayrollperiod = await _context.TblEmployeePayrollPeriods.FindAsync(processid);
        if (tblemployeepayrollperiod == null)
        {
            return NotFound();
        }

        _context.TblEmployeePayrollPeriods.Remove(tblemployeepayrollperiod);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeePayrollPeriodExists(int? processid)
    {
        return _context.TblEmployeePayrollPeriods.Any(e => e.ProcessId == processid);
    }
}

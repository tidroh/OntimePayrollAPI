using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblLoanSchedulesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblLoanSchedulesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblLoanSchedule
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblLoanSchedule>>> GetTblLoanSchedule()
    {
        return await _context.TblLoanSchedules.ToListAsync();
    }

    // GET: api/TblLoanSchedule/5
    [HttpGet("{scheduleid}")]
    public async Task<ActionResult<TblLoanSchedule>> GetTblLoanSchedule(int scheduleid)
    {
        var tblloanschedule = await _context.TblLoanSchedules.FindAsync(scheduleid);

        if (tblloanschedule == null)
        {
            return NotFound();
        }

        return tblloanschedule;
    }

    // PUT: api/TblLoanSchedule/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{scheduleid}")]
    public async Task<IActionResult> PutTblLoanSchedule(int? scheduleid, TblLoanSchedule tblloanschedule)
    {
        if (scheduleid != tblloanschedule.ScheduleId)
        {
            return BadRequest();
        }

        _context.Entry(tblloanschedule).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblLoanScheduleExists(scheduleid))
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

    // POST: api/TblLoanSchedule
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblLoanSchedule>> PostTblLoanSchedule(TblLoanSchedule tblloanschedule)
    {
        _context.TblLoanSchedules.Add(tblloanschedule);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblLoanSchedule", new { scheduleid = tblloanschedule.ScheduleId }, tblloanschedule);
    }

    // DELETE: api/TblLoanSchedule/5
    [HttpDelete("{scheduleid}")]
    public async Task<IActionResult> DeleteTblLoanSchedule(int? scheduleid)
    {
        var tblloanschedule = await _context.TblLoanSchedules.FindAsync(scheduleid);
        if (tblloanschedule == null)
        {
            return NotFound();
        }

        _context.TblLoanSchedules.Remove(tblloanschedule);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblLoanScheduleExists(int? scheduleid)
    {
        return _context.TblLoanSchedules.Any(e => e.ScheduleId == scheduleid);
    }
}

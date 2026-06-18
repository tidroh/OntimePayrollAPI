using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblHolidaysController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblHolidaysController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblHoliday
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblHoliday>>> GetTblHoliday()
    {
        return await _context.TblHolidays.ToListAsync();
    }

    // GET: api/TblHoliday/5
    [HttpGet("{holidayid}")]
    public async Task<ActionResult<TblHoliday>> GetTblHoliday(int holidayid)
    {
        var tblholiday = await _context.TblHolidays.FindAsync(holidayid);

        if (tblholiday == null)
        {
            return NotFound();
        }

        return tblholiday;
    }

    // PUT: api/TblHoliday/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{holidayid}")]
    public async Task<IActionResult> PutTblHoliday(int? holidayid, TblHoliday tblholiday)
    {
        if (holidayid != tblholiday.HolidayId)
        {
            return BadRequest();
        }

        _context.Entry(tblholiday).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblHolidayExists(holidayid))
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

    // POST: api/TblHoliday
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblHoliday>> PostTblHoliday(TblHoliday tblholiday)
    {
        _context.TblHolidays.Add(tblholiday);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblHoliday", new { holidayid = tblholiday.HolidayId }, tblholiday);
    }

    // DELETE: api/TblHoliday/5
    [HttpDelete("{holidayid}")]
    public async Task<IActionResult> DeleteTblHoliday(int? holidayid)
    {
        var tblholiday = await _context.TblHolidays.FindAsync(holidayid);
        if (tblholiday == null)
        {
            return NotFound();
        }

        _context.TblHolidays.Remove(tblholiday);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblHolidayExists(int? holidayid)
    {
        return _context.TblHolidays.Any(e => e.HolidayId == holidayid);
    }
}

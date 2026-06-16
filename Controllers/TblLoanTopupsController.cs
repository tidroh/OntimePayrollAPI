using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblLoanTopupsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblLoanTopupsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblLoanTopup
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblLoanTopup>>> GetTblLoanTopup()
    {
        return await _context.TblLoanTopups.ToListAsync();
    }

    // GET: api/TblLoanTopup/5
    [HttpGet("{topupid}")]
    public async Task<ActionResult<TblLoanTopup>> GetTblLoanTopup(int topupid)
    {
        var tblloantopup = await _context.TblLoanTopups.FindAsync(topupid);

        if (tblloantopup == null)
        {
            return NotFound();
        }

        return tblloantopup;
    }

    // PUT: api/TblLoanTopup/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{topupid}")]
    public async Task<IActionResult> PutTblLoanTopup(int? topupid, TblLoanTopup tblloantopup)
    {
        if (topupid != tblloantopup.TopupId)
        {
            return BadRequest();
        }

        _context.Entry(tblloantopup).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblLoanTopupExists(topupid))
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

    // POST: api/TblLoanTopup
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblLoanTopup>> PostTblLoanTopup(TblLoanTopup tblloantopup)
    {
        _context.TblLoanTopups.Add(tblloantopup);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblLoanTopup", new { topupid = tblloantopup.TopupId }, tblloantopup);
    }

    // DELETE: api/TblLoanTopup/5
    [HttpDelete("{topupid}")]
    public async Task<IActionResult> DeleteTblLoanTopup(int? topupid)
    {
        var tblloantopup = await _context.TblLoanTopups.FindAsync(topupid);
        if (tblloantopup == null)
        {
            return NotFound();
        }

        _context.TblLoanTopups.Remove(tblloantopup);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblLoanTopupExists(int? topupid)
    {
        return _context.TblLoanTopups.Any(e => e.TopupId == topupid);
    }
}

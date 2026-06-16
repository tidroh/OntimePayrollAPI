using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblPaypointsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblPaypointsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblPaypoint
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblPaypoint>>> GetTblPaypoint()
    {
        return await _context.TblPaypoints.ToListAsync();
    }

    // GET: api/TblPaypoint/5
    [HttpGet("{paypointid}")]
    public async Task<ActionResult<TblPaypoint>> GetTblPaypoint(int paypointid)
    {
        var tblpaypoint = await _context.TblPaypoints.FindAsync(paypointid);

        if (tblpaypoint == null)
        {
            return NotFound();
        }

        return tblpaypoint;
    }

    // PUT: api/TblPaypoint/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{paypointid}")]
    public async Task<IActionResult> PutTblPaypoint(int? paypointid, TblPaypoint tblpaypoint)
    {
        if (paypointid != tblpaypoint.PaypointId)
        {
            return BadRequest();
        }

        _context.Entry(tblpaypoint).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblPaypointExists(paypointid))
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

    // POST: api/TblPaypoint
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblPaypoint>> PostTblPaypoint(TblPaypoint tblpaypoint)
    {
        _context.TblPaypoints.Add(tblpaypoint);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblPaypoint", new { paypointid = tblpaypoint.PaypointId }, tblpaypoint);
    }

    // DELETE: api/TblPaypoint/5
    [HttpDelete("{paypointid}")]
    public async Task<IActionResult> DeleteTblPaypoint(int? paypointid)
    {
        var tblpaypoint = await _context.TblPaypoints.FindAsync(paypointid);
        if (tblpaypoint == null)
        {
            return NotFound();
        }

        _context.TblPaypoints.Remove(tblpaypoint);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblPaypointExists(int? paypointid)
    {
        return _context.TblPaypoints.Any(e => e.PaypointId == paypointid);
    }
}

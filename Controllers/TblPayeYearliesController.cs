using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblPayeYearliesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblPayeYearliesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblPayeYearly
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblPayeYearly>>> GetTblPayeYearly()
    {
        return await _context.TblPayeYearlies.ToListAsync();
    }

    // GET: api/TblPayeYearly/5
    [HttpGet("{payeid}")]
    public async Task<ActionResult<TblPayeYearly>> GetTblPayeYearly(int payeid)
    {
        var tblpayeyearly = await _context.TblPayeYearlies.FindAsync(payeid);

        if (tblpayeyearly == null)
        {
            return NotFound();
        }

        return tblpayeyearly;
    }

    // PUT: api/TblPayeYearly/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{payeid}")]
    public async Task<IActionResult> PutTblPayeYearly(int? payeid, TblPayeYearly tblpayeyearly)
    {
        if (payeid != tblpayeyearly.PayeId)
        {
            return BadRequest();
        }

        _context.Entry(tblpayeyearly).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblPayeYearlyExists(payeid))
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

    // POST: api/TblPayeYearly
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblPayeYearly>> PostTblPayeYearly(TblPayeYearly tblpayeyearly)
    {
        _context.TblPayeYearlies.Add(tblpayeyearly);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblPayeYearly", new { payeid = tblpayeyearly.PayeId }, tblpayeyearly);
    }

    // DELETE: api/TblPayeYearly/5
    [HttpDelete("{payeid}")]
    public async Task<IActionResult> DeleteTblPayeYearly(int? payeid)
    {
        var tblpayeyearly = await _context.TblPayeYearlies.FindAsync(payeid);
        if (tblpayeyearly == null)
        {
            return NotFound();
        }

        _context.TblPayeYearlies.Remove(tblpayeyearly);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblPayeYearlyExists(int? payeid)
    {
        return _context.TblPayeYearlies.Any(e => e.PayeId == payeid);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblNssfsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblNssfsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblNssf
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblNssf>>> GetTblNssf()
    {
        return await _context.TblNssfs.ToListAsync();
    }

    // GET: api/TblNssf/5
    [HttpGet("{nssfid}")]
    public async Task<ActionResult<TblNssf>> GetTblNssf(int nssfid)
    {
        var tblnssf = await _context.TblNssfs.FindAsync(nssfid);

        if (tblnssf == null)
        {
            return NotFound();
        }

        return tblnssf;
    }

    // PUT: api/TblNssf/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{nssfid}")]
    public async Task<IActionResult> PutTblNssf(int? nssfid, TblNssf tblnssf)
    {
        if (nssfid != tblnssf.NssfId)
        {
            return BadRequest();
        }

        _context.Entry(tblnssf).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblNssfExists(nssfid))
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

    // POST: api/TblNssf
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblNssf>> PostTblNssf(TblNssf tblnssf)
    {
        _context.TblNssfs.Add(tblnssf);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblNssf", new { nssfid = tblnssf.NssfId }, tblnssf);
    }

    // DELETE: api/TblNssf/5
    [HttpDelete("{nssfid}")]
    public async Task<IActionResult> DeleteTblNssf(int? nssfid)
    {
        var tblnssf = await _context.TblNssfs.FindAsync(nssfid);
        if (tblnssf == null)
        {
            return NotFound();
        }

        _context.TblNssfs.Remove(tblnssf);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblNssfExists(int? nssfid)
    {
        return _context.TblNssfs.Any(e => e.NssfId == nssfid);
    }
}

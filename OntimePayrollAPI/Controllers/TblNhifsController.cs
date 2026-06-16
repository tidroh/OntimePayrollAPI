using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblNhifsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblNhifsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblNhif
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblNhif>>> GetTblNhif()
    {
        return await _context.TblNhifs.ToListAsync();
    }

    // GET: api/TblNhif/5
    [HttpGet("{nhifid}")]
    public async Task<ActionResult<TblNhif>> GetTblNhif(int nhifid)
    {
        var tblnhif = await _context.TblNhifs.FindAsync(nhifid);

        if (tblnhif == null)
        {
            return NotFound();
        }

        return tblnhif;
    }

    // PUT: api/TblNhif/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{nhifid}")]
    public async Task<IActionResult> PutTblNhif(int? nhifid, TblNhif tblnhif)
    {
        if (nhifid != tblnhif.NhifId)
        {
            return BadRequest();
        }

        _context.Entry(tblnhif).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblNhifExists(nhifid))
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

    // POST: api/TblNhif
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblNhif>> PostTblNhif(TblNhif tblnhif)
    {
        _context.TblNhifs.Add(tblnhif);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblNhif", new { nhifid = tblnhif.NhifId }, tblnhif);
    }

    // DELETE: api/TblNhif/5
    [HttpDelete("{nhifid}")]
    public async Task<IActionResult> DeleteTblNhif(int? nhifid)
    {
        var tblnhif = await _context.TblNhifs.FindAsync(nhifid);
        if (tblnhif == null)
        {
            return NotFound();
        }

        _context.TblNhifs.Remove(tblnhif);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblNhifExists(int? nhifid)
    {
        return _context.TblNhifs.Any(e => e.NhifId == nhifid);
    }
}

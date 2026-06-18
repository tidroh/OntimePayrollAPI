using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblHousingSchemesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblHousingSchemesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblHousingScheme
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblHousingScheme>>> GetTblHousingScheme()
    {
        return await _context.TblHousingSchemes.ToListAsync();
    }

    // GET: api/TblHousingScheme/5
    [HttpGet("{housingid}")]
    public async Task<ActionResult<TblHousingScheme>> GetTblHousingScheme(int housingid)
    {
        var tblhousingscheme = await _context.TblHousingSchemes.FindAsync(housingid);

        if (tblhousingscheme == null)
        {
            return NotFound();
        }

        return tblhousingscheme;
    }

    // PUT: api/TblHousingScheme/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{housingid}")]
    public async Task<IActionResult> PutTblHousingScheme(int? housingid, TblHousingScheme tblhousingscheme)
    {
        if (housingid != tblhousingscheme.HousingId)
        {
            return BadRequest();
        }

        _context.Entry(tblhousingscheme).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblHousingSchemeExists(housingid))
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

    // POST: api/TblHousingScheme
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblHousingScheme>> PostTblHousingScheme(TblHousingScheme tblhousingscheme)
    {
        _context.TblHousingSchemes.Add(tblhousingscheme);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblHousingScheme", new { housingid = tblhousingscheme.HousingId }, tblhousingscheme);
    }

    // DELETE: api/TblHousingScheme/5
    [HttpDelete("{housingid}")]
    public async Task<IActionResult> DeleteTblHousingScheme(int? housingid)
    {
        var tblhousingscheme = await _context.TblHousingSchemes.FindAsync(housingid);
        if (tblhousingscheme == null)
        {
            return NotFound();
        }

        _context.TblHousingSchemes.Remove(tblhousingscheme);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblHousingSchemeExists(int? housingid)
    {
        return _context.TblHousingSchemes.Any(e => e.HousingId == housingid);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblHousingsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblHousingsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblHousing
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblHousing>>> GetTblHousing()
    {
        return await _context.TblHousings.ToListAsync();
    }

    // GET: api/TblHousing/5
    [HttpGet("{housingid}")]
    public async Task<ActionResult<TblHousing>> GetTblHousing(int housingid)
    {
        var tblhousing = await _context.TblHousings.FindAsync(housingid);

        if (tblhousing == null)
        {
            return NotFound();
        }

        return tblhousing;
    }

    // PUT: api/TblHousing/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{housingid}")]
    public async Task<IActionResult> PutTblHousing(int? housingid, TblHousing tblhousing)
    {
        if (housingid != tblhousing.HousingId)
        {
            return BadRequest();
        }

        _context.Entry(tblhousing).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblHousingExists(housingid))
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

    // POST: api/TblHousing
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblHousing>> PostTblHousing(TblHousing tblhousing)
    {
        _context.TblHousings.Add(tblhousing);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblHousing", new { housingid = tblhousing.HousingId }, tblhousing);
    }

    // DELETE: api/TblHousing/5
    [HttpDelete("{housingid}")]
    public async Task<IActionResult> DeleteTblHousing(int? housingid)
    {
        var tblhousing = await _context.TblHousings.FindAsync(housingid);
        if (tblhousing == null)
        {
            return NotFound();
        }

        _context.TblHousings.Remove(tblhousing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblHousingExists(int? housingid)
    {
        return _context.TblHousings.Any(e => e.HousingId == housingid);
    }
}

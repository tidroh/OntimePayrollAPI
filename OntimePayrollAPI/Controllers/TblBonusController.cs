using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblBonusController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblBonusController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblBonu
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblBonu>>> GetTblBonu()
    {
        return await _context.TblBonus.ToListAsync();
    }

    // GET: api/TblBonu/5
    [HttpGet("{bonusid}")]
    public async Task<ActionResult<TblBonu>> GetTblBonu(int bonusid)
    {
        var tblbonu = await _context.TblBonus.FindAsync(bonusid);

        if (tblbonu == null)
        {
            return NotFound();
        }

        return tblbonu;
    }

    // PUT: api/TblBonu/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{bonusid}")]
    public async Task<IActionResult> PutTblBonu(int? bonusid, TblBonu tblbonu)
    {
        if (bonusid != tblbonu.BonusId)
        {
            return BadRequest();
        }

        _context.Entry(tblbonu).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblBonuExists(bonusid))
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

    // POST: api/TblBonu
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblBonu>> PostTblBonu(TblBonu tblbonu)
    {
        _context.TblBonus.Add(tblbonu);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblBonu", new { bonusid = tblbonu.BonusId }, tblbonu);
    }

    // DELETE: api/TblBonu/5
    [HttpDelete("{bonusid}")]
    public async Task<IActionResult> DeleteTblBonu(int? bonusid)
    {
        var tblbonu = await _context.TblBonus.FindAsync(bonusid);
        if (tblbonu == null)
        {
            return NotFound();
        }

        _context.TblBonus.Remove(tblbonu);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblBonuExists(int? bonusid)
    {
        return _context.TblBonus.Any(e => e.BonusId == bonusid);
    }
}

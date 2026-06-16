using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblBonusDetailsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblBonusDetailsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblBonusDetail
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblBonusDetail>>> GetTblBonusDetail()
    {
        return await _context.TblBonusDetails.ToListAsync();
    }

    // GET: api/TblBonusDetail/5
    [HttpGet("{bonusdetailid}")]
    public async Task<ActionResult<TblBonusDetail>> GetTblBonusDetail(int bonusdetailid)
    {
        var tblbonusdetail = await _context.TblBonusDetails.FindAsync(bonusdetailid);

        if (tblbonusdetail == null)
        {
            return NotFound();
        }

        return tblbonusdetail;
    }

    // PUT: api/TblBonusDetail/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{bonusdetailid}")]
    public async Task<IActionResult> PutTblBonusDetail(int? bonusdetailid, TblBonusDetail tblbonusdetail)
    {
        if (bonusdetailid != tblbonusdetail.BonusdetailId)
        {
            return BadRequest();
        }

        _context.Entry(tblbonusdetail).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblBonusDetailExists(bonusdetailid))
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

    // POST: api/TblBonusDetail
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblBonusDetail>> PostTblBonusDetail(TblBonusDetail tblbonusdetail)
    {
        _context.TblBonusDetails.Add(tblbonusdetail);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblBonusDetail", new { bonusdetailid = tblbonusdetail.BonusdetailId }, tblbonusdetail);
    }

    // DELETE: api/TblBonusDetail/5
    [HttpDelete("{bonusdetailid}")]
    public async Task<IActionResult> DeleteTblBonusDetail(int? bonusdetailid)
    {
        var tblbonusdetail = await _context.TblBonusDetails.FindAsync(bonusdetailid);
        if (tblbonusdetail == null)
        {
            return NotFound();
        }

        _context.TblBonusDetails.Remove(tblbonusdetail);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblBonusDetailExists(int? bonusdetailid)
    {
        return _context.TblBonusDetails.Any(e => e.BonusdetailId == bonusdetailid);
    }
}

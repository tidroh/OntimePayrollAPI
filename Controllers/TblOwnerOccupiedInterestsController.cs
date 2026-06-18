using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblOwnerOccupiedInterestsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblOwnerOccupiedInterestsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblOwnerOccupiedInterest
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblOwnerOccupiedInterest>>> GetTblOwnerOccupiedInterest()
    {
        return await _context.TblOwnerOccupiedInterests.ToListAsync();
    }

    // GET: api/TblOwnerOccupiedInterest/5
    [HttpGet("{ownerocuupiedid}")]
    public async Task<ActionResult<TblOwnerOccupiedInterest>> GetTblOwnerOccupiedInterest(int ownerocuupiedid)
    {
        var tblowneroccupiedinterest = await _context.TblOwnerOccupiedInterests.FindAsync(ownerocuupiedid);

        if (tblowneroccupiedinterest == null)
        {
            return NotFound();
        }

        return tblowneroccupiedinterest;
    }

    // PUT: api/TblOwnerOccupiedInterest/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{ownerocuupiedid}")]
    public async Task<IActionResult> PutTblOwnerOccupiedInterest(int? ownerocuupiedid, TblOwnerOccupiedInterest tblowneroccupiedinterest)
    {
        if (ownerocuupiedid != tblowneroccupiedinterest.OwnerOcuupiedId)
        {
            return BadRequest();
        }

        _context.Entry(tblowneroccupiedinterest).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblOwnerOccupiedInterestExists(ownerocuupiedid))
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

    // POST: api/TblOwnerOccupiedInterest
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblOwnerOccupiedInterest>> PostTblOwnerOccupiedInterest(TblOwnerOccupiedInterest tblowneroccupiedinterest)
    {
        _context.TblOwnerOccupiedInterests.Add(tblowneroccupiedinterest);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblOwnerOccupiedInterest", new { ownerocuupiedid = tblowneroccupiedinterest.OwnerOcuupiedId }, tblowneroccupiedinterest);
    }

    // DELETE: api/TblOwnerOccupiedInterest/5
    [HttpDelete("{ownerocuupiedid}")]
    public async Task<IActionResult> DeleteTblOwnerOccupiedInterest(int? ownerocuupiedid)
    {
        var tblowneroccupiedinterest = await _context.TblOwnerOccupiedInterests.FindAsync(ownerocuupiedid);
        if (tblowneroccupiedinterest == null)
        {
            return NotFound();
        }

        _context.TblOwnerOccupiedInterests.Remove(tblowneroccupiedinterest);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblOwnerOccupiedInterestExists(int? ownerocuupiedid)
    {
        return _context.TblOwnerOccupiedInterests.Any(e => e.OwnerOcuupiedId == ownerocuupiedid);
    }
}

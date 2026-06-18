using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblCooperativesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblCooperativesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblCooperative
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblCooperative>>> GetTblCooperative()
    {
        return await _context.TblCooperatives.ToListAsync();
    }

    // GET: api/TblCooperative/5
    [HttpGet("{coopid}")]
    public async Task<ActionResult<TblCooperative>> GetTblCooperative(int coopid)
    {
        var tblcooperative = await _context.TblCooperatives.FindAsync(coopid);

        if (tblcooperative == null)
        {
            return NotFound();
        }

        return tblcooperative;
    }

    // PUT: api/TblCooperative/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{coopid}")]
    public async Task<IActionResult> PutTblCooperative(int? coopid, TblCooperative tblcooperative)
    {
        if (coopid != tblcooperative.CoopId)
        {
            return BadRequest();
        }

        _context.Entry(tblcooperative).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblCooperativeExists(coopid))
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

    // POST: api/TblCooperative
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblCooperative>> PostTblCooperative(TblCooperative tblcooperative)
    {
        _context.TblCooperatives.Add(tblcooperative);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblCooperative", new { coopid = tblcooperative.CoopId }, tblcooperative);
    }

    // DELETE: api/TblCooperative/5
    [HttpDelete("{coopid}")]
    public async Task<IActionResult> DeleteTblCooperative(int? coopid)
    {
        var tblcooperative = await _context.TblCooperatives.FindAsync(coopid);
        if (tblcooperative == null)
        {
            return NotFound();
        }

        _context.TblCooperatives.Remove(tblcooperative);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblCooperativeExists(int? coopid)
    {
        return _context.TblCooperatives.Any(e => e.CoopId == coopid);
    }
}

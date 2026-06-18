using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblDenominationsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblDenominationsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblDenomination
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblDenomination>>> GetTblDenomination()
    {
        return await _context.TblDenominations.ToListAsync();
    }

    // GET: api/TblDenomination/5
    [HttpGet("{denominationid}")]
    public async Task<ActionResult<TblDenomination>> GetTblDenomination(int denominationid)
    {
        var tbldenomination = await _context.TblDenominations.FindAsync(denominationid);

        if (tbldenomination == null)
        {
            return NotFound();
        }

        return tbldenomination;
    }

    // PUT: api/TblDenomination/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{denominationid}")]
    public async Task<IActionResult> PutTblDenomination(int? denominationid, TblDenomination tbldenomination)
    {
        if (denominationid != tbldenomination.DenominationId)
        {
            return BadRequest();
        }

        _context.Entry(tbldenomination).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblDenominationExists(denominationid))
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

    // POST: api/TblDenomination
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblDenomination>> PostTblDenomination(TblDenomination tbldenomination)
    {
        _context.TblDenominations.Add(tbldenomination);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblDenomination", new { denominationid = tbldenomination.DenominationId }, tbldenomination);
    }

    // DELETE: api/TblDenomination/5
    [HttpDelete("{denominationid}")]
    public async Task<IActionResult> DeleteTblDenomination(int? denominationid)
    {
        var tbldenomination = await _context.TblDenominations.FindAsync(denominationid);
        if (tbldenomination == null)
        {
            return NotFound();
        }

        _context.TblDenominations.Remove(tbldenomination);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblDenominationExists(int? denominationid)
    {
        return _context.TblDenominations.Any(e => e.DenominationId == denominationid);
    }
}

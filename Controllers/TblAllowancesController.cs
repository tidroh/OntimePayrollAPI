using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblAllowancesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblAllowancesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblAllowance
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblAllowance>>> GetTblAllowance()
    {
        return await _context.TblAllowances.ToListAsync();
    }

    // GET: api/TblAllowance/5
    [HttpGet("{allowanceid}")]
    public async Task<ActionResult<TblAllowance>> GetTblAllowance(int allowanceid)
    {
        var tblallowance = await _context.TblAllowances.FindAsync(allowanceid);

        if (tblallowance == null)
        {
            return NotFound();
        }

        return tblallowance;
    }

    // PUT: api/TblAllowance/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{allowanceid}")]
    public async Task<IActionResult> PutTblAllowance(int? allowanceid, TblAllowance tblallowance)
    {
        if (allowanceid != tblallowance.AllowanceId)
        {
            return BadRequest();
        }

        _context.Entry(tblallowance).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblAllowanceExists(allowanceid))
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

    // POST: api/TblAllowance
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblAllowance>> PostTblAllowance(TblAllowance tblallowance)
    {
        _context.TblAllowances.Add(tblallowance);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblAllowance", new { allowanceid = tblallowance.AllowanceId }, tblallowance);
    }

    // DELETE: api/TblAllowance/5
    [HttpDelete("{allowanceid}")]
    public async Task<IActionResult> DeleteTblAllowance(int? allowanceid)
    {
        var tblallowance = await _context.TblAllowances.FindAsync(allowanceid);
        if (tblallowance == null)
        {
            return NotFound();
        }

        _context.TblAllowances.Remove(tblallowance);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblAllowanceExists(int? allowanceid)
    {
        return _context.TblAllowances.Any(e => e.AllowanceId == allowanceid);
    }
}

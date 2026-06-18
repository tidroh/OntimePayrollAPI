using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblLoanReductionsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblLoanReductionsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblLoanReduction
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblLoanReduction>>> GetTblLoanReduction()
    {
        return await _context.TblLoanReductions.ToListAsync();
    }

    // GET: api/TblLoanReduction/5
    [HttpGet("{reductionid}")]
    public async Task<ActionResult<TblLoanReduction>> GetTblLoanReduction(int reductionid)
    {
        var tblloanreduction = await _context.TblLoanReductions.FindAsync(reductionid);

        if (tblloanreduction == null)
        {
            return NotFound();
        }

        return tblloanreduction;
    }

    // PUT: api/TblLoanReduction/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{reductionid}")]
    public async Task<IActionResult> PutTblLoanReduction(int? reductionid, TblLoanReduction tblloanreduction)
    {
        if (reductionid != tblloanreduction.ReductionId)
        {
            return BadRequest();
        }

        _context.Entry(tblloanreduction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblLoanReductionExists(reductionid))
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

    // POST: api/TblLoanReduction
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblLoanReduction>> PostTblLoanReduction(TblLoanReduction tblloanreduction)
    {
        _context.TblLoanReductions.Add(tblloanreduction);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblLoanReduction", new { reductionid = tblloanreduction.ReductionId }, tblloanreduction);
    }

    // DELETE: api/TblLoanReduction/5
    [HttpDelete("{reductionid}")]
    public async Task<IActionResult> DeleteTblLoanReduction(int? reductionid)
    {
        var tblloanreduction = await _context.TblLoanReductions.FindAsync(reductionid);
        if (tblloanreduction == null)
        {
            return NotFound();
        }

        _context.TblLoanReductions.Remove(tblloanreduction);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblLoanReductionExists(int? reductionid)
    {
        return _context.TblLoanReductions.Any(e => e.ReductionId == reductionid);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblOpeningBalancesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblOpeningBalancesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblOpeningBalance
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblOpeningBalance>>> GetTblOpeningBalance()
    {
        return await _context.TblOpeningBalances.ToListAsync();
    }

    // GET: api/TblOpeningBalance/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblOpeningBalance>> GetTblOpeningBalance(int id)
    {
        var tblopeningbalance = await _context.TblOpeningBalances.FindAsync(id);

        if (tblopeningbalance == null)
        {
            return NotFound();
        }

        return tblopeningbalance;
    }

    // PUT: api/TblOpeningBalance/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblOpeningBalance(int? id, TblOpeningBalance tblopeningbalance)
    {
        if (id != tblopeningbalance.Id)
        {
            return BadRequest();
        }

        _context.Entry(tblopeningbalance).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblOpeningBalanceExists(id))
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

    // POST: api/TblOpeningBalance
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblOpeningBalance>> PostTblOpeningBalance(TblOpeningBalance tblopeningbalance)
    {
        _context.TblOpeningBalances.Add(tblopeningbalance);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblOpeningBalance", new { id = tblopeningbalance.Id }, tblopeningbalance);
    }

    // DELETE: api/TblOpeningBalance/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblOpeningBalance(int? id)
    {
        var tblopeningbalance = await _context.TblOpeningBalances.FindAsync(id);
        if (tblopeningbalance == null)
        {
            return NotFound();
        }

        _context.TblOpeningBalances.Remove(tblopeningbalance);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblOpeningBalanceExists(int? id)
    {
        return _context.TblOpeningBalances.Any(e => e.Id == id);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblLoanTransactionsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblLoanTransactionsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblLoanTransaction
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblLoanTransaction>>> GetTblLoanTransaction()
    {
        return await _context.TblLoanTransactions.ToListAsync();
    }

    // GET: api/TblLoanTransaction/5
    [HttpGet("{loantransid}")]
    public async Task<ActionResult<TblLoanTransaction>> GetTblLoanTransaction(int loantransid)
    {
        var tblloantransaction = await _context.TblLoanTransactions.FindAsync(loantransid);

        if (tblloantransaction == null)
        {
            return NotFound();
        }

        return tblloantransaction;
    }

    // PUT: api/TblLoanTransaction/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{loantransid}")]
    public async Task<IActionResult> PutTblLoanTransaction(int? loantransid, TblLoanTransaction tblloantransaction)
    {
        if (loantransid != tblloantransaction.LoantransId)
        {
            return BadRequest();
        }

        _context.Entry(tblloantransaction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblLoanTransactionExists(loantransid))
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

    // POST: api/TblLoanTransaction
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblLoanTransaction>> PostTblLoanTransaction(TblLoanTransaction tblloantransaction)
    {
        _context.TblLoanTransactions.Add(tblloantransaction);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblLoanTransaction", new { loantransid = tblloantransaction.LoantransId }, tblloantransaction);
    }

    // DELETE: api/TblLoanTransaction/5
    [HttpDelete("{loantransid}")]
    public async Task<IActionResult> DeleteTblLoanTransaction(int? loantransid)
    {
        var tblloantransaction = await _context.TblLoanTransactions.FindAsync(loantransid);
        if (tblloantransaction == null)
        {
            return NotFound();
        }

        _context.TblLoanTransactions.Remove(tblloantransaction);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblLoanTransactionExists(int? loantransid)
    {
        return _context.TblLoanTransactions.Any(e => e.LoantransId == loantransid);
    }
}

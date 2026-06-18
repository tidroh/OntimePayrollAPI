using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblNonPayrollTransactionsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblNonPayrollTransactionsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblNonPayrollTransaction
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblNonPayrollTransaction>>> GetTblNonPayrollTransaction()
    {
        return await _context.TblNonPayrollTransactions.ToListAsync();
    }

    // GET: api/TblNonPayrollTransaction/5
    [HttpGet("{nonpayrolltransid}")]
    public async Task<ActionResult<TblNonPayrollTransaction>> GetTblNonPayrollTransaction(int nonpayrolltransid)
    {
        var tblnonpayrolltransaction = await _context.TblNonPayrollTransactions.FindAsync(nonpayrolltransid);

        if (tblnonpayrolltransaction == null)
        {
            return NotFound();
        }

        return tblnonpayrolltransaction;
    }

    // PUT: api/TblNonPayrollTransaction/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{nonpayrolltransid}")]
    public async Task<IActionResult> PutTblNonPayrollTransaction(int? nonpayrolltransid, TblNonPayrollTransaction tblnonpayrolltransaction)
    {
        if (nonpayrolltransid != tblnonpayrolltransaction.NonPayrollTransId)
        {
            return BadRequest();
        }

        _context.Entry(tblnonpayrolltransaction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblNonPayrollTransactionExists(nonpayrolltransid))
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

    // POST: api/TblNonPayrollTransaction
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblNonPayrollTransaction>> PostTblNonPayrollTransaction(TblNonPayrollTransaction tblnonpayrolltransaction)
    {
        _context.TblNonPayrollTransactions.Add(tblnonpayrolltransaction);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblNonPayrollTransaction", new { nonpayrolltransid = tblnonpayrolltransaction.NonPayrollTransId }, tblnonpayrolltransaction);
    }

    // DELETE: api/TblNonPayrollTransaction/5
    [HttpDelete("{nonpayrolltransid}")]
    public async Task<IActionResult> DeleteTblNonPayrollTransaction(int? nonpayrolltransid)
    {
        var tblnonpayrolltransaction = await _context.TblNonPayrollTransactions.FindAsync(nonpayrolltransid);
        if (tblnonpayrolltransaction == null)
        {
            return NotFound();
        }

        _context.TblNonPayrollTransactions.Remove(tblnonpayrolltransaction);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblNonPayrollTransactionExists(int? nonpayrolltransid)
    {
        return _context.TblNonPayrollTransactions.Any(e => e.NonPayrollTransId == nonpayrolltransid);
    }
}

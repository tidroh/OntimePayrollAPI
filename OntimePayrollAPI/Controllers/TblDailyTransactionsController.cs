using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblDailyTransactionsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblDailyTransactionsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblDailyTransaction
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblDailyTransaction>>> GetTblDailyTransaction()
    {
        return await _context.TblDailyTransactions.ToListAsync();
    }

    // GET: api/TblDailyTransaction/5
    [HttpGet("{dailytransactionid}")]
    public async Task<ActionResult<TblDailyTransaction>> GetTblDailyTransaction(int dailytransactionid)
    {
        var tbldailytransaction = await _context.TblDailyTransactions.FindAsync(dailytransactionid);

        if (tbldailytransaction == null)
        {
            return NotFound();
        }

        return tbldailytransaction;
    }

    // PUT: api/TblDailyTransaction/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{dailytransactionid}")]
    public async Task<IActionResult> PutTblDailyTransaction(int? dailytransactionid, TblDailyTransaction tbldailytransaction)
    {
        if (dailytransactionid != tbldailytransaction.DailyTransactionId)
        {
            return BadRequest();
        }

        _context.Entry(tbldailytransaction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblDailyTransactionExists(dailytransactionid))
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

    // POST: api/TblDailyTransaction
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblDailyTransaction>> PostTblDailyTransaction(TblDailyTransaction tbldailytransaction)
    {
        _context.TblDailyTransactions.Add(tbldailytransaction);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblDailyTransaction", new { dailytransactionid = tbldailytransaction.DailyTransactionId }, tbldailytransaction);
    }

    // DELETE: api/TblDailyTransaction/5
    [HttpDelete("{dailytransactionid}")]
    public async Task<IActionResult> DeleteTblDailyTransaction(int? dailytransactionid)
    {
        var tbldailytransaction = await _context.TblDailyTransactions.FindAsync(dailytransactionid);
        if (tbldailytransaction == null)
        {
            return NotFound();
        }

        _context.TblDailyTransactions.Remove(tbldailytransaction);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblDailyTransactionExists(int? dailytransactionid)
    {
        return _context.TblDailyTransactions.Any(e => e.DailyTransactionId == dailytransactionid);
    }
}

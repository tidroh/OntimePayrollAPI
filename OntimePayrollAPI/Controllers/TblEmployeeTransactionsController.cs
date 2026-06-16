using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeTransactionsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeTransactionsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeTransaction
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeTransaction>>> GetTblEmployeeTransaction()
    {
        return await _context.TblEmployeeTransactions.ToListAsync();
    }

    // GET: api/TblEmployeeTransaction/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblEmployeeTransaction>> GetTblEmployeeTransaction(long id)
    {
        var tblemployeetransaction = await _context.TblEmployeeTransactions.FindAsync(id);

        if (tblemployeetransaction == null)
        {
            return NotFound();
        }

        return tblemployeetransaction;
    }

    // PUT: api/TblEmployeeTransaction/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblEmployeeTransaction(long? id, TblEmployeeTransaction tblemployeetransaction)
    {
        if (id != tblemployeetransaction.Id)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeetransaction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeTransactionExists(id))
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

    // POST: api/TblEmployeeTransaction
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeTransaction>> PostTblEmployeeTransaction(TblEmployeeTransaction tblemployeetransaction)
    {
        _context.TblEmployeeTransactions.Add(tblemployeetransaction);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeTransaction", new { id = tblemployeetransaction.Id }, tblemployeetransaction);
    }

    // DELETE: api/TblEmployeeTransaction/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblEmployeeTransaction(long? id)
    {
        var tblemployeetransaction = await _context.TblEmployeeTransactions.FindAsync(id);
        if (tblemployeetransaction == null)
        {
            return NotFound();
        }

        _context.TblEmployeeTransactions.Remove(tblemployeetransaction);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeTransactionExists(long? id)
    {
        return _context.TblEmployeeTransactions.Any(e => e.Id == id);
    }
}

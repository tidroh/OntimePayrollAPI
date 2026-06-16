using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblCasualEmployeeTransactionsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblCasualEmployeeTransactionsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblCasualEmployeeTransaction
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblCasualEmployeeTransaction>>> GetTblCasualEmployeeTransaction()
    {
        return await _context.TblCasualEmployeeTransactions.ToListAsync();
    }

    // GET: api/TblCasualEmployeeTransaction/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblCasualEmployeeTransaction>> GetTblCasualEmployeeTransaction(int id)
    {
        var tblcasualemployeetransaction = await _context.TblCasualEmployeeTransactions.FindAsync(id);

        if (tblcasualemployeetransaction == null)
        {
            return NotFound();
        }

        return tblcasualemployeetransaction;
    }

    // PUT: api/TblCasualEmployeeTransaction/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblCasualEmployeeTransaction(int? id, TblCasualEmployeeTransaction tblcasualemployeetransaction)
    {
        if (id != tblcasualemployeetransaction.Id)
        {
            return BadRequest();
        }

        _context.Entry(tblcasualemployeetransaction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblCasualEmployeeTransactionExists(id))
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

    // POST: api/TblCasualEmployeeTransaction
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblCasualEmployeeTransaction>> PostTblCasualEmployeeTransaction(TblCasualEmployeeTransaction tblcasualemployeetransaction)
    {
        _context.TblCasualEmployeeTransactions.Add(tblcasualemployeetransaction);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblCasualEmployeeTransaction", new { id = tblcasualemployeetransaction.Id }, tblcasualemployeetransaction);
    }

    // DELETE: api/TblCasualEmployeeTransaction/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblCasualEmployeeTransaction(int? id)
    {
        var tblcasualemployeetransaction = await _context.TblCasualEmployeeTransactions.FindAsync(id);
        if (tblcasualemployeetransaction == null)
        {
            return NotFound();
        }

        _context.TblCasualEmployeeTransactions.Remove(tblcasualemployeetransaction);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblCasualEmployeeTransactionExists(int? id)
    {
        return _context.TblCasualEmployeeTransactions.Any(e => e.Id == id);
    }
}

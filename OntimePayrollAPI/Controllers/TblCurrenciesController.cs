using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblCurrenciesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblCurrenciesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblCurrency
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblCurrency>>> GetTblCurrency()
    {
        return await _context.TblCurrencies.ToListAsync();
    }

    // GET: api/TblCurrency/5
    [HttpGet("{currencyid}")]
    public async Task<ActionResult<TblCurrency>> GetTblCurrency(int currencyid)
    {
        var tblcurrency = await _context.TblCurrencies.FindAsync(currencyid);

        if (tblcurrency == null)
        {
            return NotFound();
        }

        return tblcurrency;
    }

    // PUT: api/TblCurrency/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{currencyid}")]
    public async Task<IActionResult> PutTblCurrency(int? currencyid, TblCurrency tblcurrency)
    {
        if (currencyid != tblcurrency.CurrencyId)
        {
            return BadRequest();
        }

        _context.Entry(tblcurrency).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblCurrencyExists(currencyid))
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

    // POST: api/TblCurrency
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblCurrency>> PostTblCurrency(TblCurrency tblcurrency)
    {
        _context.TblCurrencies.Add(tblcurrency);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblCurrency", new { currencyid = tblcurrency.CurrencyId }, tblcurrency);
    }

    // DELETE: api/TblCurrency/5
    [HttpDelete("{currencyid}")]
    public async Task<IActionResult> DeleteTblCurrency(int? currencyid)
    {
        var tblcurrency = await _context.TblCurrencies.FindAsync(currencyid);
        if (tblcurrency == null)
        {
            return NotFound();
        }

        _context.TblCurrencies.Remove(tblcurrency);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblCurrencyExists(int? currencyid)
    {
        return _context.TblCurrencies.Any(e => e.CurrencyId == currencyid);
    }
}

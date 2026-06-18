using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblBanksController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblBanksController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblBank
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblBank>>> GetTblBank()
    {
        return await _context.TblBanks.ToListAsync();
    }

    // GET: api/TblBank/5
    [HttpGet("{bankid}")]
    public async Task<ActionResult<TblBank>> GetTblBank(int bankid)
    {
        var tblbank = await _context.TblBanks.FindAsync(bankid);

        if (tblbank == null)
        {
            return NotFound();
        }

        return tblbank;
    }

    // PUT: api/TblBank/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{bankid}")]
    public async Task<IActionResult> PutTblBank(int? bankid, TblBank tblbank)
    {
        if (bankid != tblbank.BankId)
        {
            return BadRequest();
        }

        _context.Entry(tblbank).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblBankExists(bankid))
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

    // POST: api/TblBank
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblBank>> PostTblBank(TblBank tblbank)
    {
        _context.TblBanks.Add(tblbank);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblBank", new { bankid = tblbank.BankId }, tblbank);
    }

    // DELETE: api/TblBank/5
    [HttpDelete("{bankid}")]
    public async Task<IActionResult> DeleteTblBank(int? bankid)
    {
        var tblbank = await _context.TblBanks.FindAsync(bankid);
        if (tblbank == null)
        {
            return NotFound();
        }

        _context.TblBanks.Remove(tblbank);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblBankExists(int? bankid)
    {
        return _context.TblBanks.Any(e => e.BankId == bankid);
    }
}

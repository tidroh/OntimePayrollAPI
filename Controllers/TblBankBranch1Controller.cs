using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblBankBranch1Controller : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblBankBranch1Controller(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblBankBranch1
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblBankBranch1>>> GetTblBankBranch1()
    {
        return await _context.TblBankBranches1.ToListAsync();
    }

    // GET: api/TblBankBranch1/5
    [HttpGet("{bankcode}")]
    public async Task<ActionResult<TblBankBranch1>> GetTblBankBranch1(string bankcode)
    {
        var tblbankbranch1 = await _context.TblBankBranches1.FindAsync(bankcode);

        if (tblbankbranch1 == null)
        {
            return NotFound();
        }

        return tblbankbranch1;
    }

    // PUT: api/TblBankBranch1/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{bankcode}")]
    public async Task<IActionResult> PutTblBankBranch1(string? bankcode, TblBankBranch1 tblbankbranch1)
    {
        if (bankcode != tblbankbranch1.BankCode)
        {
            return BadRequest();
        }

        _context.Entry(tblbankbranch1).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblBankBranch1Exists(bankcode))
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

    // POST: api/TblBankBranch1
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblBankBranch1>> PostTblBankBranch1(TblBankBranch1 tblbankbranch1)
    {
        _context.TblBankBranches1.Add(tblbankbranch1);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblBankBranch1", new { bankcode = tblbankbranch1.BankCode }, tblbankbranch1);
    }

    // DELETE: api/TblBankBranch1/5
    [HttpDelete("{bankcode}")]
    public async Task<IActionResult> DeleteTblBankBranch1(string? bankcode)
    {
        var tblbankbranch1 = await _context.TblBankBranches1.FindAsync(bankcode);
        if (tblbankbranch1 == null)
        {
            return NotFound();
        }

        _context.TblBankBranches1.Remove(tblbankbranch1);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblBankBranch1Exists(string? bankcode)
    {
        return _context.TblBankBranches1.Any(e => e.BankCode == bankcode);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblBankBranchesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblBankBranchesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblBankBranch
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblBankBranch>>> GetTblBankBranch()
    {
        return await _context.TblBankBranches.ToListAsync();
    }

    // GET: api/TblBankBranch/5
    [HttpGet("{bankbranchid}")]
    public async Task<ActionResult<TblBankBranch>> GetTblBankBranch(int bankbranchid)
    {
        var tblbankbranch = await _context.TblBankBranches.FindAsync(bankbranchid);

        if (tblbankbranch == null)
        {
            return NotFound();
        }

        return tblbankbranch;
    }

    // PUT: api/TblBankBranch/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{bankbranchid}")]
    public async Task<IActionResult> PutTblBankBranch(int? bankbranchid, TblBankBranch tblbankbranch)
    {
        if (bankbranchid != tblbankbranch.BankbranchId)
        {
            return BadRequest();
        }

        _context.Entry(tblbankbranch).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblBankBranchExists(bankbranchid))
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

    // POST: api/TblBankBranch
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblBankBranch>> PostTblBankBranch(TblBankBranch tblbankbranch)
    {
        _context.TblBankBranches.Add(tblbankbranch);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblBankBranch", new { bankbranchid = tblbankbranch.BankbranchId }, tblbankbranch);
    }

    // DELETE: api/TblBankBranch/5
    [HttpDelete("{bankbranchid}")]
    public async Task<IActionResult> DeleteTblBankBranch(int? bankbranchid)
    {
        var tblbankbranch = await _context.TblBankBranches.FindAsync(bankbranchid);
        if (tblbankbranch == null)
        {
            return NotFound();
        }

        _context.TblBankBranches.Remove(tblbankbranch);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblBankBranchExists(int? bankbranchid)
    {
        return _context.TblBankBranches.Any(e => e.BankbranchId == bankbranchid);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblBankTransfersController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblBankTransfersController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblBankTransfer
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblBankTransfer>>> GetTblBankTransfer()
    {
        return await _context.TblBankTransfers.ToListAsync();
    }

    // GET: api/TblBankTransfer/5
    [HttpGet("{sfiheader}")]
    public async Task<ActionResult<TblBankTransfer>> GetTblBankTransfer(string sfiheader)
    {
        var tblbanktransfer = await _context.TblBankTransfers.FindAsync(sfiheader);

        if (tblbanktransfer == null)
        {
            return NotFound();
        }

        return tblbanktransfer;
    }

    // PUT: api/TblBankTransfer/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{sfiheader}")]
    public async Task<IActionResult> PutTblBankTransfer(string? sfiheader, TblBankTransfer tblbanktransfer)
    {
        if (sfiheader != tblbanktransfer.SfiHeader)
        {
            return BadRequest();
        }

        _context.Entry(tblbanktransfer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblBankTransferExists(sfiheader))
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

    // POST: api/TblBankTransfer
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblBankTransfer>> PostTblBankTransfer(TblBankTransfer tblbanktransfer)
    {
        _context.TblBankTransfers.Add(tblbanktransfer);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblBankTransfer", new { sfiheader = tblbanktransfer.SfiHeader }, tblbanktransfer);
    }

    // DELETE: api/TblBankTransfer/5
    [HttpDelete("{sfiheader}")]
    public async Task<IActionResult> DeleteTblBankTransfer(string? sfiheader)
    {
        var tblbanktransfer = await _context.TblBankTransfers.FindAsync(sfiheader);
        if (tblbanktransfer == null)
        {
            return NotFound();
        }

        _context.TblBankTransfers.Remove(tblbanktransfer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblBankTransferExists(string? sfiheader)
    {
        return _context.TblBankTransfers.Any(e => e.SfiHeader == sfiheader);
    }
}

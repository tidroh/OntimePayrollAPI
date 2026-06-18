using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblOverWritesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblOverWritesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblOverWrite
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblOverWrite>>> GetTblOverWrite()
    {
        return await _context.TblOverWrites.ToListAsync();
    }

    // GET: api/TblOverWrite/5
    [HttpGet("{transid}")]
    public async Task<ActionResult<TblOverWrite>> GetTblOverWrite(int transid)
    {
        var tbloverwrite = await _context.TblOverWrites.FindAsync(transid);

        if (tbloverwrite == null)
        {
            return NotFound();
        }

        return tbloverwrite;
    }

    // PUT: api/TblOverWrite/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{transid}")]
    public async Task<IActionResult> PutTblOverWrite(int? transid, TblOverWrite tbloverwrite)
    {
        if (transid != tbloverwrite.Transid)
        {
            return BadRequest();
        }

        _context.Entry(tbloverwrite).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblOverWriteExists(transid))
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

    // POST: api/TblOverWrite
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblOverWrite>> PostTblOverWrite(TblOverWrite tbloverwrite)
    {
        _context.TblOverWrites.Add(tbloverwrite);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblOverWrite", new { transid = tbloverwrite.Transid }, tbloverwrite);
    }

    // DELETE: api/TblOverWrite/5
    [HttpDelete("{transid}")]
    public async Task<IActionResult> DeleteTblOverWrite(int? transid)
    {
        var tbloverwrite = await _context.TblOverWrites.FindAsync(transid);
        if (tbloverwrite == null)
        {
            return NotFound();
        }

        _context.TblOverWrites.Remove(tbloverwrite);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblOverWriteExists(int? transid)
    {
        return _context.TblOverWrites.Any(e => e.Transid == transid);
    }
}

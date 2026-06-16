using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblJvsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblJvsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblJv
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblJv>>> GetTblJv()
    {
        return await _context.TblJvs.ToListAsync();
    }

    // GET: api/TblJv/5
    [HttpGet("{jvid}")]
    public async Task<ActionResult<TblJv>> GetTblJv(int jvid)
    {
        var tbljv = await _context.TblJvs.FindAsync(jvid);

        if (tbljv == null)
        {
            return NotFound();
        }

        return tbljv;
    }

    // PUT: api/TblJv/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{jvid}")]
    public async Task<IActionResult> PutTblJv(int? jvid, TblJv tbljv)
    {
        if (jvid != tbljv.Jvid)
        {
            return BadRequest();
        }

        _context.Entry(tbljv).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblJvExists(jvid))
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

    // POST: api/TblJv
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblJv>> PostTblJv(TblJv tbljv)
    {
        _context.TblJvs.Add(tbljv);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblJv", new { jvid = tbljv.Jvid }, tbljv);
    }

    // DELETE: api/TblJv/5
    [HttpDelete("{jvid}")]
    public async Task<IActionResult> DeleteTblJv(int? jvid)
    {
        var tbljv = await _context.TblJvs.FindAsync(jvid);
        if (tbljv == null)
        {
            return NotFound();
        }

        _context.TblJvs.Remove(tbljv);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblJvExists(int? jvid)
    {
        return _context.TblJvs.Any(e => e.Jvid == jvid);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblPayesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblPayesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblPaye
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblPaye>>> GetTblPaye()
    {
        return await _context.TblPayes.ToListAsync();
    }

    // GET: api/TblPaye/5
    [HttpGet("{payeid}")]
    public async Task<ActionResult<TblPaye>> GetTblPaye(int payeid)
    {
        var tblpaye = await _context.TblPayes.FindAsync(payeid);

        if (tblpaye == null)
        {
            return NotFound();
        }

        return tblpaye;
    }

    // PUT: api/TblPaye/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{payeid}")]
    public async Task<IActionResult> PutTblPaye(int? payeid, TblPaye tblpaye)
    {
        if (payeid != tblpaye.PayeId)
        {
            return BadRequest();
        }

        _context.Entry(tblpaye).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblPayeExists(payeid))
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

    // POST: api/TblPaye
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblPaye>> PostTblPaye(TblPaye tblpaye)
    {
        _context.TblPayes.Add(tblpaye);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblPaye", new { payeid = tblpaye.PayeId }, tblpaye);
    }

    // DELETE: api/TblPaye/5
    [HttpDelete("{payeid}")]
    public async Task<IActionResult> DeleteTblPaye(int? payeid)
    {
        var tblpaye = await _context.TblPayes.FindAsync(payeid);
        if (tblpaye == null)
        {
            return NotFound();
        }

        _context.TblPayes.Remove(tblpaye);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblPayeExists(int? payeid)
    {
        return _context.TblPayes.Any(e => e.PayeId == payeid);
    }
}

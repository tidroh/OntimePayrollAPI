using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblPayeUgandumsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblPayeUgandumsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblPayeUgandum
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblPayeUgandum>>> GetTblPayeUgandum()
    {
        return await _context.TblPayeUganda.ToListAsync();
    }

    // GET: api/TblPayeUgandum/5
    [HttpGet("{payeid}")]
    public async Task<ActionResult<TblPayeUgandum>> GetTblPayeUgandum(int payeid)
    {
        var tblpayeugandum = await _context.TblPayeUganda.FindAsync(payeid);

        if (tblpayeugandum == null)
        {
            return NotFound();
        }

        return tblpayeugandum;
    }

    // PUT: api/TblPayeUgandum/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{payeid}")]
    public async Task<IActionResult> PutTblPayeUgandum(int? payeid, TblPayeUgandum tblpayeugandum)
    {
        if (payeid != tblpayeugandum.PayeId)
        {
            return BadRequest();
        }

        _context.Entry(tblpayeugandum).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblPayeUgandumExists(payeid))
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

    // POST: api/TblPayeUgandum
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblPayeUgandum>> PostTblPayeUgandum(TblPayeUgandum tblpayeugandum)
    {
        _context.TblPayeUganda.Add(tblpayeugandum);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblPayeUgandum", new { payeid = tblpayeugandum.PayeId }, tblpayeugandum);
    }

    // DELETE: api/TblPayeUgandum/5
    [HttpDelete("{payeid}")]
    public async Task<IActionResult> DeleteTblPayeUgandum(int? payeid)
    {
        var tblpayeugandum = await _context.TblPayeUganda.FindAsync(payeid);
        if (tblpayeugandum == null)
        {
            return NotFound();
        }

        _context.TblPayeUganda.Remove(tblpayeugandum);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblPayeUgandumExists(int? payeid)
    {
        return _context.TblPayeUganda.Any(e => e.PayeId == payeid);
    }
}

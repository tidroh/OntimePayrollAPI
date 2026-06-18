using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblPayeTanzaniumsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblPayeTanzaniumsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblPayeTanzanium
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblPayeTanzanium>>> GetTblPayeTanzanium()
    {
        return await _context.TblPayeTanzania.ToListAsync();
    }

    // GET: api/TblPayeTanzanium/5
    [HttpGet("{payeid}")]
    public async Task<ActionResult<TblPayeTanzanium>> GetTblPayeTanzanium(int payeid)
    {
        var tblpayetanzanium = await _context.TblPayeTanzania.FindAsync(payeid);

        if (tblpayetanzanium == null)
        {
            return NotFound();
        }

        return tblpayetanzanium;
    }

    // PUT: api/TblPayeTanzanium/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{payeid}")]
    public async Task<IActionResult> PutTblPayeTanzanium(int? payeid, TblPayeTanzanium tblpayetanzanium)
    {
        if (payeid != tblpayetanzanium.PayeId)
        {
            return BadRequest();
        }

        _context.Entry(tblpayetanzanium).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblPayeTanzaniumExists(payeid))
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

    // POST: api/TblPayeTanzanium
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblPayeTanzanium>> PostTblPayeTanzanium(TblPayeTanzanium tblpayetanzanium)
    {
        _context.TblPayeTanzania.Add(tblpayetanzanium);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblPayeTanzanium", new { payeid = tblpayetanzanium.PayeId }, tblpayetanzanium);
    }

    // DELETE: api/TblPayeTanzanium/5
    [HttpDelete("{payeid}")]
    public async Task<IActionResult> DeleteTblPayeTanzanium(int? payeid)
    {
        var tblpayetanzanium = await _context.TblPayeTanzania.FindAsync(payeid);
        if (tblpayetanzanium == null)
        {
            return NotFound();
        }

        _context.TblPayeTanzania.Remove(tblpayetanzanium);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblPayeTanzaniumExists(int? payeid)
    {
        return _context.TblPayeTanzania.Any(e => e.PayeId == payeid);
    }
}

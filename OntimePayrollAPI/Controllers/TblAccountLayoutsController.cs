using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblAccountLayoutsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblAccountLayoutsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblAccountLayout
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblAccountLayout>>> GetTblAccountLayout()
    {
        return await _context.TblAccountLayouts.ToListAsync();
    }

    // GET: api/TblAccountLayout/5
    [HttpGet("{accountid}")]
    public async Task<ActionResult<TblAccountLayout>> GetTblAccountLayout(int accountid)
    {
        var tblaccountlayout = await _context.TblAccountLayouts.FindAsync(accountid);

        if (tblaccountlayout == null)
        {
            return NotFound();
        }

        return tblaccountlayout;
    }

    // PUT: api/TblAccountLayout/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{accountid}")]
    public async Task<IActionResult> PutTblAccountLayout(int? accountid, TblAccountLayout tblaccountlayout)
    {
        if (accountid != tblaccountlayout.Accountid)
        {
            return BadRequest();
        }

        _context.Entry(tblaccountlayout).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblAccountLayoutExists(accountid))
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

    // POST: api/TblAccountLayout
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblAccountLayout>> PostTblAccountLayout(TblAccountLayout tblaccountlayout)
    {
        _context.TblAccountLayouts.Add(tblaccountlayout);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblAccountLayout", new { accountid = tblaccountlayout.Accountid }, tblaccountlayout);
    }

    // DELETE: api/TblAccountLayout/5
    [HttpDelete("{accountid}")]
    public async Task<IActionResult> DeleteTblAccountLayout(int? accountid)
    {
        var tblaccountlayout = await _context.TblAccountLayouts.FindAsync(accountid);
        if (tblaccountlayout == null)
        {
            return NotFound();
        }

        _context.TblAccountLayouts.Remove(tblaccountlayout);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblAccountLayoutExists(int? accountid)
    {
        return _context.TblAccountLayouts.Any(e => e.Accountid == accountid);
    }
}

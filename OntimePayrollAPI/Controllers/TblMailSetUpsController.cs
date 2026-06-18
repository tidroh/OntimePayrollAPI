using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblMailSetUpsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblMailSetUpsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblMailSetUp
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblMailSetUp>>> GetTblMailSetUp()
    {
        return await _context.TblMailSetUps.ToListAsync();
    }

    // GET: api/TblMailSetUp/5
    [HttpGet("{mailsetupid}")]
    public async Task<ActionResult<TblMailSetUp>> GetTblMailSetUp(int mailsetupid)
    {
        var tblmailsetup = await _context.TblMailSetUps.FindAsync(mailsetupid);

        if (tblmailsetup == null)
        {
            return NotFound();
        }

        return tblmailsetup;
    }

    // PUT: api/TblMailSetUp/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{mailsetupid}")]
    public async Task<IActionResult> PutTblMailSetUp(int? mailsetupid, TblMailSetUp tblmailsetup)
    {
        if (mailsetupid != tblmailsetup.MailsetUpId)
        {
            return BadRequest();
        }

        _context.Entry(tblmailsetup).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblMailSetUpExists(mailsetupid))
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

    // POST: api/TblMailSetUp
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblMailSetUp>> PostTblMailSetUp(TblMailSetUp tblmailsetup)
    {
        _context.TblMailSetUps.Add(tblmailsetup);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblMailSetUp", new { mailsetupid = tblmailsetup.MailsetUpId }, tblmailsetup);
    }

    // DELETE: api/TblMailSetUp/5
    [HttpDelete("{mailsetupid}")]
    public async Task<IActionResult> DeleteTblMailSetUp(int? mailsetupid)
    {
        var tblmailsetup = await _context.TblMailSetUps.FindAsync(mailsetupid);
        if (tblmailsetup == null)
        {
            return NotFound();
        }

        _context.TblMailSetUps.Remove(tblmailsetup);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblMailSetUpExists(int? mailsetupid)
    {
        return _context.TblMailSetUps.Any(e => e.MailsetUpId == mailsetupid);
    }
}

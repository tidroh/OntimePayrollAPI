using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeMessagesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeMessagesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeMessage
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeMessage>>> GetTblEmployeeMessage()
    {
        return await _context.TblEmployeeMessages.ToListAsync();
    }

    // GET: api/TblEmployeeMessage/5
    [HttpGet("{messageid}")]
    public async Task<ActionResult<TblEmployeeMessage>> GetTblEmployeeMessage(int messageid)
    {
        var tblemployeemessage = await _context.TblEmployeeMessages.FindAsync(messageid);

        if (tblemployeemessage == null)
        {
            return NotFound();
        }

        return tblemployeemessage;
    }

    // PUT: api/TblEmployeeMessage/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{messageid}")]
    public async Task<IActionResult> PutTblEmployeeMessage(int? messageid, TblEmployeeMessage tblemployeemessage)
    {
        if (messageid != tblemployeemessage.MessageId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeemessage).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeMessageExists(messageid))
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

    // POST: api/TblEmployeeMessage
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeMessage>> PostTblEmployeeMessage(TblEmployeeMessage tblemployeemessage)
    {
        _context.TblEmployeeMessages.Add(tblemployeemessage);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeMessage", new { messageid = tblemployeemessage.MessageId }, tblemployeemessage);
    }

    // DELETE: api/TblEmployeeMessage/5
    [HttpDelete("{messageid}")]
    public async Task<IActionResult> DeleteTblEmployeeMessage(int? messageid)
    {
        var tblemployeemessage = await _context.TblEmployeeMessages.FindAsync(messageid);
        if (tblemployeemessage == null)
        {
            return NotFound();
        }

        _context.TblEmployeeMessages.Remove(tblemployeemessage);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeMessageExists(int? messageid)
    {
        return _context.TblEmployeeMessages.Any(e => e.MessageId == messageid);
    }
}

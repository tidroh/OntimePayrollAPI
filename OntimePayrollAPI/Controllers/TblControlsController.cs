using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblControlsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblControlsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblControl
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblControl>>> GetTblControl()
    {
        return await _context.TblControls.ToListAsync();
    }

    // GET: api/TblControl/5
    [HttpGet("{controlid}")]
    public async Task<ActionResult<TblControl>> GetTblControl(int controlid)
    {
        var tblcontrol = await _context.TblControls.FindAsync(controlid);

        if (tblcontrol == null)
        {
            return NotFound();
        }

        return tblcontrol;
    }

    // PUT: api/TblControl/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{controlid}")]
    public async Task<IActionResult> PutTblControl(int? controlid, TblControl tblcontrol)
    {
        if (controlid != tblcontrol.ControlId)
        {
            return BadRequest();
        }

        _context.Entry(tblcontrol).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblControlExists(controlid))
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

    // POST: api/TblControl
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblControl>> PostTblControl(TblControl tblcontrol)
    {
        _context.TblControls.Add(tblcontrol);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblControl", new { controlid = tblcontrol.ControlId }, tblcontrol);
    }

    // DELETE: api/TblControl/5
    [HttpDelete("{controlid}")]
    public async Task<IActionResult> DeleteTblControl(int? controlid)
    {
        var tblcontrol = await _context.TblControls.FindAsync(controlid);
        if (tblcontrol == null)
        {
            return NotFound();
        }

        _context.TblControls.Remove(tblcontrol);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblControlExists(int? controlid)
    {
        return _context.TblControls.Any(e => e.ControlId == controlid);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeePensionsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeePensionsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeePension
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeePension>>> GetTblEmployeePension()
    {
        return await _context.TblEmployeePensions.ToListAsync();
    }

    // GET: api/TblEmployeePension/5
    [HttpGet("{emppensionid}")]
    public async Task<ActionResult<TblEmployeePension>> GetTblEmployeePension(int emppensionid)
    {
        var tblemployeepension = await _context.TblEmployeePensions.FindAsync(emppensionid);

        if (tblemployeepension == null)
        {
            return NotFound();
        }

        return tblemployeepension;
    }

    // PUT: api/TblEmployeePension/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{emppensionid}")]
    public async Task<IActionResult> PutTblEmployeePension(int? emppensionid, TblEmployeePension tblemployeepension)
    {
        if (emppensionid != tblemployeepension.EmppensionId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeepension).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeePensionExists(emppensionid))
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

    // POST: api/TblEmployeePension
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeePension>> PostTblEmployeePension(TblEmployeePension tblemployeepension)
    {
        _context.TblEmployeePensions.Add(tblemployeepension);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeePension", new { emppensionid = tblemployeepension.EmppensionId }, tblemployeepension);
    }

    // DELETE: api/TblEmployeePension/5
    [HttpDelete("{emppensionid}")]
    public async Task<IActionResult> DeleteTblEmployeePension(int? emppensionid)
    {
        var tblemployeepension = await _context.TblEmployeePensions.FindAsync(emppensionid);
        if (tblemployeepension == null)
        {
            return NotFound();
        }

        _context.TblEmployeePensions.Remove(tblemployeepension);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeePensionExists(int? emppensionid)
    {
        return _context.TblEmployeePensions.Any(e => e.EmppensionId == emppensionid);
    }
}

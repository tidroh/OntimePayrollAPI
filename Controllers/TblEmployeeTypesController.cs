using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeTypesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeTypesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeType
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeType>>> GetTblEmployeeType()
    {
        return await _context.TblEmployeeTypes.ToListAsync();
    }

    // GET: api/TblEmployeeType/5
    [HttpGet("{emptypeid}")]
    public async Task<ActionResult<TblEmployeeType>> GetTblEmployeeType(int emptypeid)
    {
        var tblemployeetype = await _context.TblEmployeeTypes.FindAsync(emptypeid);

        if (tblemployeetype == null)
        {
            return NotFound();
        }

        return tblemployeetype;
    }

    // PUT: api/TblEmployeeType/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{emptypeid}")]
    public async Task<IActionResult> PutTblEmployeeType(int? emptypeid, TblEmployeeType tblemployeetype)
    {
        if (emptypeid != tblemployeetype.EmptypeId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeetype).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeTypeExists(emptypeid))
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

    // POST: api/TblEmployeeType
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeType>> PostTblEmployeeType(TblEmployeeType tblemployeetype)
    {
        _context.TblEmployeeTypes.Add(tblemployeetype);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeType", new { emptypeid = tblemployeetype.EmptypeId }, tblemployeetype);
    }

    // DELETE: api/TblEmployeeType/5
    [HttpDelete("{emptypeid}")]
    public async Task<IActionResult> DeleteTblEmployeeType(int? emptypeid)
    {
        var tblemployeetype = await _context.TblEmployeeTypes.FindAsync(emptypeid);
        if (tblemployeetype == null)
        {
            return NotFound();
        }

        _context.TblEmployeeTypes.Remove(tblemployeetype);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeTypeExists(int? emptypeid)
    {
        return _context.TblEmployeeTypes.Any(e => e.EmptypeId == emptypeid);
    }
}

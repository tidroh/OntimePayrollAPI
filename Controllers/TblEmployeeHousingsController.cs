using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeHousingsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeHousingsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeHousing
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeHousing>>> GetTblEmployeeHousing()
    {
        return await _context.TblEmployeeHousings.ToListAsync();
    }

    // GET: api/TblEmployeeHousing/5
    [HttpGet("{emphousingid}")]
    public async Task<ActionResult<TblEmployeeHousing>> GetTblEmployeeHousing(int emphousingid)
    {
        var tblemployeehousing = await _context.TblEmployeeHousings.FindAsync(emphousingid);

        if (tblemployeehousing == null)
        {
            return NotFound();
        }

        return tblemployeehousing;
    }

    // PUT: api/TblEmployeeHousing/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{emphousingid}")]
    public async Task<IActionResult> PutTblEmployeeHousing(int? emphousingid, TblEmployeeHousing tblemployeehousing)
    {
        if (emphousingid != tblemployeehousing.EmphousingId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeehousing).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeHousingExists(emphousingid))
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

    // POST: api/TblEmployeeHousing
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeHousing>> PostTblEmployeeHousing(TblEmployeeHousing tblemployeehousing)
    {
        _context.TblEmployeeHousings.Add(tblemployeehousing);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeHousing", new { emphousingid = tblemployeehousing.EmphousingId }, tblemployeehousing);
    }

    // DELETE: api/TblEmployeeHousing/5
    [HttpDelete("{emphousingid}")]
    public async Task<IActionResult> DeleteTblEmployeeHousing(int? emphousingid)
    {
        var tblemployeehousing = await _context.TblEmployeeHousings.FindAsync(emphousingid);
        if (tblemployeehousing == null)
        {
            return NotFound();
        }

        _context.TblEmployeeHousings.Remove(tblemployeehousing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeHousingExists(int? emphousingid)
    {
        return _context.TblEmployeeHousings.Any(e => e.EmphousingId == emphousingid);
    }
}

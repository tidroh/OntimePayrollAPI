using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeRemunerationsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeRemunerationsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeRemuneration
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeRemuneration>>> GetTblEmployeeRemuneration()
    {
        return await _context.TblEmployeeRemunerations.ToListAsync();
    }

    // GET: api/TblEmployeeRemuneration/5
    [HttpGet("{emprenumid}")]
    public async Task<ActionResult<TblEmployeeRemuneration>> GetTblEmployeeRemuneration(int emprenumid)
    {
        var tblemployeeremuneration = await _context.TblEmployeeRemunerations.FindAsync(emprenumid);

        if (tblemployeeremuneration == null)
        {
            return NotFound();
        }

        return tblemployeeremuneration;
    }

    // PUT: api/TblEmployeeRemuneration/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{emprenumid}")]
    public async Task<IActionResult> PutTblEmployeeRemuneration(int? emprenumid, TblEmployeeRemuneration tblemployeeremuneration)
    {
        if (emprenumid != tblemployeeremuneration.EmprenumId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeeremuneration).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeRemunerationExists(emprenumid))
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

    // POST: api/TblEmployeeRemuneration
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeRemuneration>> PostTblEmployeeRemuneration(TblEmployeeRemuneration tblemployeeremuneration)
    {
        _context.TblEmployeeRemunerations.Add(tblemployeeremuneration);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeRemuneration", new { emprenumid = tblemployeeremuneration.EmprenumId }, tblemployeeremuneration);
    }

    // DELETE: api/TblEmployeeRemuneration/5
    [HttpDelete("{emprenumid}")]
    public async Task<IActionResult> DeleteTblEmployeeRemuneration(int? emprenumid)
    {
        var tblemployeeremuneration = await _context.TblEmployeeRemunerations.FindAsync(emprenumid);
        if (tblemployeeremuneration == null)
        {
            return NotFound();
        }

        _context.TblEmployeeRemunerations.Remove(tblemployeeremuneration);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeRemunerationExists(int? emprenumid)
    {
        return _context.TblEmployeeRemunerations.Any(e => e.EmprenumId == emprenumid);
    }
}

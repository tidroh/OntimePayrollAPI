using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeBonusController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeBonusController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeBonu
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeBonu>>> GetTblEmployeeBonu()
    {
        return await _context.TblEmployeeBonus.ToListAsync();
    }

    // GET: api/TblEmployeeBonu/5
    [HttpGet("{empbonusid}")]
    public async Task<ActionResult<TblEmployeeBonu>> GetTblEmployeeBonu(int empbonusid)
    {
        var tblemployeebonu = await _context.TblEmployeeBonus.FindAsync(empbonusid);

        if (tblemployeebonu == null)
        {
            return NotFound();
        }

        return tblemployeebonu;
    }

    // PUT: api/TblEmployeeBonu/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{empbonusid}")]
    public async Task<IActionResult> PutTblEmployeeBonu(int? empbonusid, TblEmployeeBonu tblemployeebonu)
    {
        if (empbonusid != tblemployeebonu.EmpbonusId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeebonu).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeBonuExists(empbonusid))
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

    // POST: api/TblEmployeeBonu
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeBonu>> PostTblEmployeeBonu(TblEmployeeBonu tblemployeebonu)
    {
        _context.TblEmployeeBonus.Add(tblemployeebonu);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeBonu", new { empbonusid = tblemployeebonu.EmpbonusId }, tblemployeebonu);
    }

    // DELETE: api/TblEmployeeBonu/5
    [HttpDelete("{empbonusid}")]
    public async Task<IActionResult> DeleteTblEmployeeBonu(int? empbonusid)
    {
        var tblemployeebonu = await _context.TblEmployeeBonus.FindAsync(empbonusid);
        if (tblemployeebonu == null)
        {
            return NotFound();
        }

        _context.TblEmployeeBonus.Remove(tblemployeebonu);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeBonuExists(int? empbonusid)
    {
        return _context.TblEmployeeBonus.Any(e => e.EmpbonusId == empbonusid);
    }
}

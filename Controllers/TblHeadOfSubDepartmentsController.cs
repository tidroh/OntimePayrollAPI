using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblHeadOfSubDepartmentsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblHeadOfSubDepartmentsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblHeadOfSubDepartment
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblHeadOfSubDepartment>>> GetTblHeadOfSubDepartment()
    {
        return await _context.TblHeadOfSubDepartments.ToListAsync();
    }

    // GET: api/TblHeadOfSubDepartment/5
    [HttpGet("{hosdid}")]
    public async Task<ActionResult<TblHeadOfSubDepartment>> GetTblHeadOfSubDepartment(int hosdid)
    {
        var tblheadofsubdepartment = await _context.TblHeadOfSubDepartments.FindAsync(hosdid);

        if (tblheadofsubdepartment == null)
        {
            return NotFound();
        }

        return tblheadofsubdepartment;
    }

    // PUT: api/TblHeadOfSubDepartment/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{hosdid}")]
    public async Task<IActionResult> PutTblHeadOfSubDepartment(int? hosdid, TblHeadOfSubDepartment tblheadofsubdepartment)
    {
        if (hosdid != tblheadofsubdepartment.HosdId)
        {
            return BadRequest();
        }

        _context.Entry(tblheadofsubdepartment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblHeadOfSubDepartmentExists(hosdid))
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

    // POST: api/TblHeadOfSubDepartment
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblHeadOfSubDepartment>> PostTblHeadOfSubDepartment(TblHeadOfSubDepartment tblheadofsubdepartment)
    {
        _context.TblHeadOfSubDepartments.Add(tblheadofsubdepartment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblHeadOfSubDepartment", new { hosdid = tblheadofsubdepartment.HosdId }, tblheadofsubdepartment);
    }

    // DELETE: api/TblHeadOfSubDepartment/5
    [HttpDelete("{hosdid}")]
    public async Task<IActionResult> DeleteTblHeadOfSubDepartment(int? hosdid)
    {
        var tblheadofsubdepartment = await _context.TblHeadOfSubDepartments.FindAsync(hosdid);
        if (tblheadofsubdepartment == null)
        {
            return NotFound();
        }

        _context.TblHeadOfSubDepartments.Remove(tblheadofsubdepartment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblHeadOfSubDepartmentExists(int? hosdid)
    {
        return _context.TblHeadOfSubDepartments.Any(e => e.HosdId == hosdid);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblHeadOfDepartmentsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblHeadOfDepartmentsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblHeadOfDepartment
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblHeadOfDepartment>>> GetTblHeadOfDepartment()
    {
        return await _context.TblHeadOfDepartments.ToListAsync();
    }

    // GET: api/TblHeadOfDepartment/5
    [HttpGet("{hodid}")]
    public async Task<ActionResult<TblHeadOfDepartment>> GetTblHeadOfDepartment(int hodid)
    {
        var tblheadofdepartment = await _context.TblHeadOfDepartments.FindAsync(hodid);

        if (tblheadofdepartment == null)
        {
            return NotFound();
        }

        return tblheadofdepartment;
    }

    // PUT: api/TblHeadOfDepartment/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{hodid}")]
    public async Task<IActionResult> PutTblHeadOfDepartment(int? hodid, TblHeadOfDepartment tblheadofdepartment)
    {
        if (hodid != tblheadofdepartment.HodId)
        {
            return BadRequest();
        }

        _context.Entry(tblheadofdepartment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblHeadOfDepartmentExists(hodid))
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

    // POST: api/TblHeadOfDepartment
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblHeadOfDepartment>> PostTblHeadOfDepartment(TblHeadOfDepartment tblheadofdepartment)
    {
        _context.TblHeadOfDepartments.Add(tblheadofdepartment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblHeadOfDepartment", new { hodid = tblheadofdepartment.HodId }, tblheadofdepartment);
    }

    // DELETE: api/TblHeadOfDepartment/5
    [HttpDelete("{hodid}")]
    public async Task<IActionResult> DeleteTblHeadOfDepartment(int? hodid)
    {
        var tblheadofdepartment = await _context.TblHeadOfDepartments.FindAsync(hodid);
        if (tblheadofdepartment == null)
        {
            return NotFound();
        }

        _context.TblHeadOfDepartments.Remove(tblheadofdepartment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblHeadOfDepartmentExists(int? hodid)
    {
        return _context.TblHeadOfDepartments.Any(e => e.HodId == hodid);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblModulesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblModulesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblModule
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblModule>>> GetTblModule()
    {
        return await _context.TblModules.ToListAsync();
    }

    // GET: api/TblModule/5
    [HttpGet("{moduleid}")]
    public async Task<ActionResult<TblModule>> GetTblModule(int moduleid)
    {
        var tblmodule = await _context.TblModules.FindAsync(moduleid);

        if (tblmodule == null)
        {
            return NotFound();
        }

        return tblmodule;
    }

    // PUT: api/TblModule/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{moduleid}")]
    public async Task<IActionResult> PutTblModule(int? moduleid, TblModule tblmodule)
    {
        if (moduleid != tblmodule.ModuleId)
        {
            return BadRequest();
        }

        _context.Entry(tblmodule).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblModuleExists(moduleid))
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

    // POST: api/TblModule
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblModule>> PostTblModule(TblModule tblmodule)
    {
        _context.TblModules.Add(tblmodule);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblModule", new { moduleid = tblmodule.ModuleId }, tblmodule);
    }

    // DELETE: api/TblModule/5
    [HttpDelete("{moduleid}")]
    public async Task<IActionResult> DeleteTblModule(int? moduleid)
    {
        var tblmodule = await _context.TblModules.FindAsync(moduleid);
        if (tblmodule == null)
        {
            return NotFound();
        }

        _context.TblModules.Remove(tblmodule);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblModuleExists(int? moduleid)
    {
        return _context.TblModules.Any(e => e.ModuleId == moduleid);
    }
}

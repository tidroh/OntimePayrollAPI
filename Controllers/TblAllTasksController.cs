using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblAllTasksController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblAllTasksController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblAllTask
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblAllTask>>> GetTblAllTask()
    {
        return await _context.TblAllTasks.ToListAsync();
    }

    // GET: api/TblAllTask/5
    [HttpGet("{moduleid}")]
    public async Task<ActionResult<TblAllTask>> GetTblAllTask(int moduleid)
    {
        var tblalltask = await _context.TblAllTasks.FindAsync(moduleid);

        if (tblalltask == null)
        {
            return NotFound();
        }

        return tblalltask;
    }

    // PUT: api/TblAllTask/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{moduleid}")]
    public async Task<IActionResult> PutTblAllTask(int? moduleid, TblAllTask tblalltask)
    {
        if (moduleid != tblalltask.ModuleId)
        {
            return BadRequest();
        }

        _context.Entry(tblalltask).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblAllTaskExists(moduleid))
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

    // POST: api/TblAllTask
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblAllTask>> PostTblAllTask(TblAllTask tblalltask)
    {
        _context.TblAllTasks.Add(tblalltask);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblAllTask", new { moduleid = tblalltask.ModuleId }, tblalltask);
    }

    // DELETE: api/TblAllTask/5
    [HttpDelete("{moduleid}")]
    public async Task<IActionResult> DeleteTblAllTask(int? moduleid)
    {
        var tblalltask = await _context.TblAllTasks.FindAsync(moduleid);
        if (tblalltask == null)
        {
            return NotFound();
        }

        _context.TblAllTasks.Remove(tblalltask);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblAllTaskExists(int? moduleid)
    {
        return _context.TblAllTasks.Any(e => e.ModuleId == moduleid);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblAssignedRightsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblAssignedRightsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblAssignedRight
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblAssignedRight>>> GetTblAssignedRight()
    {
        return await _context.TblAssignedRights.ToListAsync();
    }

    // GET: api/TblAssignedRight/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblAssignedRight>> GetTblAssignedRight(int id)
    {
        var tblassignedright = await _context.TblAssignedRights.FindAsync(id);

        if (tblassignedright == null)
        {
            return NotFound();
        }

        return tblassignedright;
    }

    // PUT: api/TblAssignedRight/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblAssignedRight(int? id, TblAssignedRight tblassignedright)
    {
        if (id != tblassignedright.Id)
        {
            return BadRequest();
        }

        _context.Entry(tblassignedright).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblAssignedRightExists(id))
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

    // POST: api/TblAssignedRight
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblAssignedRight>> PostTblAssignedRight(TblAssignedRight tblassignedright)
    {
        _context.TblAssignedRights.Add(tblassignedright);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblAssignedRight", new { id = tblassignedright.Id }, tblassignedright);
    }

    // DELETE: api/TblAssignedRight/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblAssignedRight(int? id)
    {
        var tblassignedright = await _context.TblAssignedRights.FindAsync(id);
        if (tblassignedright == null)
        {
            return NotFound();
        }

        _context.TblAssignedRights.Remove(tblassignedright);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblAssignedRightExists(int? id)
    {
        return _context.TblAssignedRights.Any(e => e.Id == id);
    }
}

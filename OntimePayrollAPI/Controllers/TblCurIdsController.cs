using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblCurIdsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblCurIdsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblCurId
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblCurId>>> GetTblCurId()
    {
        return await _context.TblCurIds.ToListAsync();
    }

    // GET: api/TblCurId/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblCurId>> GetTblCurId(int id)
    {
        var tblcurid = await _context.TblCurIds.FindAsync(id);

        if (tblcurid == null)
        {
            return NotFound();
        }

        return tblcurid;
    }

    // PUT: api/TblCurId/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblCurId(int? id, TblCurId tblcurid)
    {
        if (id != tblcurid.Id)
        {
            return BadRequest();
        }

        _context.Entry(tblcurid).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblCurIdExists(id))
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

    // POST: api/TblCurId
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblCurId>> PostTblCurId(TblCurId tblcurid)
    {
        _context.TblCurIds.Add(tblcurid);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblCurId", new { id = tblcurid.Id }, tblcurid);
    }

    // DELETE: api/TblCurId/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblCurId(int? id)
    {
        var tblcurid = await _context.TblCurIds.FindAsync(id);
        if (tblcurid == null)
        {
            return NotFound();
        }

        _context.TblCurIds.Remove(tblcurid);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblCurIdExists(int? id)
    {
        return _context.TblCurIds.Any(e => e.Id == id);
    }
}

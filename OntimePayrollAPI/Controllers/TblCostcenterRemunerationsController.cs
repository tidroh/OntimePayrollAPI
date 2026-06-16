using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblCostcenterRemunerationsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblCostcenterRemunerationsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblCostcenterRemuneration
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblCostcenterRemuneration>>> GetTblCostcenterRemuneration()
    {
        return await _context.TblCostcenterRemunerations.ToListAsync();
    }

    // GET: api/TblCostcenterRemuneration/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblCostcenterRemuneration>> GetTblCostcenterRemuneration(int id)
    {
        var tblcostcenterremuneration = await _context.TblCostcenterRemunerations.FindAsync(id);

        if (tblcostcenterremuneration == null)
        {
            return NotFound();
        }

        return tblcostcenterremuneration;
    }

    // PUT: api/TblCostcenterRemuneration/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblCostcenterRemuneration(int? id, TblCostcenterRemuneration tblcostcenterremuneration)
    {
        if (id != tblcostcenterremuneration.Id)
        {
            return BadRequest();
        }

        _context.Entry(tblcostcenterremuneration).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblCostcenterRemunerationExists(id))
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

    // POST: api/TblCostcenterRemuneration
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblCostcenterRemuneration>> PostTblCostcenterRemuneration(TblCostcenterRemuneration tblcostcenterremuneration)
    {
        _context.TblCostcenterRemunerations.Add(tblcostcenterremuneration);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblCostcenterRemuneration", new { id = tblcostcenterremuneration.Id }, tblcostcenterremuneration);
    }

    // DELETE: api/TblCostcenterRemuneration/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblCostcenterRemuneration(int? id)
    {
        var tblcostcenterremuneration = await _context.TblCostcenterRemunerations.FindAsync(id);
        if (tblcostcenterremuneration == null)
        {
            return NotFound();
        }

        _context.TblCostcenterRemunerations.Remove(tblcostcenterremuneration);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblCostcenterRemunerationExists(int? id)
    {
        return _context.TblCostcenterRemunerations.Any(e => e.Id == id);
    }
}

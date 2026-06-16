using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblCostCentersController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblCostCentersController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblCostCenter
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblCostCenter>>> GetTblCostCenter()
    {
        return await _context.TblCostCenters.ToListAsync();
    }

    // GET: api/TblCostCenter/5
    [HttpGet("{costcenterid}")]
    public async Task<ActionResult<TblCostCenter>> GetTblCostCenter(int costcenterid)
    {
        var tblcostcenter = await _context.TblCostCenters.FindAsync(costcenterid);

        if (tblcostcenter == null)
        {
            return NotFound();
        }

        return tblcostcenter;
    }

    // PUT: api/TblCostCenter/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{costcenterid}")]
    public async Task<IActionResult> PutTblCostCenter(int? costcenterid, TblCostCenter tblcostcenter)
    {
        if (costcenterid != tblcostcenter.CostcenterId)
        {
            return BadRequest();
        }

        _context.Entry(tblcostcenter).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblCostCenterExists(costcenterid))
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

    // POST: api/TblCostCenter
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblCostCenter>> PostTblCostCenter(TblCostCenter tblcostcenter)
    {
        _context.TblCostCenters.Add(tblcostcenter);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblCostCenter", new { costcenterid = tblcostcenter.CostcenterId }, tblcostcenter);
    }

    // DELETE: api/TblCostCenter/5
    [HttpDelete("{costcenterid}")]
    public async Task<IActionResult> DeleteTblCostCenter(int? costcenterid)
    {
        var tblcostcenter = await _context.TblCostCenters.FindAsync(costcenterid);
        if (tblcostcenter == null)
        {
            return NotFound();
        }

        _context.TblCostCenters.Remove(tblcostcenter);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblCostCenterExists(int? costcenterid)
    {
        return _context.TblCostCenters.Any(e => e.CostcenterId == costcenterid);
    }
}

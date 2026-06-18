using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblHomeOwnershipSavingsPlansController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblHomeOwnershipSavingsPlansController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblHomeOwnershipSavingsPlan
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblHomeOwnershipSavingsPlan>>> GetTblHomeOwnershipSavingsPlan()
    {
        return await _context.TblHomeOwnershipSavingsPlans.ToListAsync();
    }

    // GET: api/TblHomeOwnershipSavingsPlan/5
    [HttpGet("{planid}")]
    public async Task<ActionResult<TblHomeOwnershipSavingsPlan>> GetTblHomeOwnershipSavingsPlan(int planid)
    {
        var tblhomeownershipsavingsplan = await _context.TblHomeOwnershipSavingsPlans.FindAsync(planid);

        if (tblhomeownershipsavingsplan == null)
        {
            return NotFound();
        }

        return tblhomeownershipsavingsplan;
    }

    // PUT: api/TblHomeOwnershipSavingsPlan/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{planid}")]
    public async Task<IActionResult> PutTblHomeOwnershipSavingsPlan(int? planid, TblHomeOwnershipSavingsPlan tblhomeownershipsavingsplan)
    {
        if (planid != tblhomeownershipsavingsplan.PlanId)
        {
            return BadRequest();
        }

        _context.Entry(tblhomeownershipsavingsplan).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblHomeOwnershipSavingsPlanExists(planid))
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

    // POST: api/TblHomeOwnershipSavingsPlan
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblHomeOwnershipSavingsPlan>> PostTblHomeOwnershipSavingsPlan(TblHomeOwnershipSavingsPlan tblhomeownershipsavingsplan)
    {
        _context.TblHomeOwnershipSavingsPlans.Add(tblhomeownershipsavingsplan);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblHomeOwnershipSavingsPlan", new { planid = tblhomeownershipsavingsplan.PlanId }, tblhomeownershipsavingsplan);
    }

    // DELETE: api/TblHomeOwnershipSavingsPlan/5
    [HttpDelete("{planid}")]
    public async Task<IActionResult> DeleteTblHomeOwnershipSavingsPlan(int? planid)
    {
        var tblhomeownershipsavingsplan = await _context.TblHomeOwnershipSavingsPlans.FindAsync(planid);
        if (tblhomeownershipsavingsplan == null)
        {
            return NotFound();
        }

        _context.TblHomeOwnershipSavingsPlans.Remove(tblhomeownershipsavingsplan);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblHomeOwnershipSavingsPlanExists(int? planid)
    {
        return _context.TblHomeOwnershipSavingsPlans.Any(e => e.PlanId == planid);
    }
}

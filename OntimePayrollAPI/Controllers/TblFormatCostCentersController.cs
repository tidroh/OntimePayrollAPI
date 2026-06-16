using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblFormatCostCentersController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblFormatCostCentersController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblFormatCostCenter
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblFormatCostCenter>>> GetTblFormatCostCenter()
    {
        return await _context.TblFormatCostCenters.ToListAsync();
    }

    // GET: api/TblFormatCostCenter/5
    [HttpGet("{formatcostcenterid}")]
    public async Task<ActionResult<TblFormatCostCenter>> GetTblFormatCostCenter(int formatcostcenterid)
    {
        var tblformatcostcenter = await _context.TblFormatCostCenters.FindAsync(formatcostcenterid);

        if (tblformatcostcenter == null)
        {
            return NotFound();
        }

        return tblformatcostcenter;
    }

    // PUT: api/TblFormatCostCenter/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{formatcostcenterid}")]
    public async Task<IActionResult> PutTblFormatCostCenter(int? formatcostcenterid, TblFormatCostCenter tblformatcostcenter)
    {
        if (formatcostcenterid != tblformatcostcenter.FormatCostCenterId)
        {
            return BadRequest();
        }

        _context.Entry(tblformatcostcenter).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblFormatCostCenterExists(formatcostcenterid))
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

    // POST: api/TblFormatCostCenter
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblFormatCostCenter>> PostTblFormatCostCenter(TblFormatCostCenter tblformatcostcenter)
    {
        _context.TblFormatCostCenters.Add(tblformatcostcenter);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblFormatCostCenter", new { formatcostcenterid = tblformatcostcenter.FormatCostCenterId }, tblformatcostcenter);
    }

    // DELETE: api/TblFormatCostCenter/5
    [HttpDelete("{formatcostcenterid}")]
    public async Task<IActionResult> DeleteTblFormatCostCenter(int? formatcostcenterid)
    {
        var tblformatcostcenter = await _context.TblFormatCostCenters.FindAsync(formatcostcenterid);
        if (tblformatcostcenter == null)
        {
            return NotFound();
        }

        _context.TblFormatCostCenters.Remove(tblformatcostcenter);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblFormatCostCenterExists(int? formatcostcenterid)
    {
        return _context.TblFormatCostCenters.Any(e => e.FormatCostCenterId == formatcostcenterid);
    }
}

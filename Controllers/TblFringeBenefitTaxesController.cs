using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblFringeBenefitTaxesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblFringeBenefitTaxesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblFringeBenefitTax
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblFringeBenefitTax>>> GetTblFringeBenefitTax()
    {
        return await _context.TblFringeBenefitTaxes.ToListAsync();
    }

    // GET: api/TblFringeBenefitTax/5
    [HttpGet("{fringebenefitid}")]
    public async Task<ActionResult<TblFringeBenefitTax>> GetTblFringeBenefitTax(int fringebenefitid)
    {
        var tblfringebenefittax = await _context.TblFringeBenefitTaxes.FindAsync(fringebenefitid);

        if (tblfringebenefittax == null)
        {
            return NotFound();
        }

        return tblfringebenefittax;
    }

    // PUT: api/TblFringeBenefitTax/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{fringebenefitid}")]
    public async Task<IActionResult> PutTblFringeBenefitTax(int? fringebenefitid, TblFringeBenefitTax tblfringebenefittax)
    {
        if (fringebenefitid != tblfringebenefittax.FringebenefitId)
        {
            return BadRequest();
        }

        _context.Entry(tblfringebenefittax).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblFringeBenefitTaxExists(fringebenefitid))
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

    // POST: api/TblFringeBenefitTax
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblFringeBenefitTax>> PostTblFringeBenefitTax(TblFringeBenefitTax tblfringebenefittax)
    {
        _context.TblFringeBenefitTaxes.Add(tblfringebenefittax);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblFringeBenefitTax", new { fringebenefitid = tblfringebenefittax.FringebenefitId }, tblfringebenefittax);
    }

    // DELETE: api/TblFringeBenefitTax/5
    [HttpDelete("{fringebenefitid}")]
    public async Task<IActionResult> DeleteTblFringeBenefitTax(int? fringebenefitid)
    {
        var tblfringebenefittax = await _context.TblFringeBenefitTaxes.FindAsync(fringebenefitid);
        if (tblfringebenefittax == null)
        {
            return NotFound();
        }

        _context.TblFringeBenefitTaxes.Remove(tblfringebenefittax);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblFringeBenefitTaxExists(int? fringebenefitid)
    {
        return _context.TblFringeBenefitTaxes.Any(e => e.FringebenefitId == fringebenefitid);
    }
}

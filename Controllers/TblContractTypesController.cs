using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblContractTypesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblContractTypesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblContractType
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblContractType>>> GetTblContractType()
    {
        return await _context.TblContractTypes.ToListAsync();
    }

    // GET: api/TblContractType/5
    [HttpGet("{contcode}")]
    public async Task<ActionResult<TblContractType>> GetTblContractType(string contcode)
    {
        var tblcontracttype = await _context.TblContractTypes.FindAsync(contcode);

        if (tblcontracttype == null)
        {
            return NotFound();
        }

        return tblcontracttype;
    }

    // PUT: api/TblContractType/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{contcode}")]
    public async Task<IActionResult> PutTblContractType(string? contcode, TblContractType tblcontracttype)
    {
        if (contcode != tblcontracttype.ContCode)
        {
            return BadRequest();
        }

        _context.Entry(tblcontracttype).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblContractTypeExists(contcode))
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

    // POST: api/TblContractType
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblContractType>> PostTblContractType(TblContractType tblcontracttype)
    {
        _context.TblContractTypes.Add(tblcontracttype);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblContractType", new { contcode = tblcontracttype.ContCode }, tblcontracttype);
    }

    // DELETE: api/TblContractType/5
    [HttpDelete("{contcode}")]
    public async Task<IActionResult> DeleteTblContractType(string? contcode)
    {
        var tblcontracttype = await _context.TblContractTypes.FindAsync(contcode);
        if (tblcontracttype == null)
        {
            return NotFound();
        }

        _context.TblContractTypes.Remove(tblcontracttype);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblContractTypeExists(string? contcode)
    {
        return _context.TblContractTypes.Any(e => e.ContCode == contcode);
    }
}

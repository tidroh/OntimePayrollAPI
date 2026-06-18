using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeCasualPaymentCriterionsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeCasualPaymentCriterionsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeCasualPaymentCriterion
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeCasualPaymentCriterion>>> GetTblEmployeeCasualPaymentCriterion()
    {
        return await _context.TblEmployeeCasualPaymentCriteria.ToListAsync();
    }

    // GET: api/TblEmployeeCasualPaymentCriterion/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblEmployeeCasualPaymentCriterion>> GetTblEmployeeCasualPaymentCriterion(int id)
    {
        var tblemployeecasualpaymentcriterion = await _context.TblEmployeeCasualPaymentCriteria.FindAsync(id);

        if (tblemployeecasualpaymentcriterion == null)
        {
            return NotFound();
        }

        return tblemployeecasualpaymentcriterion;
    }

    // PUT: api/TblEmployeeCasualPaymentCriterion/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblEmployeeCasualPaymentCriterion(int? id, TblEmployeeCasualPaymentCriterion tblemployeecasualpaymentcriterion)
    {
        if (id != tblemployeecasualpaymentcriterion.Id)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeecasualpaymentcriterion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeCasualPaymentCriterionExists(id))
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

    // POST: api/TblEmployeeCasualPaymentCriterion
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeCasualPaymentCriterion>> PostTblEmployeeCasualPaymentCriterion(TblEmployeeCasualPaymentCriterion tblemployeecasualpaymentcriterion)
    {
        _context.TblEmployeeCasualPaymentCriteria.Add(tblemployeecasualpaymentcriterion);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeCasualPaymentCriterion", new { id = tblemployeecasualpaymentcriterion.Id }, tblemployeecasualpaymentcriterion);
    }

    // DELETE: api/TblEmployeeCasualPaymentCriterion/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblEmployeeCasualPaymentCriterion(int? id)
    {
        var tblemployeecasualpaymentcriterion = await _context.TblEmployeeCasualPaymentCriteria.FindAsync(id);
        if (tblemployeecasualpaymentcriterion == null)
        {
            return NotFound();
        }

        _context.TblEmployeeCasualPaymentCriteria.Remove(tblemployeecasualpaymentcriterion);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeCasualPaymentCriterionExists(int? id)
    {
        return _context.TblEmployeeCasualPaymentCriteria.Any(e => e.Id == id);
    }
}

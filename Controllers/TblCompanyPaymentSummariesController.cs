using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblCompanyPaymentSummariesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblCompanyPaymentSummariesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblCompanyPaymentSummary
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblCompanyPaymentSummary>>> GetTblCompanyPaymentSummary()
    {
        return await _context.TblCompanyPaymentSummaries.ToListAsync();
    }

    // GET: api/TblCompanyPaymentSummary/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblCompanyPaymentSummary>> GetTblCompanyPaymentSummary(int id)
    {
        var tblcompanypaymentsummary = await _context.TblCompanyPaymentSummaries.FindAsync(id);

        if (tblcompanypaymentsummary == null)
        {
            return NotFound();
        }

        return tblcompanypaymentsummary;
    }

    // PUT: api/TblCompanyPaymentSummary/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblCompanyPaymentSummary(int? id, TblCompanyPaymentSummary tblcompanypaymentsummary)
    {
        if (id != tblcompanypaymentsummary.Id)
        {
            return BadRequest();
        }

        _context.Entry(tblcompanypaymentsummary).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblCompanyPaymentSummaryExists(id))
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

    // POST: api/TblCompanyPaymentSummary
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblCompanyPaymentSummary>> PostTblCompanyPaymentSummary(TblCompanyPaymentSummary tblcompanypaymentsummary)
    {
        _context.TblCompanyPaymentSummaries.Add(tblcompanypaymentsummary);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblCompanyPaymentSummary", new { id = tblcompanypaymentsummary.Id }, tblcompanypaymentsummary);
    }

    // DELETE: api/TblCompanyPaymentSummary/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblCompanyPaymentSummary(int? id)
    {
        var tblcompanypaymentsummary = await _context.TblCompanyPaymentSummaries.FindAsync(id);
        if (tblcompanypaymentsummary == null)
        {
            return NotFound();
        }

        _context.TblCompanyPaymentSummaries.Remove(tblcompanypaymentsummary);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblCompanyPaymentSummaryExists(int? id)
    {
        return _context.TblCompanyPaymentSummaries.Any(e => e.Id == id);
    }
}

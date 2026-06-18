using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblPasswordRulesController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblPasswordRulesController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblPasswordRule
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblPasswordRule>>> GetTblPasswordRule()
    {
        return await _context.TblPasswordRules.ToListAsync();
    }

    // GET: api/TblPasswordRule/5
    [HttpGet("{ruleid}")]
    public async Task<ActionResult<TblPasswordRule>> GetTblPasswordRule(int ruleid)
    {
        var tblpasswordrule = await _context.TblPasswordRules.FindAsync(ruleid);

        if (tblpasswordrule == null)
        {
            return NotFound();
        }

        return tblpasswordrule;
    }

    // PUT: api/TblPasswordRule/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{ruleid}")]
    public async Task<IActionResult> PutTblPasswordRule(int? ruleid, TblPasswordRule tblpasswordrule)
    {
        if (ruleid != tblpasswordrule.RuleId)
        {
            return BadRequest();
        }

        _context.Entry(tblpasswordrule).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblPasswordRuleExists(ruleid))
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

    // POST: api/TblPasswordRule
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblPasswordRule>> PostTblPasswordRule(TblPasswordRule tblpasswordrule)
    {
        _context.TblPasswordRules.Add(tblpasswordrule);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblPasswordRule", new { ruleid = tblpasswordrule.RuleId }, tblpasswordrule);
    }

    // DELETE: api/TblPasswordRule/5
    [HttpDelete("{ruleid}")]
    public async Task<IActionResult> DeleteTblPasswordRule(int? ruleid)
    {
        var tblpasswordrule = await _context.TblPasswordRules.FindAsync(ruleid);
        if (tblpasswordrule == null)
        {
            return NotFound();
        }

        _context.TblPasswordRules.Remove(tblpasswordrule);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblPasswordRuleExists(int? ruleid)
    {
        return _context.TblPasswordRules.Any(e => e.RuleId == ruleid);
    }
}

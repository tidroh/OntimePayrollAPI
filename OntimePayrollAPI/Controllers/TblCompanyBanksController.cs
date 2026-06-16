using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblCompanyBanksController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblCompanyBanksController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblCompanyBank
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblCompanyBank>>> GetTblCompanyBank()
    {
        return await _context.TblCompanyBanks.ToListAsync();
    }

    // GET: api/TblCompanyBank/5
    [HttpGet("{companybankid}")]
    public async Task<ActionResult<TblCompanyBank>> GetTblCompanyBank(int companybankid)
    {
        var tblcompanybank = await _context.TblCompanyBanks.FindAsync(companybankid);

        if (tblcompanybank == null)
        {
            return NotFound();
        }

        return tblcompanybank;
    }

    // PUT: api/TblCompanyBank/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{companybankid}")]
    public async Task<IActionResult> PutTblCompanyBank(int? companybankid, TblCompanyBank tblcompanybank)
    {
        if (companybankid != tblcompanybank.CompanybankId)
        {
            return BadRequest();
        }

        _context.Entry(tblcompanybank).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblCompanyBankExists(companybankid))
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

    // POST: api/TblCompanyBank
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblCompanyBank>> PostTblCompanyBank(TblCompanyBank tblcompanybank)
    {
        _context.TblCompanyBanks.Add(tblcompanybank);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblCompanyBank", new { companybankid = tblcompanybank.CompanybankId }, tblcompanybank);
    }

    // DELETE: api/TblCompanyBank/5
    [HttpDelete("{companybankid}")]
    public async Task<IActionResult> DeleteTblCompanyBank(int? companybankid)
    {
        var tblcompanybank = await _context.TblCompanyBanks.FindAsync(companybankid);
        if (tblcompanybank == null)
        {
            return NotFound();
        }

        _context.TblCompanyBanks.Remove(tblcompanybank);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblCompanyBankExists(int? companybankid)
    {
        return _context.TblCompanyBanks.Any(e => e.CompanybankId == companybankid);
    }
}

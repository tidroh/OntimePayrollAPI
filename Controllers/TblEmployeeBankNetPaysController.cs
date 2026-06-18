using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeBankNetPaysController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeBankNetPaysController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeBankNetPay
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeBankNetPay>>> GetTblEmployeeBankNetPay()
    {
        return await _context.TblEmployeeBankNetPays.ToListAsync();
    }

    // GET: api/TblEmployeeBankNetPay/5
    [HttpGet("{netpayid}")]
    public async Task<ActionResult<TblEmployeeBankNetPay>> GetTblEmployeeBankNetPay(int netpayid)
    {
        var tblemployeebanknetpay = await _context.TblEmployeeBankNetPays.FindAsync(netpayid);

        if (tblemployeebanknetpay == null)
        {
            return NotFound();
        }

        return tblemployeebanknetpay;
    }

    // PUT: api/TblEmployeeBankNetPay/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{netpayid}")]
    public async Task<IActionResult> PutTblEmployeeBankNetPay(int? netpayid, TblEmployeeBankNetPay tblemployeebanknetpay)
    {
        if (netpayid != tblemployeebanknetpay.NetpayId)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeebanknetpay).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeBankNetPayExists(netpayid))
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

    // POST: api/TblEmployeeBankNetPay
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeBankNetPay>> PostTblEmployeeBankNetPay(TblEmployeeBankNetPay tblemployeebanknetpay)
    {
        _context.TblEmployeeBankNetPays.Add(tblemployeebanknetpay);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeBankNetPay", new { netpayid = tblemployeebanknetpay.NetpayId }, tblemployeebanknetpay);
    }

    // DELETE: api/TblEmployeeBankNetPay/5
    [HttpDelete("{netpayid}")]
    public async Task<IActionResult> DeleteTblEmployeeBankNetPay(int? netpayid)
    {
        var tblemployeebanknetpay = await _context.TblEmployeeBankNetPays.FindAsync(netpayid);
        if (tblemployeebanknetpay == null)
        {
            return NotFound();
        }

        _context.TblEmployeeBankNetPays.Remove(tblemployeebanknetpay);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeBankNetPayExists(int? netpayid)
    {
        return _context.TblEmployeeBankNetPays.Any(e => e.NetpayId == netpayid);
    }
}

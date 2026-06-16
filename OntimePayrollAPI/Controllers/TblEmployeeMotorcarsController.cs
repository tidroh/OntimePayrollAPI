using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblEmployeeMotorcarsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblEmployeeMotorcarsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblEmployeeMotorcar
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblEmployeeMotorcar>>> GetTblEmployeeMotorcar()
    {
        return await _context.TblEmployeeMotorcars.ToListAsync();
    }

    // GET: api/TblEmployeeMotorcar/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblEmployeeMotorcar>> GetTblEmployeeMotorcar(int id)
    {
        var tblemployeemotorcar = await _context.TblEmployeeMotorcars.FindAsync(id);

        if (tblemployeemotorcar == null)
        {
            return NotFound();
        }

        return tblemployeemotorcar;
    }

    // PUT: api/TblEmployeeMotorcar/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblEmployeeMotorcar(int? id, TblEmployeeMotorcar tblemployeemotorcar)
    {
        if (id != tblemployeemotorcar.Id)
        {
            return BadRequest();
        }

        _context.Entry(tblemployeemotorcar).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblEmployeeMotorcarExists(id))
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

    // POST: api/TblEmployeeMotorcar
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblEmployeeMotorcar>> PostTblEmployeeMotorcar(TblEmployeeMotorcar tblemployeemotorcar)
    {
        _context.TblEmployeeMotorcars.Add(tblemployeemotorcar);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblEmployeeMotorcar", new { id = tblemployeemotorcar.Id }, tblemployeemotorcar);
    }

    // DELETE: api/TblEmployeeMotorcar/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblEmployeeMotorcar(int? id)
    {
        var tblemployeemotorcar = await _context.TblEmployeeMotorcars.FindAsync(id);
        if (tblemployeemotorcar == null)
        {
            return NotFound();
        }

        _context.TblEmployeeMotorcars.Remove(tblemployeemotorcar);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblEmployeeMotorcarExists(int? id)
    {
        return _context.TblEmployeeMotorcars.Any(e => e.Id == id);
    }
}

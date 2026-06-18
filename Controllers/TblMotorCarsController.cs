using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class TblMotorCarsController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public TblMotorCarsController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/TblMotorCar
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblMotorCar>>> GetTblMotorCar()
    {
        return await _context.TblMotorCars.ToListAsync();
    }

    // GET: api/TblMotorCar/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblMotorCar>> GetTblMotorCar(int id)
    {
        var tblmotorcar = await _context.TblMotorCars.FindAsync(id);

        if (tblmotorcar == null)
        {
            return NotFound();
        }

        return tblmotorcar;
    }

    // PUT: api/TblMotorCar/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblMotorCar(int? id, TblMotorCar tblmotorcar)
    {
        if (id != tblmotorcar.Id)
        {
            return BadRequest();
        }

        _context.Entry(tblmotorcar).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TblMotorCarExists(id))
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

    // POST: api/TblMotorCar
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblMotorCar>> PostTblMotorCar(TblMotorCar tblmotorcar)
    {
        _context.TblMotorCars.Add(tblmotorcar);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblMotorCar", new { id = tblmotorcar.Id }, tblmotorcar);
    }

    // DELETE: api/TblMotorCar/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblMotorCar(int? id)
    {
        var tblmotorcar = await _context.TblMotorCars.FindAsync(id);
        if (tblmotorcar == null)
        {
            return NotFound();
        }

        _context.TblMotorCars.Remove(tblmotorcar);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TblMotorCarExists(int? id)
    {
        return _context.TblMotorCars.Any(e => e.Id == id);
    }
}

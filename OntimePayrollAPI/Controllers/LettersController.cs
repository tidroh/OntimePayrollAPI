using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class LettersController : ControllerBase
{
    private readonly OntimePayrollContext _context;
    public LettersController(OntimePayrollContext context)
    {
        _context = context;
    }

    // GET: api/Letter
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Letter>>> GetLetter()
    {
        return await _context.Letters.ToListAsync();
    }

    // GET: api/Letter/5
    [HttpGet("{ccode}")]
    public async Task<ActionResult<Letter>> GetLetter(string ccode)
    {
        var letter = await _context.Letters.FindAsync(ccode);

        if (letter == null)
        {
            return NotFound();
        }

        return letter;
    }

    // PUT: api/Letter/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{ccode}")]
    public async Task<IActionResult> PutLetter(string? ccode, Letter letter)
    {
        if (ccode != letter.Ccode)
        {
            return BadRequest();
        }

        _context.Entry(letter).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LetterExists(ccode))
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

    // POST: api/Letter
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Letter>> PostLetter(Letter letter)
    {
        _context.Letters.Add(letter);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetLetter", new { ccode = letter.Ccode }, letter);
    }

    // DELETE: api/Letter/5
    [HttpDelete("{ccode}")]
    public async Task<IActionResult> DeleteLetter(string? ccode)
    {
        var letter = await _context.Letters.FindAsync(ccode);
        if (letter == null)
        {
            return NotFound();
        }

        _context.Letters.Remove(letter);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LetterExists(string? ccode)
    {
        return _context.Letters.Any(e => e.Ccode == ccode);
    }
}

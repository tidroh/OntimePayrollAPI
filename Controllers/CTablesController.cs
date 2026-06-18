using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

namespace OntimePayrollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTablesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public CTablesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/CTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CTable>>> GetCTables()
        {
            return await _context.CTables.ToListAsync();
        }

        // GET: api/CTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CTable>> GetCTable(string id)
        {
            var cTable = await _context.CTables.FindAsync(id);

            if (cTable == null)
            {
                return NotFound();
            }

            return cTable;
        }

        // PUT: api/CTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCTable(string id, CTable cTable)
        {
            if (id != cTable.TableCode)
            {
                return BadRequest();
            }

            _context.Entry(cTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CTableExists(id))
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

        // POST: api/CTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CTable>> PostCTable(CTable cTable)
        {
            _context.CTables.Add(cTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CTableExists(cTable.TableCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCTable", new { id = cTable.TableCode }, cTable);
        }

        // DELETE: api/CTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCTable(string id)
        {
            var cTable = await _context.CTables.FindAsync(id);
            if (cTable == null)
            {
                return NotFound();
            }

            _context.CTables.Remove(cTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CTableExists(string id)
        {
            return _context.CTables.Any(e => e.TableCode == id);
        }
    }
}

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
    public class TblPreviousPayeTablesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblPreviousPayeTablesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblPreviousPayeTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPreviousPayeTable>>> GetTblPreviousPayeTables()
        {
            return await _context.TblPreviousPayeTables.ToListAsync();
        }

        // GET: api/TblPreviousPayeTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPreviousPayeTable>> GetTblPreviousPayeTable(int id)
        {
            var tblPreviousPayeTable = await _context.TblPreviousPayeTables.FindAsync(id);

            if (tblPreviousPayeTable == null)
            {
                return NotFound();
            }

            return tblPreviousPayeTable;
        }

        // PUT: api/TblPreviousPayeTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPreviousPayeTable(int id, TblPreviousPayeTable tblPreviousPayeTable)
        {
            if (id != tblPreviousPayeTable.PayeId)
            {
                return BadRequest();
            }

            _context.Entry(tblPreviousPayeTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPreviousPayeTableExists(id))
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

        // POST: api/TblPreviousPayeTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPreviousPayeTable>> PostTblPreviousPayeTable(TblPreviousPayeTable tblPreviousPayeTable)
        {
            _context.TblPreviousPayeTables.Add(tblPreviousPayeTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPreviousPayeTable", new { id = tblPreviousPayeTable.PayeId }, tblPreviousPayeTable);
        }

        // DELETE: api/TblPreviousPayeTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPreviousPayeTable(int id)
        {
            var tblPreviousPayeTable = await _context.TblPreviousPayeTables.FindAsync(id);
            if (tblPreviousPayeTable == null)
            {
                return NotFound();
            }

            _context.TblPreviousPayeTables.Remove(tblPreviousPayeTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPreviousPayeTableExists(int id)
        {
            return _context.TblPreviousPayeTables.Any(e => e.PayeId == id);
        }
    }
}

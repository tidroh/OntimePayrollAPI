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
    public class CTableDetailsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public CTableDetailsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/CTableDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CTableDetail>>> GetCTableDetails()
        {
            return await _context.CTableDetails.ToListAsync();
        }

        // GET: api/CTableDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CTableDetail>> GetCTableDetail(int id)
        {
            var cTableDetail = await _context.CTableDetails.FindAsync(id);

            if (cTableDetail == null)
            {
                return NotFound();
            }

            return cTableDetail;
        }

        // PUT: api/CTableDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCTableDetail(int id, CTableDetail cTableDetail)
        {
            if (id != cTableDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(cTableDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CTableDetailExists(id))
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

        // POST: api/CTableDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CTableDetail>> PostCTableDetail(CTableDetail cTableDetail)
        {
            _context.CTableDetails.Add(cTableDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCTableDetail", new { id = cTableDetail.Id }, cTableDetail);
        }

        // DELETE: api/CTableDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCTableDetail(int id)
        {
            var cTableDetail = await _context.CTableDetails.FindAsync(id);
            if (cTableDetail == null)
            {
                return NotFound();
            }

            _context.CTableDetails.Remove(cTableDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CTableDetailExists(int id)
        {
            return _context.CTableDetails.Any(e => e.Id == id);
        }
    }
}

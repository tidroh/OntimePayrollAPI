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
    public class TblServicesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblServicesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblService>>> GetTblServices()
        {
            return await _context.TblServices.ToListAsync();
        }

        // GET: api/TblServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblService>> GetTblService(long id)
        {
            var tblService = await _context.TblServices.FindAsync(id);

            if (tblService == null)
            {
                return NotFound();
            }

            return tblService;
        }

        // PUT: api/TblServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblService(long id, TblService tblService)
        {
            if (id != tblService.ServicesId)
            {
                return BadRequest();
            }

            _context.Entry(tblService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblServiceExists(id))
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

        // POST: api/TblServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblService>> PostTblService(TblService tblService)
        {
            _context.TblServices.Add(tblService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblService", new { id = tblService.ServicesId }, tblService);
        }

        // DELETE: api/TblServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblService(long id)
        {
            var tblService = await _context.TblServices.FindAsync(id);
            if (tblService == null)
            {
                return NotFound();
            }

            _context.TblServices.Remove(tblService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblServiceExists(long id)
        {
            return _context.TblServices.Any(e => e.ServicesId == id);
        }
    }
}

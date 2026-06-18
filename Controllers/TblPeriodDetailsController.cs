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
    public class TblPeriodDetailsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblPeriodDetailsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblPeriodDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPeriodDetail>>> GetTblPeriodDetails()
        {
            return await _context.TblPeriodDetails.ToListAsync();
        }

        // GET: api/TblPeriodDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPeriodDetail>> GetTblPeriodDetail(int id)
        {
            var tblPeriodDetail = await _context.TblPeriodDetails.FindAsync(id);

            if (tblPeriodDetail == null)
            {
                return NotFound();
            }

            return tblPeriodDetail;
        }

        // PUT: api/TblPeriodDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPeriodDetail(int id, TblPeriodDetail tblPeriodDetail)
        {
            if (id != tblPeriodDetail.PerioddetailId)
            {
                return BadRequest();
            }

            _context.Entry(tblPeriodDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPeriodDetailExists(id))
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

        // POST: api/TblPeriodDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPeriodDetail>> PostTblPeriodDetail(TblPeriodDetail tblPeriodDetail)
        {
            _context.TblPeriodDetails.Add(tblPeriodDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPeriodDetail", new { id = tblPeriodDetail.PerioddetailId }, tblPeriodDetail);
        }

        // DELETE: api/TblPeriodDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPeriodDetail(int id)
        {
            var tblPeriodDetail = await _context.TblPeriodDetails.FindAsync(id);
            if (tblPeriodDetail == null)
            {
                return NotFound();
            }

            _context.TblPeriodDetails.Remove(tblPeriodDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPeriodDetailExists(int id)
        {
            return _context.TblPeriodDetails.Any(e => e.PerioddetailId == id);
        }
    }
}

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
    public class TblSettingsController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public TblSettingsController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/TblSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSetting>>> GetTblSettings()
        {
            return await _context.TblSettings.ToListAsync();
        }

        // GET: api/TblSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSetting>> GetTblSetting(int? id)
        {
            var tblSetting = await _context.TblSettings.FindAsync(id);

            if (tblSetting == null)
            {
                return NotFound();
            }

            return tblSetting;
        }

        // PUT: api/TblSettings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSetting(int? id, TblSetting tblSetting)
        {
            if (id != tblSetting.YearId)
            {
                return BadRequest();
            }

            _context.Entry(tblSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSettingExists(id))
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

        // POST: api/TblSettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblSetting>> PostTblSetting(TblSetting tblSetting)
        {
            _context.TblSettings.Add(tblSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblSetting", new { id = tblSetting.YearId }, tblSetting);
        }

        // DELETE: api/TblSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSetting(int? id)
        {
            var tblSetting = await _context.TblSettings.FindAsync(id);
            if (tblSetting == null)
            {
                return NotFound();
            }

            _context.TblSettings.Remove(tblSetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblSettingExists(int? id)
        {
            return _context.TblSettings.Any(e => e.YearId == id);
        }
    }
}

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
    public class PdContractTypesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public PdContractTypesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/PdContractTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PdContractType>>> GetPdContractTypes()
        {
            return await _context.PdContractTypes.ToListAsync();
        }

        // GET: api/PdContractTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PdContractType>> GetPdContractType(int id)
        {
            var pdContractType = await _context.PdContractTypes.FindAsync(id);

            if (pdContractType == null)
            {
                return NotFound();
            }

            return pdContractType;
        }

        // PUT: api/PdContractTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPdContractType(int id, PdContractType pdContractType)
        {
            if (id != pdContractType.Id)
            {
                return BadRequest();
            }

            _context.Entry(pdContractType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PdContractTypeExists(id))
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

        // POST: api/PdContractTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PdContractType>> PostPdContractType(PdContractType pdContractType)
        {
            _context.PdContractTypes.Add(pdContractType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPdContractType", new { id = pdContractType.Id }, pdContractType);
        }

        // DELETE: api/PdContractTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePdContractType(int id)
        {
            var pdContractType = await _context.PdContractTypes.FindAsync(id);
            if (pdContractType == null)
            {
                return NotFound();
            }

            _context.PdContractTypes.Remove(pdContractType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PdContractTypeExists(int id)
        {
            return _context.PdContractTypes.Any(e => e.Id == id);
        }
    }
}

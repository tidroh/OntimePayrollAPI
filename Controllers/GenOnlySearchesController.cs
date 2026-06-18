using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OntimePayrollAPI.Models;

namespace OntimePayrollAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenOnlySearchesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        // Inject the database context via constructor
        public GenOnlySearchesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // 1. GET ALL: api/GenOnlySearches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenOnlySearch>>> GetGenOnlySearches()
        {
            return await _context.GenOnlySearches.ToListAsync();
        }

        // 2. POST (Create): api/GenOnlySearches
        [HttpPost]
        public async Task<ActionResult<GenOnlySearch>> PostGenOnlySearch(GenOnlySearch data)
        {
            _context.GenOnlySearches.Add(data);
            await _context.SaveChangesAsync();

            return Ok(data);
        }

        /* 
         * NOTE ON GET BY ID / PUT / DELETE:
         * Because this model lacks a designated Primary Key, Entity Framework 
         * cannot automatically track records by a simple ID. 
         * 
         * If you have a column you want to use as a unique identifier (like 'Code' or 'Name'), 
         * you can implement them like the custom examples below:
         */

        // 3. GET BY UNIQUE FIELD (Example using a string property named 'Code')
        // [HttpGet("{code}")]
        // public async Task<ActionResult<GenOnlySearch>> GetGenOnlySearch(string code)
        // {
        //     var item = await _context.GenOnlySearches.FirstOrDefaultAsync(x => x.Code == code);
        //     if (item == null) return NotFound();
        //     return item;
        // }
    }
}
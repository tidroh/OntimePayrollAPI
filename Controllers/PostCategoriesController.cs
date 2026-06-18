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
    public class PostCategoriesController : ControllerBase
    {
        private readonly OntimePayrollContext _context;

        public PostCategoriesController(OntimePayrollContext context)
        {
            _context = context;
        }

        // GET: api/PostCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostCategory>>> GetPostCategories()
        {
            return await _context.PostCategories.ToListAsync();
        }

        // GET: api/PostCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostCategory>> GetPostCategory(string id)
        {
            var postCategory = await _context.PostCategories.FindAsync(id);

            if (postCategory == null)
            {
                return NotFound();
            }

            return postCategory;
        }

        // PUT: api/PostCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostCategory(string id, PostCategory postCategory)
        {
            if (id != postCategory.Dcode)
            {
                return BadRequest();
            }

            _context.Entry(postCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostCategoryExists(id))
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

        // POST: api/PostCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostCategory>> PostPostCategory(PostCategory postCategory)
        {
            _context.PostCategories.Add(postCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PostCategoryExists(postCategory.Dcode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPostCategory", new { id = postCategory.Dcode }, postCategory);
        }

        // DELETE: api/PostCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostCategory(string id)
        {
            var postCategory = await _context.PostCategories.FindAsync(id);
            if (postCategory == null)
            {
                return NotFound();
            }

            _context.PostCategories.Remove(postCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostCategoryExists(string id)
        {
            return _context.PostCategories.Any(e => e.Dcode == id);
        }
    }
}

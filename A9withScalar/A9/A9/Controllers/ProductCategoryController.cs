using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using A9.Data;
using A9.Entities;
using Scalar.AspNetCore;

namespace A9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly A9DbContext _context;

        public ProductCategoryController(A9DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (productCategory == null) return NotFound();
            return productCategory;
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductCategory), new { id = productCategory.Id }, productCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(int id, ProductCategory productCategory)
        {
            if (id != productCategory.Id) return BadRequest();

            _context.Entry(productCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (productCategory == null) return NotFound();

            _context.ProductCategories.Remove(productCategory);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

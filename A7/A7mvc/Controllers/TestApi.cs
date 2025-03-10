using A7mvc.Data;
using A7mvc.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A7mvc.Controllers
{
    public class TestApiController : Controller
    {
        private readonly FirstRunDbContext dbContext;

        public TestApiController(FirstRunDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Index Action (Displays List of Product Categories)
        public async Task<IActionResult> Index()
        {
            var categories = await dbContext.ProductCategories.ToListAsync();
            return View("~/Views/ReadUpdate/Read.cshtml", categories);
        }

        // Add Product (GET)
        public IActionResult Add()
        {
            return View("~/Views/ReadUpdate/Add.cshtml");
        }

        // Add Product (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(ProductCategory newProduct)
        {
            if (ModelState.IsValid)
            {
                newProduct.CreatedAt = DateTime.UtcNow; // Set created date
                dbContext.ProductCategories.Add(newProduct);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect back to product list
            }
            return View("~/Views/ReadUpdate/Add.cshtml", newProduct); // If validation fails, stay on the form
        }

        // Edit Product (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var productCategory = await dbContext.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View("~/Views/ReadUpdate/Edit.cshtml", productCategory);
        }

        // Edit Product (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, ProductCategory updatedProduct)
        {
            if (id != updatedProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                dbContext.Update(updatedProduct);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/ReadUpdate/Edit.cshtml", updatedProduct);
        }

        // Delete Product (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var productCategory = await dbContext.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            dbContext.ProductCategories.Remove(productCategory);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

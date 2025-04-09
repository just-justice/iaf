using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Entity;
using Project.ViewModels;

namespace Project.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View("Crud/Create"); // Explicitly set view location
        }

        // POST: Product/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to Index after creation
            }

            // Return to Create view if there are validation errors
            return View("Crud/Create", model);
        }

        // GET: Product/Index
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View("Crud/Index", products); // Explicitly return the view from the Crud folder
        }

        // GET: Product/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(); // Return NotFound if product is not found
            }

            var model = new CreateProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };

            return View("Crud/Edit", model); // Explicitly return Edit view
        }

        // POST: Product/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateProductViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound(); // If id doesn't match, return NotFound
            }

            if (ModelState.IsValid)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound(); // If product is not found, return NotFound
                }

                product.Name = model.Name;
                product.Price = model.Price;
                product.Description = model.Description;

                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to Index after updating
            }

            // Return to Edit view if there are validation errors
            return View("Crud/Edit", model);
        }

        // GET: Product/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(); // Return NotFound if product is not found
            }

            return View("Crud/Delete", product); // Explicitly return Delete view
        }

        // POST: Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirect to Index after deletion
        }
    }
}

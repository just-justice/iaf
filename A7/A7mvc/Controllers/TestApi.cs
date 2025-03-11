using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using A7mvc.Data;
using A7mvc.Entity;
using A7mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A7mvc.Controllers
{
    public class TestApiController : Controller
    {
        private readonly FirstRunDbContext _dbContext;

        public TestApiController(FirstRunDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Read action - fetching and passing the list of products to the view
        public async Task<IActionResult> Read()
        {
            var products = await _dbContext.ProductCategories.ToListAsync();
            return View("~/Views/ReadUpdate/Read.cshtml", products); // Pass data to the view
        }

        // Add action - return the Add page
        public IActionResult Add()
        {
            return View("~/Views/ReadUpdate/Add.cshtml");
        }

        // Add POST action - handle adding new product
        [HttpPost]
        public async Task<IActionResult> Add(ProductCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // Ensure the ID is unique
                        var exists = await _dbContext.ProductCategories.AnyAsync(p => p.Id == model.Id);
                        if (exists)
                        {
                            ModelState.AddModelError("Id", "ID must be unique.");
                            return View("~/Views/ReadUpdate/Add.cshtml", model); // Return to Add page
                        }

                        var product = new ProductCategory
                        {
                            Id = model.Id,
                            Name = model.Name,
                            IsActive = model.IsActive,
                            CreatedAt = DateTime.UtcNow
                        };

                        _dbContext.ProductCategories.Add(product);
                        await _dbContext.SaveChangesAsync();

                        scope.Complete(); // Commit the transaction
                        return RedirectToAction("Read"); // Redirect to Read page after success
                    }
                    catch
                    {
                        ModelState.AddModelError("", "An error occurred while saving the product.");
                    }
                }
            }
            return View("~/Views/ReadUpdate/Add.cshtml", model); // If invalid, return to Add page
        }

        // Edit action - fetch and show product details in the Edit form
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _dbContext.ProductCategories.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductCategoryViewModel
            {
                Id = product.Id,
                Name = product.Name,
                IsActive = product.IsActive
            };

            return View("~/Views/ReadUpdate/Edit.cshtml", model); // Return Edit view with the product data
        }

        // Edit POST action - handle updating the product
        [HttpPost]
        public async Task<IActionResult> Edit(ProductCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        var existingProduct = await _dbContext.ProductCategories.FindAsync(model.Id);
                        if (existingProduct == null)
                        {
                            return NotFound();
                        }

                        existingProduct.Name = model.Name;
                        existingProduct.IsActive = model.IsActive;

                        _dbContext.ProductCategories.Update(existingProduct);
                        await _dbContext.SaveChangesAsync();

                        scope.Complete(); // Commit the transaction
                        return RedirectToAction("Read"); // Redirect to Read page after update
                    }
                    catch
                    {
                        ModelState.AddModelError("", "An error occurred while updating the product.");
                    }
                }
            }
            return View("~/Views/ReadUpdate/Edit.cshtml", model); // Return to Edit page if validation fails
        }

        // Delete action - handle deleting a product
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var product = await _dbContext.ProductCategories.FindAsync(id);
                    if (product == null)
                    {
                        return NotFound();
                    }

                    _dbContext.ProductCategories.Remove(product);
                    await _dbContext.SaveChangesAsync();

                    scope.Complete(); // Commit the transaction
                    return RedirectToAction("Read"); // Redirect to Read page after deletion
                }
                catch
                {
                    ModelState.AddModelError("", "An error occurred while deleting the product.");
                }
            }
            return RedirectToAction("Read"); // Redirect to Read page if any error
        }
    }
}

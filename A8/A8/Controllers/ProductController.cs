using Microsoft.AspNetCore.Mvc;
using A8.Interface;
using A8.ViewModels;

namespace A8.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        // Constructor injection of IProductService
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // Display products and search functionality
        public IActionResult Index(string searchTerm)
        {
            // Search or retrieve all products
            var products = string.IsNullOrEmpty(searchTerm)
                ? _productService.GetAllProducts()
                : _productService.SearchProducts(searchTerm);

            // Preserve the search term in the ViewBag for UI
            ViewBag.SearchTerm = searchTerm;
            return View(products);
        }

        // GET: Add Product Page
        public IActionResult Add()
        {
            return View(); // Return the Add view with an empty model
        }

        // POST: Add New Product
        [HttpPost]
        public IActionResult Add(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Call the service to add the product
                    _productService.AddProduct(model);

                    // Redirect to Index after successful add
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {
                    // If product ID is not unique or any other error, display the error
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }
            }

            // If the model is not valid, return the view with the model to display errors
            return View(model);
        }

        // GET: Edit Product
        public IActionResult Edit(int id)
        {
            // Get the product by ID
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                // Return NotFound if the product doesn't exist
                return NotFound();
            }

            return View(product);
        }

        // POST: Edit Product
        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Update the product through the service
                    _productService.UpdateProduct(model);

                    // Redirect to Index after successful update
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {
                    // If there is an error (e.g., product not found), display the error
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }
            }

            return View(model); // Return the view if model is invalid
        }

        // Delete Product
        public IActionResult Delete(int id)
        {
            try
            {
                // Delete the product by ID
                _productService.DeleteProduct(id);
            }
            catch (System.Exception ex)
            {
                // Catch any exceptions (e.g., product not found) and show the error
                ModelState.AddModelError("", ex.Message);
            }

            return RedirectToAction("Index"); // Redirect back to the product list after deletion
        }
    }
}

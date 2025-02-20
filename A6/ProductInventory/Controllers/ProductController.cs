using Microsoft.AspNetCore.Mvc;
using ProductInventory.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductInventory.Controllers
{
    public class ProductController : Controller
    {
        // Static list to store product data
        private static List<Product> products = new List<Product>
        {
            new Product { Name = "Apple", Unit = "Kg", Quantity = 10, Description = "Fresh apples" },
            new Product { Name = "Milk", Unit = "Litre", Quantity = 5, Description = "Dairy milk" },
            new Product { Name = "Rice", Unit = "Kg", Quantity = 20, Description = "Basmati rice" },
            new Product { Name = "Sugar", Unit = "Kg", Quantity = 15, Description = "White sugar" },
            new Product { Name = "Eggs", Unit = "Dozen", Quantity = 2, Description = "Farm eggs" },
            new Product { Name = "Bread", Unit = "Piece", Quantity = 8, Description = "Whole wheat bread" },
            new Product { Name = "Butter", Unit = "Gram", Quantity = 500, Description = "Salted butter" }
        };

        // Displays the list of products
        public IActionResult Index()
        {
            return View(products);
        }

        // Edit Product - GET request
        // Fetches the product details for editing
        public IActionResult Edit(int id)
        {
            if (id < 0 || id >= products.Count)
                return NotFound();

            return View(products[id]);
        }

        // Edit Product - POST request
        // Updates the product details
        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            if (id < 0 || id >= products.Count)
                return NotFound();

            if (ModelState.IsValid)
            {
                products[id] = product; // Update the product list with new values
                return RedirectToAction(nameof(Index)); // Redirect back to the product list
            }
            return View(product);
        }

        // Delete Product within Edit Page
        // Allows deleting the product while editing
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            products.Remove(product); // Remove the correct product
            return RedirectToAction(nameof(Index)); // Redirect to the product list
        }
    }
}

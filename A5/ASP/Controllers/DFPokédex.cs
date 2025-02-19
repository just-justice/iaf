using Microsoft.AspNetCore.Mvc;
using DFPokédex.Models;
using System.Linq;

namespace DFPokédex.Controllers
{
    public class DevilFruitsController : Controller
    {
        private static List<DevilFruit> devilFruits = new List<DevilFruit>
        {
            new DevilFruit { Id = 1, Name = "Gomu Gomu no Mi", User = "Monkey D. Luffy" },
            new DevilFruit { Id = 2, Name = "Mera Mera no Mi", User = "Portgas D. Ace" }
        };

        public IActionResult Index()
        {
            return View(devilFruits);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DevilFruit devilFruit)
        {
            if (ModelState.IsValid)
            {
                devilFruit.Id = devilFruits.Count + 1;
                devilFruits.Add(devilFruit);
                return RedirectToAction("Index");

            }
            return View(devilFruit);
        }
        public IActionResult Edit(int id)
        {
            var devilFruit = devilFruits.FirstOrDefault(d => d.Id == id);
            if (devilFruit == null) return NotFound();
            return View(devilFruit);
        }

        [HttpPost]
        public IActionResult Edit(DevilFruit updatedFruit)
        {
            var existingFruit = devilFruits.FirstOrDefault(d => d.Id == updatedFruit.Id);
            if (existingFruit == null) return NotFound();

            existingFruit.Name = updatedFruit.Name;
            existingFruit.User = updatedFruit.User;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var devilFruit = devilFruits.FirstOrDefault(d => d.Id == id);
            if (devilFruit == null) return NotFound();
            return View(devilFruit);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var devilFruit = devilFruits.FirstOrDefault(d => d.Id == id);
            if (devilFruit != null)
            {
                devilFruits.Remove(devilFruit);
            }
            return RedirectToAction("Index");
        }
    }
}

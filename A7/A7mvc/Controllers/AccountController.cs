using Microsoft.AspNetCore.Mvc;
using A7mvc.Models;
using A7mvc.Repositories;

namespace A7mvc.Controllers
{
    public class AccountController : Controller
    {
        // Store the logged-in user's username
        private static string? loggedInUsername;

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = UserRepository.GetUser(username, password);
            if (user != null)
            {
                loggedInUsername = username;  // Set the logged-in username
                return RedirectToAction("Dashboard");
            }
            ModelState.AddModelError("", "Invalid credentials");
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAccount(User user)
        {
            if (ModelState.IsValid)
            {
                UserRepository.AddUser(user);
                loggedInUsername = user.Username;

                // Construct the user information as a string
                string userInfo = $"Username: {user.Username}\nEmail: {user.Email}\n" +
                                  $"Age: {user.Age}\nPhone: {user.PhoneNumber}\nDOB: {user.DateOfBirth}\n" +
                                  $"Address: {user.Address}\nDonation: {user.Donation}\n" +
                                  $"-----------------------------------------\n";

                // Define the file path
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "UserData.txt");

                // Append the user info to the file
                System.IO.File.AppendAllText(filePath, userInfo);

                return RedirectToAction("Dashboard");
            }

            // If validation fails, return the view with error messages
            return View(user);
        }



        public IActionResult Dashboard()
        {
            // Pass the logged-in username to the view to allow conditionally showing the edit button
            ViewBag.LoggedInUsername = loggedInUsername;
            return View(UserRepository.Users);
        }

        [HttpPost]
        public IActionResult EditDonation(string username, decimal donation)
        {
            var user = UserRepository.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.Donation = donation;
            }
            return RedirectToAction("Dashboard");
        }
    }
}

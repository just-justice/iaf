using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Entity;
using Project.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AdminUser> _userManager;
        private readonly SignInManager<AdminUser> _signInManager;

        public AccountController(UserManager<AdminUser> userManager, SignInManager<AdminUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login() => View();

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous] // Ensure this action can be accessed without being logged in
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        // Redirect to Product/Index after successful login
                        return RedirectToAction("Index", "Product");  // Redirect to /crud/index
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                }
            }

            return View(model);  // Return the login page if login fails
        }


        // GET: /Account/Create (for registering a new user)
        [HttpGet]
        public IActionResult Create() => View();

        // POST: /Account/Create (handle form submission for registration)
        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AdminUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Name = model.Name
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Sign the user in after successful registration
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");  // Redirect to homepage or dashboard after registration
                }

                // Add any errors from registration failure to the ModelState
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);  // Return to the form if there were validation errors
        }

        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]  // Adding this for security when performing the logout operation
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");  // Redirect to login after logout
        }
    }
}

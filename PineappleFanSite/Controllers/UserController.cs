using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PineappleFanSite.Models;

namespace PineappleFanSite.Controllers
{
    public class UserController : Controller
    {
        [Authorize(Roles = "Admin")]
        public class CustomUserController : Controller
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public CustomUserController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }
            [HttpGet]
            public async Task<IActionResult> Index()
            {
                var users = new List<IdentityUser>();
                foreach (var user in _userManager.Users.ToList())
                {
                    //user.RoleNames = await _userManager.GetRolesAsync(user);
                    users.Add(user);
                }

                var model = new Login
                {
                    Users = (IEnumerable<AppUser>)users,
                    Roles = _roleManager.Roles
                };

                return View("../Login");
            }

            [HttpGet]
            public IActionResult Add()
            {
                return View("../Register");
            }

            [HttpPost]
            public async Task<IActionResult> Add(Register model)
            {
                if (ModelState.IsValid)
                {
                    var user = new AppUser { UserName = model.Email };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                return View("../Register", model);
            }

            [HttpPost]
            public async Task<IActionResult> Delete(string id)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);
                    if (!result.Succeeded)
                    {
                        var errorMessage = string.Join(" | ", result.Errors.Select(error => error.Description));
                        TempData["message"] = errorMessage;
                    }
                }
                return RedirectToAction("Index");
            }

            [HttpPost]
            public async Task<IActionResult> CreateAdminRole()
            {
                var result = await _roleManager.CreateAsync(new IdentityRole("Admin"));
                // TODO: Handle the result (e.g., log or display a message)
                return RedirectToAction("Index");
            }

            [HttpPost]
            public async Task<IActionResult> DeleteRole(string id)
            {
                var role = await _roleManager.FindByIdAsync(id);
                var result = await _roleManager.DeleteAsync(role);
                // TODO: Handle the result (e.g., log or display a message)
                return RedirectToAction("Index");
            }

            [HttpPost]
            public async Task<IActionResult> RemoveFromAdmin(string id)
            {
                AppUser user = await _userManager.FindByIdAsync(id);
                var result = await _userManager.RemoveFromRoleAsync(user, "Admin");
                if (result.Succeeded) { }
                return RedirectToAction("Index");
            }

            [HttpPost]
            public async Task<IActionResult> AddToAdmin(string id)
            {
                var adminRole = await _roleManager.FindByNameAsync("Admin");
                if (adminRole == null)
                {
                    TempData["message"] = "Admin role does not exist. Click 'Create Admin Role' button to create it.";
                }
                else
                {
                    var user = await _userManager.FindByIdAsync(id);
                    await _userManager.AddToRoleAsync(user, adminRole.Name);
                }
                return RedirectToAction("Index");
            }
        }

    }
}

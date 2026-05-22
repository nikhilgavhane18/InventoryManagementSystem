using Inventory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        // CHECK IF USER ALREADY LOGGED IN
        if (User.Identity.IsAuthenticated)
        {
            var user =
                await _userManager.GetUserAsync(User);

            // ADMIN
            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                return RedirectToAction(
                    "Index",
                    "Dashboard");
            }

            // SUPPLIER
            else if (await _userManager.IsInRoleAsync(user, "Supplier"))
            {
                return RedirectToAction(
                    "Index",
                    "Supplier");
            }

            // USER
            else if (await _userManager.IsInRoleAsync(user, "User"))
            {
                return RedirectToAction(
                    "Index",
                    "User");
            }
        }

        // IF NOT LOGGED IN
        return View();
    }
}
using EmpManagePro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmpManagePro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Verificamos los roles de jose@emp.com en el HomeController
            var user = await _userManager.FindByEmailAsync("elena@emp.com");
            if (user != null)
            {
                //await _userManager.AddToRoleAsync(user, "Admin");
                var roles = await _userManager.GetRolesAsync(user);
                Debug.WriteLine($"Roles para elena@emp.com: {string.Join(", ", roles)}");
            }
            //return Content("Usuario no encontrado o no tiene roles asignados.");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

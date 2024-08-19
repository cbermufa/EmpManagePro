using EmpManagePro.BaseDatos;
using EmpManagePro.Models; // Importo los modelos, incluyendo LoginViewModel, ApplicationUser y EmployeeProfileViewModel
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity; // Importo ASP.NET Core Identity para manejar la autenticación de usuarios
using Microsoft.AspNetCore.Mvc; // Importo herramientas MVC para construir controladores y vistas
using Microsoft.EntityFrameworkCore; // Importo Entity Framework Core para trabajar con bases de datos
using System.Threading.Tasks; // Importo para trabajar con tareas asíncronas

namespace EmpManagePro.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager; // Para manejar operaciones de usuario, como la creación y búsqueda de usuarios
        private readonly SignInManager<ApplicationUser> _signInManager; // Para manejar el inicio y cierre de sesión de usuarios
        private readonly EmpleadosDBContext _context; // Contexto de la base de datos

        // Constructor: Uso inyección de dependencias para recibir UserManager y SignInManager
        // Constructor: Uso inyección de dependencias para recibir UserManager, SignInManager y el contexto de la base de datos
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, EmpleadosDBContext context)
        {
            _userManager = userManager; // Asigno el UserManager proporcionado al campo privado
            _signInManager = signInManager; // Asigno el SignInManager proporcionado al campo privado
            _context = context; // Asigno el contexto de la base de datos proporcionado al campo privado
        }

        public IActionResult AccessDenied()
        {
            return View();
        }



        // GET: /Account/Login
        // Este método muestra la vista de inicio de sesión. Puede recibir un "returnUrl" opcional para redirigir al usuario después de iniciar sesión.
        [HttpGet]
        [AllowAnonymous] // Permito el acceso a esta acción sin autenticación
        public IActionResult Login(string? returnUrl = null)
        {
            
            if (User.Identity != null && User.Identity.IsAuthenticated) // Verifico si el usuario ya está autenticado
            {
                return RedirectToAction("Index", "Home"); // Redirijo al usuario a la página principal si ya está autenticado
            }

            ViewData["IsLoginPage"] = true; // Indico que esta es la página de login
            ViewData["ReturnUrl"] = returnUrl; // Paso el returnUrl a la vista para que se mantenga en el formulario de inicio de sesión
            return View(); // Devuelvo la vista de inicio de sesión
        }

        // POST: /Account/Login
        // Este método procesa el inicio de sesión cuando el usuario envía el formulario. 
        // Si el inicio de sesión es exitoso, el usuario será redirigido a la página solicitada (returnUrl) o a la página de inicio.
        [HttpPost]
        [AllowAnonymous] // Permito el acceso a esta acción sin autenticación
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["IsLoginPage"] = true;  // Indico que esta es la página de login
            ViewData["ReturnUrl"] = returnUrl; // Mantengo el returnUrl en la vista por si hay un error y se debe reintentar el inicio de sesión

            if (ModelState.IsValid) // Verifico que los datos proporcionados en el formulario sean válidos
            {
                // Verificamos los roles de jose@emp.com antes de intentar iniciar sesión
                var user = await _userManager.FindByEmailAsync("jose@emp.com");
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    Console.WriteLine($"Roles para jose@emp.com: {string.Join(", ", roles)}");
                }
                // Intento iniciar sesión con el correo electrónico y la contraseña proporcionados
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded) // Si el inicio de sesión es exitoso
                {
                    return RedirectToLocal(returnUrl); // Redirijo al returnUrl o a la página de inicio si el returnUrl es nulo
                }
                else // Si el inicio de sesión falla
                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "La cuenta está bloqueada.");
                    }
                    else if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError(string.Empty, "La cuenta no tiene permitido iniciar sesión.");
                    }
                    else if (result.RequiresTwoFactor)
                    {
                        ModelState.AddModelError(string.Empty, "Es necesario autenticar con dos factores.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Inicio de sesión inválido.");
                    }
                }
            }

            return View(model); // Si algo falla, devuelvo la vista de inicio de sesión con el modelo original para que el usuario reintente
        }

        // Este método redirige al usuario a una URL local si es válida; de lo contrario, lo redirige a la página de inicio
        private IActionResult RedirectToLocal(string? returnUrl)
        {
            // Verifico si el returnUrl es una URL local, es decir, una URL que pertenece a este sitio
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl); // Si la URL es local, redirijo al usuario a esa URL
            }
            else
            {
                return RedirectToAction("Index", "Home"); // Si la URL no es local (o es nula), redirijo al usuario a la página de inicio
            }
        }

        // GET: /Account/Logout
        // Este método maneja el cierre de sesión. Cuando el usuario hace clic en "Cerrar sesión", se llama a este método.
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); // Cierro la sesión del usuario actual
            return RedirectToAction("Login", "Account"); // Redirijo al usuario a la página de inicio de sesión después de cerrar sesión
        }
    }
}

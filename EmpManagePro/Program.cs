using EmpManagePro.BaseDatos; // Importo el namespace de mi contexto de base de datos
using EmpManagePro.Models; // Importo el namespace de mis modelos, incluyendo ApplicationUser
using Microsoft.EntityFrameworkCore; // Importo Entity Framework Core para trabajar con bases de datos
using Microsoft.AspNetCore.Identity; // Importo ASP.NET Core Identity para la autenticación y autorización
using Microsoft.AspNetCore.Authentication.Cookies; // Importo para manejar la autenticación basada en cookies
using Microsoft.AspNetCore.Authorization; // Importo para configurar la política de autorización
using Microsoft.AspNetCore.Mvc.Authorization; // Importo para usar AuthorizeFilter

var builder = WebApplication.CreateBuilder(args);

// Configuro el servicio del contexto de base de datos con la cadena de conexión
builder.Services.AddDbContext<EmpleadosDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmpleadosDB")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => // Agrego soporte para roles
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<EmpleadosDBContext>() // Uso mi contexto de base de datos
.AddDefaultTokenProviders();

// Configurar la autenticación por cookies
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Especifico la ruta para la página de inicio de sesión
    options.AccessDeniedPath = "/Account/AccessDenied"; // Especifico la ruta para la página de acceso denegado
});

// Se agregan controladores con vistas y Razor Pages al contenedor de servicios
builder.Services.AddControllersWithViews(options =>
{
    // Configuración global para requerir autenticación en todas las páginas
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    options.Filters.Add(new AuthorizeFilter(policy)); // Aplica autenticación global
});

builder.Services.AddRazorPages();

var app = builder.Build();

// Inicializar los roles y usuarios
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedRoles.Initialize(services);
    await SeedUsers.Initialize(services); // Inicializar usuarios
}

// Configuración de la canalización de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Activo HSTS para mejorar la seguridad en producción
}

// Redirección a las solicitudes HTTP a HTTPS
app.UseHttpsRedirection();

// Permiso para el uso de archivos estáticos como CSS, JS, e imágenes
app.UseStaticFiles();

// Configuración del enrutamiento para las solicitudes HTTP
app.UseRouting();

// Añadir autenticación y autorización en la aplicación
app.UseAuthentication(); // Agrego autenticación
app.UseAuthorization(); // Agrego autorización

// Configuración de la ruta predeterminada para los controladores y acciones
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// Configuración del enrutamiento para la página de inicio de sesión
app.MapRazorPages();


// Inicio la aplicación
app.Run();

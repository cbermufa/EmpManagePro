using EmpManagePro.BaseDatos; // Importo el namespace de mi contexto de base de datos
using EmpManagePro.Models; // Importo el namespace de mis modelos, incluyendo ApplicationUser
using Microsoft.EntityFrameworkCore; // Importo Entity Framework Core para trabajar con bases de datos
using Microsoft.AspNetCore.Identity; // Importo ASP.NET Core Identity para la autenticaci�n y autorizaci�n
using Microsoft.AspNetCore.Authentication.Cookies; // Importo para manejar la autenticaci�n basada en cookies
using Microsoft.AspNetCore.Authorization; // Importo para configurar la pol�tica de autorizaci�n
using Microsoft.AspNetCore.Mvc.Authorization; // Importo para usar AuthorizeFilter

var builder = WebApplication.CreateBuilder(args);

// Configuro el servicio del contexto de base de datos con la cadena de conexi�n
builder.Services.AddDbContext<EmpleadosDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmpleadosDB")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => // Agrego soporte para roles
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<EmpleadosDBContext>() // Uso mi contexto de base de datos
.AddDefaultTokenProviders();

// Configurar la autenticaci�n por cookies
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Especifico la ruta para la p�gina de inicio de sesi�n
    options.AccessDeniedPath = "/Account/AccessDenied"; // Especifico la ruta para la p�gina de acceso denegado
});

// Se agregan controladores con vistas y Razor Pages al contenedor de servicios
builder.Services.AddControllersWithViews(options =>
{
    // Configuraci�n global para requerir autenticaci�n en todas las p�ginas
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    options.Filters.Add(new AuthorizeFilter(policy)); // Aplica autenticaci�n global
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

// Configuraci�n de la canalizaci�n de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Activo HSTS para mejorar la seguridad en producci�n
}

// Redirecci�n a las solicitudes HTTP a HTTPS
app.UseHttpsRedirection();

// Permiso para el uso de archivos est�ticos como CSS, JS, e im�genes
app.UseStaticFiles();

// Configuraci�n del enrutamiento para las solicitudes HTTP
app.UseRouting();

// A�adir autenticaci�n y autorizaci�n en la aplicaci�n
app.UseAuthentication(); // Agrego autenticaci�n
app.UseAuthorization(); // Agrego autorizaci�n

// Configuraci�n de la ruta predeterminada para los controladores y acciones
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// Configuraci�n del enrutamiento para la p�gina de inicio de sesi�n
app.MapRazorPages();


// Inicio la aplicaci�n
app.Run();

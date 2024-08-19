using EmpManagePro.Models; // Importo mis modelos, incluyendo ApplicationUser
using Microsoft.AspNetCore.Identity; // Importo ASP.NET Core Identity para manejar usuarios y roles
using Microsoft.Extensions.DependencyInjection; // Importo para usar servicios desde el contenedor de dependencias
using System;
using System.Threading.Tasks;

namespace EmpManagePro.BaseDatos
{
    public static class SeedUsers
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            // Obtengo el UserManager desde el contenedor de servicios para manejar usuarios
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            // Obtengo el RoleManager desde el contenedor de servicios para manejar roles
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            // Obtengo el contexto de base de datos
            var context = serviceProvider.GetRequiredService<EmpleadosDBContext>();

            // Defino los correos electrónicos de los usuarios que voy a crear
            string adminEmail = "admin@empmanagepro.com";
            string empleadoEmail = "empleado@empmanagepro.com";

            // Defino una contraseña por defecto para ambos usuarios
            string password = "P@ssword1";

            // Compruebo si el usuario Admin ya existe buscando por su email
            if (userManager.FindByEmailAsync(adminEmail).Result == null)
            {
                // Si el usuario no existe, lo creo
                var user = new ApplicationUser
                {
                    UserName = adminEmail, // Asigno el email como nombre de usuario
                    Email = adminEmail, // Asigno el email al campo Email
                    EmailConfirmed = true, // Confirmo el email por defecto
                    EmpleadoID = "EMP001" // Asigno un EmpleadoID único si no existe
                };

                var result = await userManager.CreateAsync(user, password);

                // Si la creación del usuario fue exitosa, le asigno el rol de Admin
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");

                    // Verifico si el empleado ya existe en la tabla Empleados
                    if (context.Empleados.Find(user.EmpleadoID) == null)
                    {
                        // Creo un registro correspondiente en la tabla Empleados
                        var empleado = new Empleado
                        {
                            EmpleadoID = user.EmpleadoID,
                            Nombre = "Administrador",
                            Direccion = "Dirección del Admin",
                            Email = adminEmail,
                            Telefono = "1234-5678",
                            FechaContratacion = DateTime.Now
                            //Rol = "Admin"
                        };

                        context.Empleados.Add(empleado);
                        await context.SaveChangesAsync();
                    }
                }
            }

            // Repito el proceso anterior para crear un usuario con rol Empleado
            if (userManager.FindByEmailAsync(empleadoEmail).Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = empleadoEmail, // Asigno el email como nombre de usuario
                    Email = empleadoEmail, // Asigno el email al campo Email
                    EmailConfirmed = true, // Confirmo el email por defecto
                    EmpleadoID = "EMP000001" // Asigno un EmpleadoID único si no existe
                };

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Empleado");

                    if (context.Empleados.Find(user.EmpleadoID) == null)
                    {
                        var empleado = new Empleado
                        {
                            EmpleadoID = user.EmpleadoID,
                            Nombre = "Empleado Ejemplo",
                            Direccion = "Dirección del Empleado",
                            Email = empleadoEmail,
                            Telefono = "8765-4321",
                            FechaContratacion = DateTime.Now,
                            //RolID = "Empleado"
                        };

                        context.Empleados.Add(empleado);
                        await context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}

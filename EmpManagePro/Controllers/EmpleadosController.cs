using EmpManagePro.BaseDatos; // Importo el namespace del contexto de base de datos
using EmpManagePro.Models; // Importo el namespace de los modelos
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc; // Importo las herramientas de MVC
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering; // Importo para usar SelectList
using System.Diagnostics;

using System.Linq; // Importo para usar LINQ para consultas de datos

namespace EmpManagePro.Controllers
{
    [Authorize]
    public class EmpleadosController : Controller
    {
        private readonly EmpleadosDBContext _context; // Creo una instancia de mi contexto de base de datos
        private readonly RoleManager<IdentityRole> _roleManager; // Creo una instancia para manejar roles en la aplicación
        private readonly UserManager<ApplicationUser> _userManager; // Creo una instancia para manejar usuarios en la aplicación

        // Utilizo inyección de dependencias para recibir una instancia de EmpleadosDBContext, RoleManager y UserManager
        public EmpleadosController(EmpleadosDBContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context; // Guardo la instancia en una variable privada para usarla en otros métodos
            _roleManager = roleManager; // Guardo la instancia de RoleManager
            _userManager = userManager; // Guardo la instancia de UserManager
        }

        // GET: Empleados
        // Este método obtiene la lista de empleados y la envía a la vista
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            // Hago un join entre la tabla de Empleados y AspNetRoles para obtener el nombre del rol
            var empleadosConRoles = await (from e in _context.Empleados
                                           join r in _context.Roles on e.RoleId equals r.Id
                                           join p in _context.Puesto on e.PuestoID equals p.PuestoID into puestos
                                           from p in puestos.DefaultIfEmpty()
                                           select new EmpleadoViewModel
                                           {
                                               EmpleadoID = e.EmpleadoID,
                                               Nombre = e.Nombre,
                                               Direccion = e.Direccion,
                                               Email = e.Email,
                                               Telefono = e.Telefono,
                                               FechaContratacion = e.FechaContratacion,
                                               RoleName = r.Name, // Traigo el nombre del rol en lugar del ID
                                               Puesto = p != null ? p.Nombre : "Sin Puesto Asignado" // Manejo de NULL
                                           }).ToListAsync();

            return View(empleadosConRoles);
        }

        // GET: Empleados/Create
        // Este método devuelve la vista para crear un nuevo empleado
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            // Inicializa un nuevo objeto Empleado
            var empleado = new Empleado();

            // Obtengo la lista de roles disponibles desde la base de datos
            ViewBag.Roles = new SelectList(_context.Roles.ToList(), "Id", "Name");

            // Obtengo la lista de puestos de la base de datos
            ViewBag.Puestos = new SelectList(_context.Puesto.ToList(), "PuestoID", "Nombre");

            // Obtengo la lista de deducciones de la base de datos, seleccionando solo los campos necesarios
            var deducciones = _context.Deduccion
                                .Select(d => new
                                {
                                    d.DeduccionID,          // ID del campo Deduccion
                                    d.Nombre,               // Nombre de la Deducción,
                                    d.Porcentaje            // Porcentaje de la Deducción
                                })
                                .ToList();
            
            Debug.WriteLine($"deducciones: {string.Join(", ", deducciones)}");
            // Obtengo la lista de deducciones de la base de datos
            ViewBag.Deducciones = new SelectList(deducciones, "DeduccionID", "Nombre");

            // Obtengo la lista de deducciones de la base de datos, seleccionando solo los campos necesarios
            var bonificaciones = _context.Bonificacion
                                .Select(d => new
                                {
                                    d.BonificacionID,   // ID del campo Deduccion
                                    d.Nombre,           // Nombre de la Deducción,
                                    d.Monto             // Porcentaje de la Deducción
                                })
                                .ToList();

            Debug.WriteLine($"bonificaciones: {string.Join(", ", bonificaciones)}");

            // Obtengo la lista de bonificaciones de la base de datos
            ViewBag.Bonificaciones = new SelectList(bonificaciones, "BonificacionID", "Nombre");

            Debug.WriteLine($"Modelo Empleado: {empleado}");
            return View(empleado);
        }

        // POST: Empleados/Create
        // Este método recibe el formulario para crear un nuevo empleado y lo guarda en la base de datos si es válido
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Empleado empleado, int[] DeduccionesID, int[] BonificacionesID)
        {
            if (ModelState.IsValid)
            {
                // Verifico que el RoleId seleccionado exista en la base de datos
                var role = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == empleado.RoleId);

                if (role == null)
                {
                    ModelState.AddModelError("RoleId", "El rol seleccionado no es válido.");
                    ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name", empleado.RoleId);
                    return View(empleado);
                }

                // Verifico que no exista un empleado con el mismo EmpleadoID
                var existingEmpleado = await _context.Empleados.FirstOrDefaultAsync(e => e.EmpleadoID == empleado.EmpleadoID);
                if (existingEmpleado != null)
                {
                    ModelState.AddModelError("EmpleadoID", "Ya existe un empleado con este ID.");
                    ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name", empleado.RoleId);
                    return View(empleado);
                }

                // Crear el empleado en la base de datos
                _context.Add(empleado);
                await _context.SaveChangesAsync(); // Guardar el empleado antes de crear el usuario

                // Guardar las deducciones seleccionadas
                if (DeduccionesID != null && DeduccionesID.Length > 0)
                {
                    foreach (var deduccionID in DeduccionesID)
                    {
                        _context.EmpleadosDeducciones.Add(new EmpleadoDeduc
                        {
                            EmpleadoID = empleado.EmpleadoID,
                            DeduccionID = deduccionID
                        });
                    }
                }

                // Guardar las bonificaciones seleccionadas
                if (BonificacionesID != null && BonificacionesID.Length > 0)
                {
                    foreach (var bonificacionID in BonificacionesID)
                    {
                        _context.EmpleadosBonificaciones.Add(new EmpleadoBonif
                        {
                            EmpleadoID = empleado.EmpleadoID,
                            BonificacionID = bonificacionID
                        });
                    }
                }

                await _context.SaveChangesAsync(); // Guardar las relaciones en la base de datos

                // Crear un nuevo usuario de Identity
                var user = new ApplicationUser
                {
                    UserName = empleado.Email,
                    Email = empleado.Email,
                    EmpleadoID = empleado.EmpleadoID, // Relacionar con el empleado recién creado
                    EmailConfirmed = true // Confirmamos automáticamente el email
                };

                var result = await _userManager.CreateAsync(user, empleado.Password);

                if (result.Succeeded)
                {
                    // Asignar el rol al usuario recién creado
                    var roleAssignmentResult = await _userManager.AddToRoleAsync(user, role.Name);

                    if (roleAssignmentResult.Succeeded)
                    {
                        // Si el rol fue asignado correctamente, redirigir a la lista de empleados
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        // Si algo falla al asignar el rol, mostrar los errores
                        foreach (var error in roleAssignmentResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    // Si algo falla al crear el usuario, mostrar los errores
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // Si algo falla, vuelve a cargar los datos necesarios para la vista y mostrar los errores
            ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name", empleado.RoleId);
            ViewBag.Puestos = new SelectList(await _context.Puesto.ToListAsync(), "PuestoID", "Nombre");
            ViewBag.Deducciones = new SelectList(await _context.Deduccion.ToListAsync(), "DeduccionID", "Nombre");
            ViewBag.Bonificaciones = new SelectList(await _context.Bonificacion.ToListAsync(), "BonificacionID", "Nombre");

            return View(empleado);
        }


        // GET: Empleados/Profile
        public async Task<IActionResult> Profile(string? id = null, bool isSelf = false)
        {
            // Si el usuario tiene el rol de "Empleado", forzamos que solo pueda ver su propio perfil
            if (User.IsInRole("Empleado"))
            {
                isSelf = true; // Forzar la bandera isSelf para los empleados
            }

            if (isSelf)
            {
                // Si se está accediendo al perfil propio, ignoramos el parámetro `id` y usamos el ID del usuario autenticado
                var currentUserId = _userManager.GetUserId(User); // Obtengo el ID del usuario autenticado

                // Busco en AspNetUsers el registro correspondiente para obtener el EmpleadoID
                var empleadoId = await _context.Users
                    .Where(u => u.Id == currentUserId)
                    .Select(u => u.EmpleadoID)
                    .FirstOrDefaultAsync();

                if (empleadoId == null)
                {
                    return NotFound(); // Si no se encuentra el EmpleadoID, retorno un error 404
                }

                var currentEmpleado = await _context.Empleados
                    .Include(e => e.User) // Incluye la relación con User
                    .Include(e => e.Puesto) // Incluye la relación con Puesto
                    .Include(e => e.EmpleadoDeduc) // Incluye la relación con EmpleadoDeduc
                        .ThenInclude(ed => ed.Deduccion) // Luego incluye la relación con Deducción a través de EmpleadoDeduc
                    .Include(e => e.EmpleadoBonif) // Incluye la relación con EmpleadoBonif
                        .ThenInclude(eb => eb.Bonificacion) // Luego incluye la relación con Bonificación a través de EmpleadoBonif
                    .Include(e => e.Turnos) // Incluye la relación con Turnos
                        .ThenInclude(te => te.Turno) // Incluye los detalles del Turno en TurnoEmpleado
                    .FirstOrDefaultAsync(e => e.EmpleadoID == empleadoId);


                if (currentEmpleado == null)
                {
                    return NotFound(); // Si el perfil no existe, retorno un error 404
                }

                // Cargar deducciones
                var deducciones = await _context.Deduccion.ToListAsync();
                var deduccionesSeleccionadas = currentEmpleado.EmpleadoDeduc.Select(d => d.DeduccionID).ToList();
                ViewBag.Deducciones = deducciones.Select(d => new SelectListItem
                {
                    Value = d.DeduccionID.ToString(),
                    Text = d.Nombre,
                    Selected = deduccionesSeleccionadas.Contains(d.DeduccionID)
                }).ToList();

                // Cargar bonificaciones
                var bonificaciones = await _context.Bonificacion.ToListAsync();
                var bonificacionesSeleccionadas = currentEmpleado.EmpleadoBonif.Select(b => b.BonificacionID).ToList();
                ViewBag.Bonificaciones = bonificaciones.Select(b => new SelectListItem
                {
                    Value = b.BonificacionID.ToString(),
                    Text = b.Nombre,
                    Selected = bonificacionesSeleccionadas.Contains(b.BonificacionID)
                }).ToList();

                // Llenar el ViewBag con la lista de roles en formato de SelectList
                ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name", currentEmpleado.RoleId);

                // Llenar el ViewBag con la lista de puestos en formato de SelectList
                ViewBag.Puestos = new SelectList(await _context.Puesto.ToListAsync(), "PuestoID", "Nombre", currentEmpleado.PuestoID);

                // Mostrar vista de solo lectura para empleados
                return View("ProfileReadOnly", currentEmpleado); // Vista solo informativa
            }
            else if (!string.IsNullOrEmpty(id) && User.IsInRole("Admin"))
            {
                // Si el usuario es Admin y se proporciona un ID (Gestionar Perfiles)
                var empleado = await _context.Empleados
                    .Include(e => e.User) // Incluye la relación con User
                     .Include(e => e.Puesto) // Incluye la relación con Puesto
                     .Include(e => e.EmpleadoDeduc) // Incluye la relación con EmpleadoDeduc
                         .ThenInclude(ed => ed.Deduccion) // Luego incluye la relación con Deducción a través de EmpleadoDeduc
                     .Include(e => e.EmpleadoBonif) // Incluye la relación con EmpleadoBonif
                         .ThenInclude(eb => eb.Bonificacion) // Luego incluye la relación con Bonificación a través de EmpleadoBonif
                     .FirstOrDefaultAsync(e => e.EmpleadoID == id); // Usa EmpleadoID para encontrar al empleado

                if (empleado == null)
                {
                    return NotFound(); // Si el empleado no existe, retorno un error 404
                }

                // Cargar deducciones
                var deducciones = await _context.Deduccion.ToListAsync();
                var deduccionesSeleccionadas = empleado.EmpleadoDeduc.Select(d => d.DeduccionID).ToList();
                ViewBag.Deducciones = deducciones.Select(d => new SelectListItem
                {
                    Value = d.DeduccionID.ToString(),
                    Text = d.Nombre,
                    Selected = deduccionesSeleccionadas.Contains(d.DeduccionID)
                }).ToList();

                // Cargar bonificaciones
                var bonificaciones = await _context.Bonificacion.ToListAsync();
                var bonificacionesSeleccionadas = empleado.EmpleadoBonif.Select(b => b.BonificacionID).ToList();
                ViewBag.Bonificaciones = bonificaciones.Select(b => new SelectListItem
                {
                    Value = b.BonificacionID.ToString(),
                    Text = b.Nombre,
                    Selected = bonificacionesSeleccionadas.Contains(b.BonificacionID)
                }).ToList();

                // Llenar el ViewBag con la lista de roles en formato de SelectList
                ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name", empleado.RoleId);

                // Llenar el ViewBag con la lista de puestos en formato de SelectList
                ViewBag.Puestos = new SelectList(await _context.Puesto.ToListAsync(), "PuestoID", "Nombre", empleado.PuestoID);

                // Mostrar vista editable para administradores
                return View("Profile", empleado); // Vista editable para Admins
            }

            return NotFound(); // Si no se cumple ninguna condición válida, retorno un error 404
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")] // Solo los administradores pueden editar
        public async Task<IActionResult> Profile(string id, EmpleadoEditViewModel model, int[] selectedDeducciones, int[] selectedBonificaciones)
        {
            // Verificar si el ID proporcionado coincide con el ID del modelo
            if (id != model.EmpleadoID)
            {
                return BadRequest(); // Retornar un error si el ID no coincide
            }

            // Verificar si el RoleId o PuestoID están vacíos
            if (string.IsNullOrEmpty(model.RoleId) || !model.PuestoID.HasValue)
            {
                Debug.WriteLine("RoleId o PuestoID están vacíos");
                ModelState.AddModelError(string.Empty, "Debe seleccionar un rol y un puesto.");
            }

            // Verificar si al menos una deducción ha sido seleccionada
            if (selectedDeducciones == null || selectedDeducciones.Length == 0)
            {
                Debug.WriteLine("No se seleccionaron deducciones");
                ModelState.AddModelError("Deducciones", "Debe seleccionar al menos una deducción.");
            }

            // Verificar si el modelo es válido antes de continuar
            if (ModelState.IsValid)
            {
                Debug.WriteLine("El modelo es válido");
                try
                {
                    var empleadoExistente = await _context.Empleados
                        .Include(e => e.EmpleadoDeduc) // Incluye las deducciones
                        .Include(e => e.EmpleadoBonif) // Incluye las bonificaciones
                        .FirstOrDefaultAsync(e => e.EmpleadoID == id);

                    if (empleadoExistente == null)
                    {
                        return NotFound(); // Retornar un error si el empleado no existe
                    }

                    // Asignar el rol al empleado basado en el RoleId seleccionado
                    var role = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == model.RoleId);
                    if (role != null)
                    {
                        empleadoExistente.RoleId = model.RoleId;
                        empleadoExistente.Role = role;
                    }

                    // Actualizar otros campos necesarios
                    empleadoExistente.Nombre = model.Nombre;
                    empleadoExistente.Direccion = model.Direccion;
                    empleadoExistente.Email = model.Email;
                    empleadoExistente.Telefono = model.Telefono;
                    empleadoExistente.FechaContratacion = model.FechaContratacion;
                    empleadoExistente.PuestoID = model.PuestoID;

                    // Manejar las deducciones seleccionadas
                    empleadoExistente.EmpleadoDeduc.Clear();

                    if (selectedDeducciones != null)
                    {
                        var nuevasDeduccionesSeleccionadas = await _context.Deduccion
                            .Where(d => selectedDeducciones.Contains(d.DeduccionID))
                            .ToListAsync();

                        foreach (var deduccion in nuevasDeduccionesSeleccionadas)
                        {
                            empleadoExistente.EmpleadoDeduc.Add(new EmpleadoDeduc
                            {
                                EmpleadoID = empleadoExistente.EmpleadoID,
                                DeduccionID = deduccion.DeduccionID
                            });
                        }
                    }

                    // Manejar las bonificaciones seleccionadas
                    empleadoExistente.EmpleadoBonif.Clear();

                    if (selectedBonificaciones != null)
                    {
                        var nuevasBonificacionesSeleccionadas = await _context.Bonificacion
                            .Where(b => selectedBonificaciones.Contains(b.BonificacionID))
                            .ToListAsync();

                        foreach (var bonificacion in nuevasBonificacionesSeleccionadas)
                        {
                            empleadoExistente.EmpleadoBonif.Add(new EmpleadoBonif
                            {
                                EmpleadoID = empleadoExistente.EmpleadoID,
                                BonificacionID = bonificacion.BonificacionID
                            });
                        }
                    }

                    _context.Update(empleadoExistente);
                    await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos

                    TempData["SuccessMessage"] = "Perfil actualizado exitosamente."; // Mensaje de éxito
                    return RedirectToAction(nameof(Profile), new { id = model.EmpleadoID });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(model.EmpleadoID))
                    {
                        TempData["ErrorMessage"] = "Error: el empleado no existe."; // Mensaje de error
                        return NotFound(); // Retornar un error si el empleado no existe
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Error de concurrencia al actualizar el perfil."; // Mensaje de error en caso de problemas de concurrencia
                        throw; // Lanzar la excepción si hay problemas con la concurrencia
                    }
                }
            }

            // Si llegamos aquí, significa que hubo un error de validación
            ViewBag.RoleId = new SelectList(_context.Roles, "Id", "Name", model.RoleId);
            ViewBag.Puestos = new SelectList(_context.Puesto.ToList(), "PuestoID", "Nombre", model.PuestoID);

            // Volver a cargar las deducciones
            var deducciones = await _context.Deduccion.ToListAsync();
            var deduccionesSeleccionadas = model.Deducciones.Select(d => d.DeduccionID).ToList();
            ViewBag.Deducciones = deducciones.Select(d => new SelectListItem
            {
                Value = d.DeduccionID.ToString(),
                Text = d.Nombre,
                Selected = deduccionesSeleccionadas.Contains(d.DeduccionID)
            }).ToList();

            // Volver a cargar las bonificaciones
            var bonificaciones = await _context.Bonificacion.ToListAsync();
            var bonificacionesSeleccionadas = model.Bonificaciones.Select(b => b.BonificacionID).ToList();
            ViewBag.Bonificaciones = bonificaciones.Select(b => new SelectListItem
            {
                Value = b.BonificacionID.ToString(),
                Text = b.Nombre,
                Selected = bonificacionesSeleccionadas.Contains(b.BonificacionID)
            }).ToList();

            TempData["ErrorMessage"] = "Error al intentar actualizar el perfil. Verifique los datos e intente nuevamente."; // Mensaje de error si la validación falla
            return View("Profile", model); // Retornar a la vista del perfil
        }



        private bool EmpleadoExists(string id)
        {
            return _context.Empleados.Any(e => e.EmpleadoID == id);
        }

        // GET: Empleados/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound(); // Si el ID no es proporcionado, se retorna un error 404
            }

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(m => m.EmpleadoID == id); // Busco el empleado por ID

            if (empleado == null)
            {
                return NotFound(); // Si el empleado no existe, se retorna un error 404
            }

            return View(empleado); // Retorno la vista de confirmación con los datos del empleado
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var empleado = await _context.Empleados.FindAsync(id); // Busco el empleado por ID

            if (empleado != null)
            {
                _context.Empleados.Remove(empleado); // Elimino el empleado de la base de datos
                await _context.SaveChangesAsync(); // Guardo los cambios
            }

            return RedirectToAction(nameof(Index)); // Redirijo a la lista de empleados después de la eliminación
        }



    }
}

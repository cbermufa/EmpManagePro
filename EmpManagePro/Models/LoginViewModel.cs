using System.ComponentModel.DataAnnotations;

namespace EmpManagePro.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo correo electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "Debe proporcionar un correo electrónico válido.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es requerida.")]
        //[StringLength(30, MinimumLength = 12, ErrorMessage = "La contraseña debe tener entre 12 y 30 caracteres.")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@+!&$*-.])[A-Za-z\d@+!&$*-.]{12,30}$",
        //ErrorMessage = "La contraseña debe tener al menos una letra minúscula, una letra mayúscula, un número y un carácter especial (@+!&$*-.).")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; } = false;
    }
}

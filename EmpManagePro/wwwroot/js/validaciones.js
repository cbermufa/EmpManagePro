document.addEventListener('DOMContentLoaded', function () {
    const empleadoIDInput = document.getElementById('empleadoID');
    const nombreInput = document.getElementById('nombre');
    const direccionInput = document.getElementById('direccion');
    const emailInput = document.getElementById('email');
    const telefonoInput = document.getElementById('telefono');
    const calendarioInput = document.getElementById('fechaContratacion');
    const rolInput = document.getElementById('rol');
    const puestoInput = document.getElementById('PuestoID');
    const passwordInput = document.getElementById('password');
    const confirmPasswordInput = document.getElementById('confirmPassword');
    const empleadoSubmit = document.getElementById('crearBtn');
    const form = document.getElementById('crearEmpleadoForm');

    let checkboxes = document.querySelectorAll('input[name="DeduccionesID"]');

    let nombreValid = false,
        empleadoIDValid = false,
        direccionValid = false,
        emailValid = false,
        telefonoValid = false,
        fechaContratacionValid = false,
        rolValid = false,
        puestoValid = false,
        deduccionValid = false,
        passwordValid = false,
        confirmPasswordValid = false

    if (form) {
        form.addEventListener('submit', function (event) {
            validateForm();
            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            }
        });
    }

    if (calendarioInput) {
        var today = new Date().toISOString().split('T')[0]; // Obtiene la fecha actual en formato YYYY-MM-DD
        calendarioInput.value = today; // Establece el valor del input a la fecha actual
        fechaContratacionValid = true;
    }

    document.addEventListener('keydown', function (event) {
        if (event.key === 'Enter') {
            empleadoSubmit.click();
        }
    });

    function validateForm() {

        const allValid = nombreValid && empleadoIDValid && direccionValid && emailValid && telefonoValid && fechaContratacionValid && rolValid && puestoValid && deduccionValid && passwordValid && confirmPasswordValid;
        const boton = document.getElementById('crearBtn');

        //console.log(nombreValid, empleadoIDValid, direccionValid, emailValid, telefonoValid, fechaContratacionValid, rolValid, puestoValid, deduccionValid);

        if (allValid) {
            //console.log('Deshabilitar boton');
            boton.disabled = false;
        } else {
            //console.log('Habilitar boton');
            boton.disabled = true;
        }
    }

    if (empleadoIDInput) {
        empleadoIDInput.addEventListener('input', function (event) {
            const input = event.target;
            let value = input.value.replace(/\D/g, ''); // Eliminamos cualquier carácter que no sea un dígito
            const requiredMessage = "El campo ID es requerido.";
            const lengthMessage = "El ID debe tener exactamente 10 dígitos en el formato 0-1234-5678.";

            // Formatear con los guiones
            if (value.length > 1) {
                value = value.slice(0, 1) + '-' + value.slice(1);
            }
            if (value.length > 6) {
                value = value.slice(0, 6) + '-' + value.slice(6, 10);
            }

            // Asignamos el valor formateado al input
            input.value = value;

            if (value == '') {
                input.setCustomValidity(requiredMessage);
                input.reportValidity();
                empleadoIDValid = false;
            } else if (value.length < 11) { // 10 dígitos + 2 guiones = 11 caracteres
                input.setCustomValidity(lengthMessage);
                input.reportValidity();
                empleadoIDValid = false;
            } else {
                input.setCustomValidity('');
                empleadoIDValid = true;
            }

            validateForm(); 
        });
    }

    if (nombreInput) {
        nombreInput.addEventListener('input', function (event) {

            const input = event.target;
            const regex = /^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]*$/;
            const value = input.value;
            const requiredMessage = "El campo Nombre es requerido.";
            const regexMessage = "Por favor, ingrese solo letras, tildes, diéresis y la letra Ñ.";
            const lengthMessage = "El nombre debe ser tener mínimo 3 letras.";
            
            if (!regex.test(value)) {

                input.setCustomValidity(regexMessage);
                input.reportValidity();
                input.value = value.slice(0, -1);
                nombreValid = false;
            } else if (value == '') {
                input.setCustomValidity(requiredMessage);
                input.reportValidity();
                nombreValid = false;
            } else if (value.length < 3) {
                input.setCustomValidity(lengthMessage);
                input.reportValidity();
                nombreValid = false;
            } else {
                input.setCustomValidity('');
                nombreValid = true;
            }

            validateForm();
        });
    }

    if (direccionInput) {
        direccionInput.addEventListener('input', function (event) {
            const input = event.target;
            const regex = /^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s0-9.,]*$/;
            const value = input.value;

            // Mensaje de error del modelo
            const requiredMessage = "La dirección es requerida.";
            const regexMessage = "Por favor, ingrese solo letras, tildes, diéresis, la letra Ñ y números.";
            const lengthMessage = "La Dirección debe contener entre 10 y 100 digitos";

            if (!regex.test(value)) {
                input.setCustomValidity(regexMessage);
                input.reportValidity();
                input.value = value.slice(0, -1);
                direccionValid = false;
            } else if (value == '') {
                input.setCustomValidity(requiredMessage);
                input.reportValidity();
                direccionValid = false;
            } else if (value.length < 10) {
                input.setCustomValidity(lengthMessage);
                input.reportValidity();
                direccionValid = false;
            } else {
                input.setCustomValidity('');
                direccionValid = true;
            }
            validateForm();
        });
    }

    if (emailInput) {
        emailInput.addEventListener('input', function (event) {
            
            const input = event.target;
            const regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
            const value = input.value;

            //console.log(value);

            // Mensaje de error del modelo
            const requiredMessage = "El Email es requerido.";
            const regexMessage = "El formato del correo no es válido";

            if (!regex.test(value)) {
                //console.log('Entra');
                input.setCustomValidity(regexMessage);
                input.reportValidity();
                emailValid = false;
            } else if (value == '') {
                //console.log('entra');
                input.setCustomValidity(requiredMessage);
                input.reportValidity();
                emailValid = false;
            }  else {
                input.setCustomValidity('');
                emailValid = true;
            }
            validateForm();
        });
    }
    if (telefonoInput) {
        telefonoInput.addEventListener('input', function (event) {
            const input = event.target;
            let value = input.value.replace(/\D/g, ''); // Eliminamos cualquier carácter que no sea un dígito
            const requiredMessage = "El teléfono es requerido.";
            const lengthMessage = "El teléfono debe tener exactamente 8 dígitos.";

            // Formatear con el guión
            if (value.length > 4) {
                value = value.slice(0, 4) + '-' + value.slice(4, 8);
            }

            // Asignamos el valor formateado al input
            input.value = value;

            if (value == '') {
                input.setCustomValidity(requiredMessage);
                input.reportValidity();
                telefonoValid = false;
            } else if (value.length < 9) { // 8 dígitos + 1 guión = 9 caracteres
                input.setCustomValidity(lengthMessage);
                input.reportValidity();
                telefonoValid = false;
            } else {
                input.setCustomValidity('');
                input.reportValidity();
                telefonoValid = true;
            }

            validateForm(); // Actualizar la validación del formulario
        });
    }

    if (passwordInput) {
        console.log('Entra Password');
        passwordInput.addEventListener('input', function (event) {
            
            console.log('Entra Password');
            const input = event.target;
            const value = input.value;
            const requiredMessage = "El password es requerido.";
            const errorMessage = "La contraseña debe tener al menos una letra minúscula, una letra mayúscula, un número y un carácter especial (@+!&$*-.).";
            const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@+!&$*.\-])[A-Za-z\d@+!&$*.\-]{12,30}$/;

            if (!regex.test(value)) {
                console.log(value);
                input.setCustomValidity(errorMessage);
                input.reportValidity();
                passwordValid = false;
            } else if (value == '') {
                //console.log('entra');
                input.setCustomValidity(requiredMessage);
                input.reportValidity();
                passwordValid = false;
            } else {
                input.setCustomValidity('');
                passwordValid = true;
            }
            validateForm(); // Actualizar la validación del formulario
        });
    }

    if (confirmPasswordInput) {
        confirmPasswordInput.addEventListener('input', function (event) {
            console.log('Entra confirmPassword');
            let password = passwordInput.value,
                confirmar = confirmPasswordInput.value;

            const input = event.target;
            const value = input.value;
            const requiredMessage = "La confirmación del password es requerida.";
            const errorMessage = "La contraseña debe tener al menos una letra minúscula, una letra mayúscula, un número y un carácter especial (@+!&$*-.).";
            const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@+!&$*.\-])[A-Za-z\d@+!&$*.\-]{12,30}$/;

            if (!regex.test(value)) {
                //console.log('Entra');
                input.setCustomValidity(errorMessage);
                input.reportValidity();
                confirmPasswordValid = false;
            } else if (value == '') {
                //console.log('entra');
                input.setCustomValidity(requiredMessage);
                input.reportValidity();
                confirmPasswordValid = false;
            } else if (password != confirmar) {
                input.setCustomValidity('Las contraseñas no coinciden');
                input.reportValidity();
                confirmPasswordValid = false;
            } else {
                input.setCustomValidity('');
                confirmPasswordValid = true;
            }
            validateForm(); // Actualizar la validación del formulario
        });
    }
    calendarioInput.addEventListener('change', function () {
        const fechaValor = calendarioInput.value;
        const fecha = new Date(fechaValor);
        const errorMessage = "La fecha no es válida.";

        if (isValidDate(fecha)) {
            fechaContratacionValid = true;
            calendarioInput.setCustomValidity('');
            
        } else {
            calendarioInput.setCustomValidity(errorMessage);
            input.reportValidity();
            fechaContratacionValid = false;
        }
        validateForm();
    });

     rolInput.addEventListener('change', function () {
        const rol = rolInput.value;
        const errorMessage = "El rol no es válido.";
         if (rol == '') {
             rolInput.setCustomValidity(errorMessage);
             rolInput.reportValidity();
             rolValid = false;
         } else {
             rolInput.setCustomValidity('');
             rolValid = true;
         }
         validateForm();
     });

    puestoInput.addEventListener('change', function () {
        const puesto = puestoInput.value;
        const errorMessage = "El puesto no es válido.";
        if (puesto == '') {
            puestoInput.setCustomValidity(errorMessage);
            puestoInput.reportValidity();
            puestoValid = false;
        } else {
            puestoInput.setCustomValidity('');
            puestoValid = true;
        }
        validateForm();
    });

    

    // Agrega un listener a cada checkbox para detectar cambios
    checkboxes.forEach(checkbox => {
        checkbox.addEventListener('change', checkCheckboxes);
    });

    // Función para verificar si al menos un checkbox está seleccionado
    function checkCheckboxes() {
        var checked = Array.from(checkboxes).some(checkbox => checkbox.checked);
        if (checked) {
            //console.log("Al menos un checkbox está seleccionado");
            deduccionValid = true;
        } else {
            //console.log("Ningún checkbox está seleccionado");
            deduccionValid = false;
            
        }

        validateForm();
    }

        
    

    // Función para verificar si una fecha es válida
    function isValidDate(d) {
        return d instanceof Date && !isNaN(d);
    }

    checkCheckboxes();

    validateForm();
});

document.addEventListener('DOMContentLoaded', function () {
    const nombreInput = document.getElementById('nombre');
    const direccionInput = document.getElementById('direccion');
    const emailInput = document.getElementById('email');
    const telefonoInput = document.getElementById('telefono');
    const calendarioInput = document.getElementById('fechaContratacion');
    const rolInput = document.getElementById('rol');
    const empleadoSubmit = document.getElementById('crearBtn');

    let nombreValid = false,
        direccionValid = false,
        emailValid = false,
        telefonoValid = false,
        fechaContratacionValid = false,
        rolValid = false;

    function validateNombre() {
        const value = nombreInput.value;
        const regex = /^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]*$/;
        const requiredMessage = "El campo Nombre es requerido.";
        const regexMessage = "Por favor, ingrese solo letras, tildes, diéresis y la letra Ñ.";
        const lengthMessage = "El nombre debe ser tener mínimo 3 letras.";

        if (!regex.test(value)) {
            nombreInput.setCustomValidity(regexMessage);
            nombreInput.value = value.slice(0, -1);
            nombreValid = false;
        } else if (value == '') {
            nombreInput.setCustomValidity(requiredMessage);
            nombreValid = false;
        } else if (value.length < 3) {
            nombreInput.setCustomValidity(lengthMessage);
            nombreValid = false;
        } else {
            nombreInput.setCustomValidity('');
            nombreValid = true;
        }
        nombreInput.reportValidity();
    }

    function validateDireccion() {
        const value = direccionInput.value;
        const regex = /^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s0-9.,]*$/;
        const requiredMessage = "La dirección es requerida.";
        const regexMessage = "Por favor, ingrese solo letras, tildes, diéresis, la letra Ñ y números.";
        const lengthMessage = "La Dirección debe contener entre 10 y 100 dígitos.";

        if (!regex.test(value)) {
            direccionInput.setCustomValidity(regexMessage);
            direccionInput.value = value.slice(0, -1);
            direccionValid = false;
        } else if (value == '') {
            direccionInput.setCustomValidity(requiredMessage);
            direccionValid = false;
        } else if (value.length < 10) {
            direccionInput.setCustomValidity(lengthMessage);
            direccionValid = false;
        } else {
            direccionInput.setCustomValidity('');
            direccionValid = true;
        }
        direccionInput.reportValidity();
    }

    function validateEmail() {
        const value = emailInput.value;
        const requiredMessage = "El campo Email es requerido.";
        const invalidEmailMessage = "Por favor, ingrese un email válido.";

        if (value == '') {
            emailInput.setCustomValidity(requiredMessage);
            emailValid = false;
        } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value)) {
            emailInput.setCustomValidity(invalidEmailMessage);
            emailValid = false;
        } else {
            emailInput.setCustomValidity('');
            emailValid = true;
        }
        emailInput.reportValidity();
    }

    function validateTelefono() {
        const value = telefonoInput.value.replace(/\D/g, ''); // Eliminamos cualquier carácter que no sea un dígito
        const requiredMessage = "El teléfono es requerido.";
        const lengthMessage = "El teléfono debe tener exactamente 8 dígitos.";

        // Formatear con el guión
        if (value.length > 4) {
            telefonoInput.value = value.slice(0, 4) + '-' + value.slice(4, 8);
        }
        //console.log(value.length);
        if (value == '') {
            telefonoInput.setCustomValidity(requiredMessage);
            telefonoValid = false;
        } else if (value.length < 8) { // 8 dígitos + 1 guión = 9 caracteres
            telefonoInput.setCustomValidity(lengthMessage);
            telefonoValid = false;
        } else {
            telefonoInput.setCustomValidity('');
            telefonoValid = true;
        }
        telefonoInput.reportValidity();
    }

    function validateFechaContratacion() {
        const value = calendarioInput.value;
        const errorMessage = "La fecha no es válida.";
        const fecha = new Date(value);

        if (isValidDate(fecha)) {
            fechaContratacionValid = true;
            calendarioInput.setCustomValidity('');
        } else {
            calendarioInput.setCustomValidity(errorMessage);
            fechaContratacionValid = false;
        }
        calendarioInput.reportValidity();
    }

    function validateRol() {
        const value = rolInput.value;
        const errorMessage = "El rol no es válido.";

        if (value == '') {
            rolInput.setCustomValidity(errorMessage);
            rolValid = false;
        } else {
            rolInput.setCustomValidity('');
            rolValid = true;
        }
        rolInput.reportValidity();
    }

    function validateForm() {
        validateNombre();
        validateDireccion();
        validateEmail();
        validateTelefono();
        validateFechaContratacion();
        validateRol();

        const allValid = nombreValid && direccionValid && emailValid && telefonoValid && fechaContratacionValid && rolValid;
        empleadoSubmit.disabled = !allValid;
    }

    // Agregar eventos de entrada a todos los inputs
    nombreInput.addEventListener('input', validateForm);
    direccionInput.addEventListener('input', validateForm);
    emailInput.addEventListener('input', validateForm);
    telefonoInput.addEventListener('input', validateForm);
    calendarioInput.addEventListener('change', validateForm);
    rolInput.addEventListener('change', validateForm);

    //form.addEventListener('submit', function (event) {
    //    validateForm();
    //    if (!form.checkValidity()) {
    //        event.preventDefault();
    //        event.stopPropagation();
    //    }
    //});

    document.addEventListener('keydown', function (event) {
        if (event.key === 'Enter') {
            empleadoSubmit.click();
        }
    });

    // Función para verificar si una fecha es válida
    function isValidDate(d) {
        return d instanceof Date && !isNaN(d);
    }



    validateForm();
});

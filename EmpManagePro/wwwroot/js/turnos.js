document.addEventListener('DOMContentLoaded', function () {
    let diasSeleccionados = 0,
        maxDias = 6;

    // Selección de elementos
    const tipoTurnoInput = document.getElementById('tipoTurno');
    const cantidadHorasInput = document.getElementById('CantidadHoras');
    const horaEntradaInput = document.getElementById('horaEntrada');
    const horaSalidaInput = document.getElementById('horaSalida');
    const crearTurnoBtn = document.getElementById('crearTurnoBtn');

    // Función para habilitar el botón de crear turno
    function checkFormCompletion() {
        const tipoTurnoValido = tipoTurnoInput.value.length > 3;
        const cantidadHorasValida = cantidadHorasInput.value > 0 && cantidadHorasInput.value <= 72;
        const horaEntradaValida = horaEntradaInput.value !== '';
        const horaSalidaValida = horaSalidaInput.value !== '';

        if (tipoTurnoValido && cantidadHorasValida && horaEntradaValida && horaSalidaValida && diasSeleccionados > 0) {
            crearTurnoBtn.disabled = false;
        } else {
            crearTurnoBtn.disabled = true;
        }
    }

    // Manejo de selección de días
    document.querySelectorAll('.dia-semana').forEach(function (checkbox) {
        checkbox.addEventListener('change', function () {
            diasSeleccionados = document.querySelectorAll('.dia-semana:checked').length;

            if (diasSeleccionados >= maxDias) {
                document.querySelectorAll('.dia-semana:not(:checked)').forEach(function (cb) {
                    cb.disabled = true;
                });
            } else {
                document.querySelectorAll('.dia-semana').forEach(function (cb) {
                    cb.disabled = false;
                });
            }

            if (horaEntradaInput.value !== '') {
                recalcularHoraSalida();
            }

            checkFormCompletion();
        });
    });

    // Manejo de cambio de cantidad de horas
    cantidadHorasInput.addEventListener('input', function () {
        let cantidadHoras = parseInt(cantidadHorasInput.value) || 0;

        if (cantidadHoras > 72) {
            cantidadHorasInput.value = 72; // Limita la cantidad de horas a 72
        }

        if (horaEntradaInput.value !== '') {
            recalcularHoraSalida();
        }

        checkFormCompletion();
    });

    // Manejo de cambio de hora de entrada
    horaEntradaInput.addEventListener('change', function () {
        recalcularHoraSalida();
        checkFormCompletion();
    });

    // Función para recalcular la hora de salida
    function recalcularHoraSalida() {
        let horaEntrada = horaEntradaInput.value,
            cantidadHoras = parseInt(cantidadHorasInput.value) || 0;

        if (cantidadHoras > 0 && diasSeleccionados > 0) {
            let horasPorDia = cantidadHoras / diasSeleccionados;

            // Crea un objeto Date usando la hora de entrada
            let tiempoEntrada = new Date('1970-01-01T' + horaEntrada + ':00Z');

            // Calcula el tiempo de salida sumando horasPorDia a la hora de entrada
            let tiempoSalida = new Date(tiempoEntrada.getTime() + horasPorDia * 3600000);

            // Extrae las horas y minutos de tiempoSalida
            let horas = String(tiempoSalida.getUTCHours()).padStart(2, '0'),
                minutos = String(tiempoSalida.getUTCMinutes()).padStart(2, '0');

            // Actualiza el valor del input de hora de salida y habilítalo
            horaSalidaInput.value = horas + ':' + minutos;
            horaSalidaInput.disabled = false;
        }
    }

    // Validación del tipo de turno
    tipoTurnoInput.addEventListener('input', function () {
        checkFormCompletion();
    });
});


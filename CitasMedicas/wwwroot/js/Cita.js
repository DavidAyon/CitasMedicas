

function consultarDoctores() {
        result2 = $.ajax({
            type: 'GET',
            url: "/Cita/GetDoctores",
            success: function (res) {
                debugger;
                console.log(res);
            }
        });
}

function guardar() {
    let doctor = document.getElementById("doctor").value;
    let fecha = document.getElementById("fecha").value;
    let hora = document.getElementById("hora").value;
    let pacienteNombre = document.getElementById("pacienteNombre").value;
    let pacienteCorreo = document.getElementById("pacienteCorreo").value;
    let cita = {
        Id: 0,
        DoctorId: doctor,
        Doctor: null,
        UsuarioId: null,
        Fecha: fecha,
        Hora: hora,
        PacienteNombre: pacienteNombre,
        PacienteCorreo: pacienteCorreo 
    }
    if (pacienteNombre == "" || pacienteCorreo == "" || fecha == "") {
        toastr.warning("Favor de llenar todos los campos");
        return false;
    }
    result2 = $.ajax({
        type: 'POST',
        url: "/Cita/GuardarCita",
        data: { value: cita }, 
        success: function (res) {
            console.log(res);
            if (res.status) {
                toastr.success("Cita agendada");
                limpiar();
                cambioFechaDoctor();
            } else {
                toastr.warning("Ocurrio un problema");
            }
        }
    });
}


function cambioFechaDoctor() {
    let doctor = document.getElementById("doctor").value;
    let fecha = document.getElementById("fecha").value;
    if (fecha == "") {
        return false;
    }
    result2 = $.ajax({
        type: 'GET',
        url: "/Cita/ConsultarCitas",
        data: { doctorId: doctor, fecha: fecha },
        success: function (res) {
            console.log(res);
            $('#hora').empty();
            let selectArray = [{ value: 10, text: "10 AM" }, { value: 11, text: "11 AM" },
                { value: 12, text: "12 PM" }, { value: 13, text: "1 AM" }, { value: 14, text: "2 AM" },
                { value: 15, text: "3 AM" }, { value: 16, text: "4 AM" }, { value: 17, text: "5 AM" },];
            var selectList = document.getElementById("hora");
            for (var i = 0; i < selectArray.length; i++) {
                var option = document.createElement("option");
                option.value = selectArray[i].value;
                option.text = selectArray[i].text;
                if (res.response.length > 0) {
                    let encontrado = res.response.find(x => x.hora == selectArray[i].value);
                    if (encontrado != null && encontrado != undefined) {
                        option.disabled = true;
                    }
                } 
                selectList.appendChild(option);
            }
        }
    });
    
}

function limpiar() {
    $("#pacienteNombre").val(null)
    $("#pacienteCorreo").val(null)
}
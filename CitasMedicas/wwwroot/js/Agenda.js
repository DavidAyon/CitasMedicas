

function Consultar() {
    let doctor = document.getElementById("doctor").value;
    let fecha = document.getElementById("fecha").value;
    if ( fecha == "") {
        toastr.warning("Favor de seleccionar una fecha");
        return false;
    }
    result2 = $.ajax({
        type: 'GET',
        url: "/Cita/ConsultarAgendaDoctor",
        data: { doctorId: doctor, fecha: fecha },
        success: function (res) {
            console.log(res);
            if (res.response.length > 0) {
                $('#table_id tr').not(':first').not(':last').remove();
                var html = '';
                for (var i = 0; i < res.response.length; i++)
                    html += '<tr><td>' + res.response[i].hora +
                        '</td><td>' + res.response[i].paciente + '</td> <td>' + res.response[i].correo + '</td></tr>';
                $('#table_id tr').first().after(html);
            } else {
                toastr.warning("No se encontraron registros");
            }
        }
    });
}
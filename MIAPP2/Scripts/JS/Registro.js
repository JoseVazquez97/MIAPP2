
$(document).ready(function () {
    $("#btnRegistrar").click(function () {
        Registrarse();
    });

});

function Registrarse() {
    var apiUrl = "http://192.168.0.111:5295/api/Usuario/Registro"; // Reemplaza con la URL correcta de tu API

    var usuf = {
        UsuarioID: 0,
        UsuarioNick: $("#entryUsername").val(),
        UsuarioPass: $("#entryPassword").val(),
        UsuarioEmail: "Aaaa@gmail.com",
        UsuarioEstado: "s",
        GoogleUserID: "string",
        UsuarioStatus: "A",
        UsuarioTipo: "J",
        Usuario_FechaRegistro: "2023-09-27", // Puedes mantener este formato si es aceptado por la API
        CodigoVerificacion: "string",
        InfoCodPais: "+54",
        InfoNroArea: "2954",
        InfoNroTelefono: "283322",
        usuarioReputacion: 0 // Añade este campo si es necesario
    };

    var solicitudRegistro = {
        usuario: usuf,
        localidad: 0 // Este valor puede cambiar según la opción seleccionada
    };

    var selectedCountry = $("#paisPicker").val(); // Obtiene el valor seleccionado del selector de países

    // Modifica el atributo localidad del objeto solicitudRegistro según la opción seleccionada
    solicitudRegistro.localidad = parseInt(selectedCountry); // Convierte a entero si es necesario

    $.ajax({
        type: "POST",
        url: apiUrl,
        data: JSON.stringify(solicitudRegistro),
        contentType: "application/json",
        success: function (data) {
            if (data !== undefined) {
                alert("Registro exitoso");
                if (data.usuario.UsuarioTipo === "C") {
                    // Redirige al usuario a la página correspondiente
                    window.location.href = "/MIAPP2/USUARIO2/Home"; // Reemplaza con la URL correcta
                } else {
                    window.location.href = "/MIAPP2/USUARIO2/Home"; // Reemplaza con la URL correcta
                }
            } else {
                alert("Registro fallido");
            }
        },
        error: function () {
            alert("Error en la solicitud AJAX");
        }
    });
}
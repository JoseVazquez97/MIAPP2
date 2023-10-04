$(document).ready(function () {
    // Agregar un evento click al botón "Guardar"
    $("#btnGuardar").click(function (e) {
        e.preventDefault(); // Evita que el formulario se envíe automáticamente

        // Llama a la función iniciarSesion
        iniciarSesion();
    });
});



function iniciarSesion() {
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

    $.ajax({
        type: "PUT",
        url: "http://192.168.0.111:5295/api/Usuario/EditarUsuario", // Reemplaza con la URL correcta de tu API
        data: JSON.stringify(usuf),
        contentType: "application/json",

        success: function (data) {
            if (data !== undefined) {
                // Redirige al usuario a la página correspondiente
                window.location.href = "/MIAPP2/USUARIO2/Home";
            } else {
                alert("Error al editar el usuario");
            }
        },
        error: function () {
            alert("Error en la solicitud AJAX");
        }
    });
}
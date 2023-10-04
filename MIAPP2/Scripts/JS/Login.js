
function iniciarSesion() {
    var usuario = {
        UsuarioID : 0,
        UsuarioNick: $("#Usuario2Nick").val(),
        UsuarioPass: $("#Usuario2Pass").val(),
        UsuarioEmail : "user@example.com",
        UsuarioEstado : "s",
        GoogleUserID : "string",
        UsuarioStatus : "s",
        UsuarioTipo : "s",
        Usuario_FechaRegistro: new Date().toISOString(),
        CodigoVerificacion : "string",
        InfoCodPais : "string",
        InfoNroArea : 0,
        InfoNroTelefono : 0
    };

    $.ajax({
        type: "POST",
        url: "http://192.168.0.111:5295/api/Usuario/Login", // Reemplaza con la URL correcta de tu API
        data: JSON.stringify(usuario),
        contentType: "application/json",

        success: function (data) {
            if (data !== undefined) {
                window.location.href = "/MIAPP2/USUARIO2/Home";
            } else {
                alert("Inicio de sesión fallido");
            }
        },
        error: function () {
            alert("Error en la solicitud AJAX");
        }
    });
}

function irRegistro() 
{
    window.location.href = "/MIAPP2/USUARIO2/Registro";
}
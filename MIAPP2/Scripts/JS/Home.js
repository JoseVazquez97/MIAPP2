
$(document).ready(function () {
    TraerBasico();

});

function TraerBasico()
{
    $.ajax({
        type: "GET",
        url: "http://192.168.0.111:5295/api/Custom/TraerBasico",
        success: function (data) {
            if (data !== undefined) {
                alert("Ok");

                var sessionNick = data.sessionNick;
                var sessionID = data.sessionID;
                var sessionTipo = data.sessionTipo;

                // Actualiza los elementos en la página web para mostrar estos valores
                $("#sessionNickElement").text(sessionNick);
                $("#sessionIDElement").text(sessionID);
                $("#sessionTipoElement").text(sessionTipo);

            } else {
                alert("No");
            }
        },
        error: function () {
            alert("Error en la solicitud AJAX");
        }
    });
}

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChatLinea.aspx.cs" Inherits="WebAppDipnicox.Vista.Chat.ChatEn_Linea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../../Scripts/jquery.signalR-2.4.3.js"></script>
    <script src="/signalr/hubs"></script>

</head>
<body>
        <style>
        .chat-container {
    width: 700px;
    min-height: 400px; /* Altura mínima para ver los mensajes */
    border: 1px solid #ccc;
    border-radius: 8px;
    overflow: hidden;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    display: flex;
    flex-direction: column; /* Cambiamos la dirección de flexbox a columna */
}

.chat-header {
    background-color: #134674;
    color: #fff;
    padding: 10px;
    text-align: center;
}

.chat-content {
    flex: 1;
    display: flex;
}

.chat-messages {
    flex: 1;
    overflow-y: auto;
    padding: 10px;
}

.message {
    padding: 8px;
}

.received {
    background-color: #7eadbf;
    border-radius: 8px 8px 8px 0;
}

.sent {
    background-color: #6d9ebe;
    border-radius: 8px 8px 0 8px;
    text-align: right;
}

.message-text {
    color: #fff;
}

.chat-input {
    flex-basis: 230px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    padding: 10px;
    border-right: 1px solid #ccc;
}

    .chat-input input {
        border: none;
        border-radius: 4px;
        padding: 8px;
        margin-bottom: 8px;
        width: 250px;
    }

    .chat-input button {
        background-color: #134674;
        color: #fff;
        border: none;
        border-radius: 4px;
        padding: 8px 16px;
        cursor: pointer;
        margin-left: 30px;
    }
    </style>
¿
        <div class="chat-container">
        <div class="chat-header">
            <h2>Chat en línea</h2>
        </div>
        <div class="chat-content">
            <div class="chat-input">
                <div class="envio">
                    <input type="text" id="mensaje" placeholder="Escribe tu mensaje aquí" />
                    <button  id="enviarMensaje" >Enviar</button>
                    <%--<input type="text" class="btn btn-success" value="Enviar" />--%>
                </div>
            </div>
            <div class="chat-messages">
                <ul id="discussion">

                </ul>
            </div>
        </div>
    </div>
    <input type="hidden" id="nombreee" />
</body>
    <script type="text/javascript">
    function hora() {
        var now = new Date();
        var tiempo = now.getHours() + ":" + now.getMinutes();
        return tiempo;
    }


    $(function () {
        var chat = $.connection.hubChat
        chat.client.chatLinea = function (nombre, mensaje) {
            var div = $("<div />").text(nombre).html();
            var mensaje = $("<div />").text(mensaje).html();
            var tiempo = hora();


            $("#discussion").append("<li> <Strong> [Hora:" + tiempo + "] - " + div + " Dice: <strong>" + mensaje + "</li>");
        };
        var nombreusu = prompt("Todo lo que hablara en este chat no sale de aqui xD" + "\n\n\nEscribe tu nombre:", " ");
        $("#nombreee").val(nombreusu);
        $("#mensaje").focus();
        $.connection.hub.start().done(function () {
            $("#enviarMensaje").click(function () {
                var nomUsu = $("#nombreee").val();
                var mensajee = $("#mensaje").val();

                chat.server.chat(nomUsu, mensajee);
                $("#mensaje").val("").focus();
            })
        })
    })
    </script>
</html>

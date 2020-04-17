//var _connection = new signalR.HubConnectionBuilder()
document.getElementById("join-group").addEventListener("click", async (event) => {
    var _userName = document.getElementById(userName).value;
    var groupName = document.getElementById(roomInput).value;
    try {
        await _connection.invoke("AddToGroup", _userName, groupName);
    }
    catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();
});
//////////////////////////////AKADEMİ Kodları
//document.getElementById("join-group").addEventListener("click", async (event) => {
//    try {
//        await connection.invoke("addToGroup", chatInput.val, roomInput.val());
//    }
//    catch (e) {
//        console.error(e.toString());
//    }
//    event.preventDefault();
//    });
$(document).ready(function () {
    var chatInput = $("#txtInput");
    var roomInput = $("#txtRoom");
    var userName = prompt("Enter a username");
    var chat = $.connection.chatHub;
    //    addToGroup(chatHub)
    chat.connection.qs = { 'username': userName };
    chat.client.messageReceived = function (username, message) {
        $("ul").append("<li><b>" + username + ": </b><i>"
            + message + "</i></li>");
    };

    $.connection.hub.start().done(function () {
        console.log("hub started!");
        chatInput.keydown(function (e) {
            if (e.which === 13) {
                var text = chatInput.val();
                chat.server.sendMessage(userName, text);
                chatInput.val("");
                self.focus();
            }
        })
    });

    chatInput.focus();
});





"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();

$(function () {
    connection.start().then(function () {

        InvokeMessage();
    }).catch(function () {
        alert('Connect failed to dashboardHub');
    });
});

function InvokeMessage() {
    connection.invoke("SendMessage").catch(function (error) {
        return console.error(error.toString());
    });
}
connection.on("ReceivedMessage", function (messages) {
    BindMessage(messages);
});

function BindMessage(messages) {
    $('.toast-body').empty();

    //$.each(messages, function (index,) {

    //});
}
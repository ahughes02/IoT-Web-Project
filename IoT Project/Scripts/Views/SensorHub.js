$(document).ready(function () {
    // set up click events
    $(".ping").click(function (event) {
        pingGalileo($("#galileoIP").val());
    });

    $(".request").click(function (event) {
        requestTemp($("#comPort").val());
    });
});

// Tells the server to ping then displays the result
function pingGalileo(ip) {
    $.ajax({
        url: $("#ping-url").val(),
        type: "GET",
        "data": { ip: ip },
        success: function (result) {
            var p = $("#pingResponse");
            p.empty();
            p.append(result);
        },
        error: function (xhr, status, msg) {
        }
    });
}

// Requests data from the Galileo
function requestTemp(port) {
    $.ajax({
        url: $("#galileo-request-url").val(),
        type: "GET",
        "data": { COM: port },
        success: function (result) {
            var p = $("#requestResponse");
            p.empty();
            p.append(result);
        },
        error: function (xhr, status, msg) {
        }
    });
}
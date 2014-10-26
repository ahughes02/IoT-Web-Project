var interval;

$(document).ready(function () {
    // set up click events
    $(".ping").click(function (event) {
        pingGalileo($("#galileoIP").val());
    });

    $(".start").click(function (event) {
        $(this).hide();
        $(".stop").show();
        requestData($("#comPort").val());
        interval = setInterval(requestTemp($("#comPort").val()), 5000);
    });

    $(".stop").click(function (event) {
        $(this).hide();
        $(".start").show();
        window.clearInterval(interval);
    });
});

// Tells the server to ping then displays the result
function pingGalileo(ip) {
    $.ajax({
        url: $("#ping-url").val(),
        type: "GET",
        "data": { ip: ip },
        success: function (result) {
            var p = $("#response");
            p.empty();
            p.append(result);
        },
        error: function (xhr, status, msg) {
        }
    });
}

// Requests data from the Galileo
function requestData(port) {
    $.ajax({
        url: $("#galileo-request-url").val(),
        type: "GET",
        "data": { COM: port },
        success: function (result) {
            var p = $("#response");
            p.empty();
            p.append(result);
        },
        error: function (xhr, status, msg) {
        }
    });
}
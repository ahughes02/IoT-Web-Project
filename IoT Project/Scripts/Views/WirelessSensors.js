$(document).ready(function () {
    // set up click events
    $(".ping").click(function (event) {
        pingGalileo($("#galileoIP").val());
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
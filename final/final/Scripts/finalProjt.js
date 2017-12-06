var ajax_call = function callFunction(selectedBid) {
    $("#list").empty();//Clear old data before ajax

    $.ajax({
        url: "/Home/GetBids",
        type: "POST",
        data: { bid: selectedBid },
        success: function (data) {
            data.arr.forEach(function (item) {
                $('#list').append(item);
            });
        },
        error: function () {
            alert('There was an error.');
        }
    });
}
var interval = 1000 * 5; // where X is your timer interval in X seconds

window.setInterval(ajax_call, interval);
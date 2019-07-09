$(function () {
    $('#register-account-form').submit(function (ev) {
        ev.preventDefault();

        console.log(this);

        var $this = $(this);
        var url = $this.attr('action');
        var dataToSend = $this.serialize();

        console.log(dataToSend);

        $.ajax({
            url: url,
            method: "POST",
            data: dataToSend,
            success: function (response) {
                console.log(response.clientName);
                swal("Good job!", "You created a account!", "success");
            },
            error: function () {
                swal("Bad job!", "You did not create an account!", "warning");
            }
        })
    });

    $.ajax({
        type: "GET",
        url: "/Admin/Authorize/GetClients",
        success: function (data) {
            console.log(data)
            var s = '<option value="-1">Please Select a Client</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ClientID + '">' + data[i].ClientName + '</option>';
            }
            $("#clientsDropdown").html(s);
        }
    });
    debugger

})
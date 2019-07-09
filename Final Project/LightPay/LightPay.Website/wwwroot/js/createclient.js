$(function () {
    $('#register-client-form').submit(function (ev) {
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
                swal("Good job!", "You created a client!", "success");
            },
            error: function () {
                debugger
                swal("Bad job!", "You did not create a client!", "warning");
            }
        })
    });
})






$(function () {

    $.ajax({
        type: "GET",
        url: "/Admin/Authorize/GetAccounts",
        success: function (data) {
            console.log(data)
            var s = '<option value="-1">Please Select an Account</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].AccountId + '">' + data[i].Name + '</option>';
            }
            $("#accountsDropdown").html(s);
        }
    });
    $('#accountsDropdown').on("change", function () {
        var accountName = $('#accountsDropdown :selected').text();
        var obj = { accountName };
        AjaxCall('/Account/GetClientName', JSON.stringify(obj), 'POST').done(function (response) {

            $('#clientz').val(response.ClientName);

        }).fail(function (error) {
            alert(error.StatusText);
        });
    });
    //debugger
    $('#register-user-form').submit(function (ev) {
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
                swal("Good job!", "You created a user!", "success");
            },
            error: function () {
                debugger
                swal("Bad job!", "You did not create a user!", "warning");
            }
        })
    });
});
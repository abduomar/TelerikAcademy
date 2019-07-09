$(function () {

    $(function () {

        $.ajax({
            type: "GET",
            url: "/Admin/Authorize/GetUsers",
            success: function (data) {
                //console.log(data)
                var s = '<option value="-1">Please Select User</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].UserId + '">' + data[i].Name + '</option>';
                }
                $("#usersDropdown").html(s);
            }
        });

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

        //debugger
        $('#add-userAccount-form').submit(function (ev) {
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
                    console.log(response.AccountId);
                    console.log(response.UserId);
                    swal("Good job!", "You added Account user!", "success");
                },
                error: function () {
                    debugger
                    swal("Bad job!", "You did not add user account!", "warning");
                }
            })
        });
    });
});

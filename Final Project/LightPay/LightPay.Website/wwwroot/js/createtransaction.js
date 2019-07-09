$(function () {
    //AjaxCall('/Transaction/GetAccounts', null).done(function (response) {
    //    if (response.length > 0) {
    //        $('#accountzDropdown').html('');
    //        var options = '';
    //        options += '<option value="Select">Select</option>';
    //        for (var i = 0; i < response.length; i++) {
    //            options += '<option value="' + response[i].AccountId + '">' + response[i].AccName + '</option>';
    //        }
    //        debugger
    //        $('#accountzDropdown').append(options);
    //    }
    //}).fail(function (error) {
    //    alert(error.StatusText);
    //});

    $.ajax({
        type: "GET",
        url: "/Transaction/GetAccounts",
        success: function (accounts) {
            console.log(accounts)
            auto(accounts)
        },
    })
    function auto(data) {
        var availableTags = data
        $("#tags").autocomplete({
            source: availableTags
        });
    }


    $('#tags').on("change", function () {
        var accountName = $('#tags').val();
        debugger
        var obj = { accountName };
        debugger
        AjaxCall('/Transaction/GetClientName', JSON.stringify(obj), 'POST').done(function (response) {

            $('#client').val(response.ClientName);
            
        }).fail(function (error) {
            alert(error.StatusText);
        });
    });

});
function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: 'application/json'
    });
}

/*
    $.ajax({
        type: "GET",
        url: "/Transaction/GetUserAccounts",
        data: "{}",
        success: function (data) {
            console.log(data)
            var s = '<option value="-1">Please Select an Account</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].AccountId + '">' + data[i].AccName + '</option>';
            }
            $("#accountsDropdown").html(s);
        }
    });

    //debugger
    $('#create-transaction').submit(function (ev) {
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
                console.log(response.AccName);
                swal("Good job!", "Test!", "success");
            },
            error: function () {
                debugger
                swal("Bad job!", "Test!", "warning");
            }
        })
    });
});*/


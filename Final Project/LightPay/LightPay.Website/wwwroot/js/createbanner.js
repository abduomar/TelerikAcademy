$(function () {
    $('#register-banner-form').submit(function (ev) {
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
                swal("Good job!", "You created a banner!", "success");
            },
            error: function () {
                debugger
                swal("Bad job!", "You did not create a banner!", "warning");
            }
        })
    });


    document.body.style.backgroundImage = "url('https://memeburn.com/gearburn/wp-content/uploads/sites/3/2017/01/xiaomi-mi-tv-4.jpg')";
    document.body.style.backgroundSize = "1400px 680px";

    $('#content').click(function (event){
        if (event.target.id == "content" || event.target.id == "wrap" || event.target.id == "cbody" || event.target.id == "someid") {
            window.open('https://memeburn.com/gearburn/2017/01/ces-2017-xiaomi-mi-tv-4/')
        }
        return
    });

})
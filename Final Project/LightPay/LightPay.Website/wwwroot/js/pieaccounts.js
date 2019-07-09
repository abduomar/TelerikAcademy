
$(function () {
    $.ajax({
        type: "GET",
        url: "/Account/GetAccounts",
        success: function (accounts) {
            console.log(accounts)
            createChart(accounts)
        },
    })



    function createChart(data) {

        $("#chart").kendoChart({
            title: {
                position: "top",
                text: "Accounts"
            },
            legend: {
                visible: true
            },
            chartArea: {
                background: ""
            },
            seriesDefaults: {
                labels: {
                    visible: true,
                    background: "transparent",
                    template: "#= category #: \n #= value #"
                }
            },
            series: [{
                type: "pie",
                startAngle: 150,
                data: data

        }],
            tooltip: {
                visible: true,
                format: "{0} BGN"
            }
        });
    }

})
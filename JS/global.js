function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "cajero.aspx/obtenerNum",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, throwError) {
            console.log(xhr.status + "\n" + xhr.responseText + "\n" + throwError);
        },
        success: function (data) {
            console.log(data.d);
        }
    });
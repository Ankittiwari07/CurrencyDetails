
function GetCurrencyList() {
    $.ajax({
        async: false,
        url: "../Currency/GetAllCurrency",
        type: 'GET',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        beforeSend: function () { // Before we send the request, remove the .hidden class from the spinner and default to inline-block.
        },
        success: function (data) {
            BindDataTable(data["data"]);
        },
        error: function (xhr, ajaxoptions, thrownError) {
            alert("Technical Error, Please try after sometimes!");
        },
        complete: function () { // Set our complete callback, adding the .hidden class and hiding the spinner.
        }
    });
}


function BindDataTable(data) {   // Provide the Currency List data to Datatable for binding,
    if ($.fn.dataTable.isDataTable('#tblCurrencyList')) {
        $('#tblCurrencyList').DataTable().clear().destroy();
    }
    table = $('#tblCurrencyList').DataTable({
        dom: 'Bfrtip',    //buttons for export the dataset into the selected formats.
        buttons: [
             'excelHtml5', 'pdfHtml5', 'csvHtml5'
        ],
        "searching": true,
        "paging": true,
        "ordering": true,
        "info": false,
        data: data,  //Bind the Source data to datacolumns
        "columns": [
            {
                "data": "country",
            },
            {
                "data": "currencyName"
            },
            {
                "data": "eur"
            },
            {
                "data": "btc"
            }
        ],
        "bDestroy": true
    });
}
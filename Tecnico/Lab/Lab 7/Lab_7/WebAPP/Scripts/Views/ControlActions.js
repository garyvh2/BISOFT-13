
function ControlActions() {

    this.URL_API = "http://localhost:61021/api/";

    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    };

    this.GetTableColumsDataName = function (tableId) {
        var val = $('#' + tableId).attr("ColumnsDataName");

        return val;
    };

    this.FillTable = function (service, tableId) {

        columns = this.GetTableColumsDataName(tableId).split(',');
        var arrayColumnsData = [];


        $.each(columns, function (index, value) {
            var obj = {};
            obj.data = value;
            arrayColumnsData.push(obj);
        });

        $('#' + tableId).DataTable({
            "processing": true,
            "ajax": {
                "url": this.GetUrlApiService(service),
                dataSrc: 'Data'
            },
            "columns": arrayColumnsData
        });
    };

    this.FillComboBox = function (service, tableId) {

    }
}

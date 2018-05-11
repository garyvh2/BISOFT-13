// >> Constructor
function ControlActions() {
    // >> Atributes
    this.URL_API = "http://localhost:54684/api/";
    this.methods = ['get', 'delete', 'put', 'post'];
}
// ====================================================================//
// >> Table Method
// ====================================================================//
ControlActions.prototype.GetTableColumsDataName = function (tableId) {
    var val = $('#' + tableId).attr("ColumnsDataName");
    return val;
};
ControlActions.prototype.GetSelectedRow = function () {
    var data = sessionStorage.getItem(tableId + '_selected');
    return data;
};
ControlActions.prototype.FillTable = function (service, tableId, refresh) {
    var _this = this;

    if (!refresh) {
        columns = _this.GetTableColumsDataName(tableId).split(',');
        var arrayColumnsData = [];


        $.each(columns, function (index, value) {
            var obj = {};
            obj.data = value;
            arrayColumnsData.push(obj);
        });
        $('#' + tableId).DataTable({
            processing: true,
            ajax: {
                url: _this.GetUrlApiService(service),
                dataSrc: 'Data'
            },
            columns: arrayColumnsData,
            rowReorder: {
                selector: 'td:nth-child(2)'
            },
            responsive: true
        });
    } else {
        //RECARGA LA TABLA
        $('#' + tableId).DataTable().ajax.reload();
    }

};
// ====================================================================//
// >> Helpers
// ====================================================================//
ControlActions.prototype.GetDataForm = function (formId) {
    var data = {};
    var _this = this;

    $('#' + formId + ' *').filter(':input').each(function (input) {
        var columnDataName = $(this).attr("ColumnDataName");
        var value = $(this).val();
        if (this.type === 'select-one') {
            value = value === "null" ? null : value;
        } else if (this.type === "select-multiple") {
            var MultipleSubId = $(this).attr("MultipleSubId");
            value = _.map(value, function (el) {
                var obj = {};
                obj[MultipleSubId] = el;
                return obj;
            });
        }
        if (value !== "") {
            data[columnDataName] = value;
        }
    });

    console.log(data);
    return data;
};
ControlActions.prototype.BindFields = function (data) {
    console.log(data);
    $('#' + this.form + ' *').filter(':input').each(function (input) {
        var columnDataName = $(this).attr("ColumnDataName");
        var value = data[columnDataName];
        switch (this.type) {
            case 'select-one':
                value = value === null ? "null" : value;
                break;
            case "select-multiple":
                var MultipleSubId = $(this).attr("MultipleSubId");
                value = _.map(value, function (el) {
                    return el[MultipleSubId];
                });
                break;
            case 'date':
                value = moment(data[columnDataName]).format('YYYY-MM-DD');
                break;
            case 'search':
                return;
        }
        $('#' + this.id).val(value);
        $('#' + this.id).trigger('keyup.iconpicker');
    });
};
ControlActions.prototype.ShowMessage = function (type, message) {
    if (type === 'E') {
        $("#alert_container").removeClass("alert alert-success alert-dismissable");
        $("#alert_container").addClass("alert alert-danger alert-dismissable");
        $("#alert_message").text(message);
    } else if (type === 'I') {
        $("#alert_container").removeClass("alert alert-danger alert-dismissable");
        $("#alert_container").addClass("alert alert-success alert-dismissable");
        $("#alert_message").text(message);
    }
    $('.alert').show();
};
// ====================================================================//
// >> API Methods
// ====================================================================//
ControlActions.prototype.GetUrlApiService = function (service) {
    var _this = this;
    return _this.URL_API + service;
};
// Run Wait For Response
ControlActions.prototype.APIRequest = function (method, service, data) {
    var _this = this;
    // >> Fill if empty
    method = _.isEmpty(method) ? "get" : method;
    // >> Abort if invalid
    if (!_.contains(_this.methods, method)) {
        console.error('Invalid Method');
        return;
    }
    // >> Return Promise
    return new Promise(function (resolve, reject) {
        var jqxhr = $[method](_this.GetUrlApiService(service), data, function (response) {
            resolve(response);
        }).fail(function (reason) {
            reject(reason);
        });
    });

};

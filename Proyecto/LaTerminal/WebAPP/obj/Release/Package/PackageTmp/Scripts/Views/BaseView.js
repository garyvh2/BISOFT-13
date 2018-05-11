// >> Constructor
var methods = ['get', 'delete', 'put', 'post'];
var BaseView = function () {
};
// >> Inherit prototype
BaseView.prototype = new ControlActions();
// >> Methods
BaseView.prototype.RetrieveAll = function () {
    this.FillTable(this.service, this.table, false);
};
BaseView.prototype.ReloadTable = function () {
    this.FillTable(this.service, this.table, true);
};
// >> CRUD Partials
_.each(methods, function (method) {
    BaseView.prototype[method] = function (data, promise) {
        var _this = this;
        if (_.isEmpty(_this.service)) {
            console.error('No Service Found');
            return;
        }
        
        // >> Pull Data From Form
        if (!_.isEmpty(_this.form)) {
            data = _this.GetDataForm(_this.form);
        }
        // >> Pull Data and refresh the 
        if (!_.isEmpty(_this.table) && !promise) {
            //Hace el post al create
            _this.APIRequest(method, _this.service, data)
                .then(function (response) {
                    _this.ShowMessage('I', response.Message);
                    //Refresca la tabla
                    _this.ReloadTable();
                })
                .catch(function (reason) {
                    var data = reason.responseJSON;
                    _this.ShowMessage('E', data.ExceptionMessage);
                    console.log(data);
                });
        } else {
            //Hace el post al create
            return _this.APIRequest(method, _this.service, data);
        }
    }
});
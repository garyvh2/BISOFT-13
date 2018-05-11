// >> Constructor
var EstacionamientoHandler = function (service, table, form) {
    this.table = table;
    this.form = form;
    this.service = service || "estacionamiento";;
}
// >> Inherit prototype
EstacionamientoHandler.prototype = new BaseView();
// >> Methods

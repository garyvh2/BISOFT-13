// >> Constructor
var ConfiguracionHandler = function (service, table, form) {
    this.table = table;
    this.form = form;
    this.service = service || "configuracion";;
    this.items = {};
}
// >> Inherit prototype
ConfiguracionHandler.prototype = new BaseView();
// >> Methods
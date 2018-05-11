// >> Constructor
var PermisoHandler = function (service, table, form) {
    this.table = table;
    this.form = form;
    this.service = service || "permiso";;
}
// >> Inherit prototype
PermisoHandler.prototype = new BaseView();
// >> Methods

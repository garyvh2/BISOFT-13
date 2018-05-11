// >> Constructor
var RolHandler = function (service, table, form) {
    this.table = table;
    this.form = form;
    this.service = service || "rol";;
}
// >> Inherit prototype
RolHandler.prototype = new BaseView();
// >> Methods

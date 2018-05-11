// >> Constructor
var SancionHandler = function (service, table, form) {
    this.table = table;
    this.form = form;
    this.service = service || "sancion";;
}
// >> Inherit prototype
SancionHandler.prototype = new BaseView();
// >> Methods

// >> Constructor
var QuejaHandler = function (service, table, form) {
    this.table = table;
    this.form = form;
    this.service = service;
}
// >> Inherit prototype
QuejaHandler.prototype = new BaseView();
// >> Methods

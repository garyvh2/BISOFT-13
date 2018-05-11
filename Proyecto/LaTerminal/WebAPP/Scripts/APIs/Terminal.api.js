// >> Constructor
var TerminalHandler = function (service, table, form) {
    this.table = table;
    this.form = form;
    this.service = service || "terminal";
}
// >> Inherit prototype
TerminalHandler.prototype = new BaseView();
// >> Methods

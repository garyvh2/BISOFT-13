// >> Constructor
var TarjetaHandler = function (service, table, form) {
    this.table = table;
    this.form = form;
    this.service = service || "tarjeta";
}
// >> Inherit prototype
TarjetaHandler.prototype = new BaseView();
// >> Methods
TarjetaHandler.prototype.Activate = function (data) {
    this.service = "tarjeta/activate";

    //Hace el post al create
    return this.post({
        Codigo: data.Codigo,
        Id_Usuario: data.Id_Usuario
    }, true);
}
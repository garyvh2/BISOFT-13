// >> Constructor
var UsuarioHandler = function (service, table, form) {
    this.table = table;
    this.form = form;
    this.service = service || "usuario";
}
// >> Inherit prototype
UsuarioHandler.prototype = new BaseView();
// >> Methods
UsuarioHandler.prototype.IniciarSession = function (data) {
    this.URL_API = "http://localhost:56552/api/";
    this.service = "usuario/login";

    //Hace el post al create
    return this.post({
        Correo: data.email,
        Clave: data.password
    }, true);
}
UsuarioHandler.prototype.CerrarSession = function (data) {
    this.URL_API = "http://localhost:56552/api/";
    this.service = "usuario/logout";

    //Hace el post al create
    return this.post({}, true);
}
UsuarioHandler.prototype.RecuperarClave = function (data) {
    this.service = "usuario/recover";

    //Hace el post al create
    return this.post({
        Correo: data.email
    }, true);
}
window.UsuarioHandler = UsuarioHandler;
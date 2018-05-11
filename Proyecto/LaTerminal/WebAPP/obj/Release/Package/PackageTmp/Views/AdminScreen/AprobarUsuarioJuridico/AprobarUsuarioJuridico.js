//ON DOCUMENT READY
$(document).ready(function () {
    window.UsuarioHandler = new ltl.Table('tblUsuarios', 'usuario/rol/JURIDICO', 'formUsuarios');
    UsuarioHandler.form.service = 'usuario';
});
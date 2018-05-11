//ON DOCUMENT READY
$(document).ready(function () {
    window.TransaccionHandler = new ltl.Table('tblTransaccion', 'transaccion/usuario', null, {
        include_session: true,
        disable_delete: true
    });
});
//ON DOCUMENT READY
$(document).ready(function () {
    window.SancionHandler = new ltl.Table('tblSanciones', 'sancion', 'formSanciones');


    $('#Id_Empresa_Bus').on('link_action', function (ev, userId) {
        ltl.api.get('empresa_bus', userId, true, function (err, res) {
            if (err || !res.Data) {
                ltl.Error(err || res);
                return;
            }

            var obj = _.pick(res.Data, "CEDULA_JUR", "NOMBRE", "TELEFONO", "CORREO");

            var html = "<table class='table table-bordered display responsive'><tbody>";

            _.each(obj, function (value, index) {
                html += `<tr><td>${ltl.NiceName(index)}</td><td>${value}</td></tr>`
            });
            html += "</tbody></table>"
            html = html.replace(/Name/g, "");

            swal({
                title: 'Consultar Empresa de Bus',
                html: html,
                showCancelButton: true,
                showConfirmButton: false,
                customClass: "left_text",
                cancelButtonText: 'Cerrar'
            });
        });
    });

});
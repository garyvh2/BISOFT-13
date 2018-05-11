//ON DOCUMENT READY
$(document).ready(function () {
    window.BusHandler = new ltl.Table('tblBuses', 'Bus', 'formBuses');

    $('#ID_CHOFER').on('link_action', function (ev, userId) {
        ltl.api.get('usuario', userId, true, function (err, res) {
            if (err || !res.Data) {
                ltl.Error(err || res);
                return;
            }
            var usuario = _.pick(res.Data, "Identificacion", "Nombre_Completo", "Rol_Name", "Genero", "Telefono", "Correo", "Empresa_Bus_Name", "Terminal_Name");

            var html = "<table class='table table-bordered display responsive'><tbody>";

            _.each(usuario, function (value, index) {
                html += `<tr><td>${ltl.NiceName(index)}</td><td>${value}</td></tr>`
            });
            html += "</tbody></table>"
            html = html.replace(/Name/g, "");

            swal({
                title: 'Consultar chofer',
                html: html,
                showCancelButton: true,
                showConfirmButton: false,
                customClass: "left_text",
                cancelButtonText: 'Cerrar'
            });
        });
    });

    $('#ID_EMPRESA_BUS').on('link_action', function (ev, userId) {
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
                title: 'Consultar empresa de bus',
                html: html,
                showCancelButton: true,
                showConfirmButton: false,
                customClass: "left_text",
                cancelButtonText: 'Cerrar'
            });
        });
    });

    $('#ID_CHOFER').on('link_create', function () {
        swal({
            title: 'Crear un chofer',
            html: $('#CrearChofer').html(),
            showCancelButton: true,
            showConfirmButton: false,
            customClass: "left_text",
            cancelButtonText: 'Cancelar',
            onOpen: function () {
                window.UsuarioHandler = new ltl.Form('CrearChoferForm', 'usuario');

                $('#CrearChoferBtn').click(function () {
                    UsuarioHandler.post()
                })

                UsuarioHandler.form.on('smt_success', function (ev, data) {
                    var value = data.Identificacion;
                    var text = data.Nombre_Completo + "(" + value + ")";

                    var option = new Option(text, value, true, true);

                    $('#ID_CHOFER').trigger('add-link', [option]);
                });
            }
        });
    });



});


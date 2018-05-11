//ON DOCUMENT READY
$(document).ready(function () {
    window.UsuarioHandler = new ltl.Table('tblUsuarios', 'usuario/terminal_empresa', 'formUsuarios', {
        include_session: true
    });
    UsuarioHandler.form.service = 'usuario';
    

    $('#Id_Rol').on('link_action', function (ev, userId) {
        ltl.api.get('rol', userId, true, function (err, res) {
            if (err || !res.Data) {
                ltl.Error(err || res);
                return;
            }

            var html = "<table class='table table-bordered display responsive'><tbody>";

            _.each(res.Data, function (value, index) {
                if (index == 'Permisos') {
                    value = _.pluck(value, 'Nombre').join("<br>")
                }
                html += `<tr><td>${ltl.NiceName(index)}</td><td>${value}</td></tr>`
            });
            html += "</tbody></table>"
            html = html.replace(/Name/g, "");

            swal({
                title: 'Consultar rol',
                html: html,
                showCancelButton: true,
                showConfirmButton: false,
                customClass: "left_text",
                cancelButtonText: 'Cerrar'
            });
        });
    });

    $('#Id_Rol').on('link_create', function () {
        swal({
            title: 'Crear un rol',
            html: $('#CrearRol').html(),
            showCancelButton: true,
            showConfirmButton: false,
            customClass: "left_text",
            cancelButtonText: 'Cancelar',
            onOpen: function () {
                window.UsuarioHandler = new ltl.Form('CrearRolForm', 'rol');

                $('#CrearRolBtn').click(function () {
                    UsuarioHandler.post()
                })

                UsuarioHandler.form.on('smt_success', function (ev, data) {
                    var value = data.Id;
                    var text = data.Nombre;

                    var option = new Option(text, value, true, true);

                    $('#Id_Rol').trigger('add-link', [option]);
                });
            }
        });
    });

});
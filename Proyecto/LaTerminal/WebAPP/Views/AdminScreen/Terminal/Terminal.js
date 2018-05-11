//ON DOCUMENT READY
$(document).ready(function () {
    window.TerminalHandler = new ltl.Table('tblTerminales', 'terminal', 'formTerminales');

    $('#Id_Usuario').on('link_action', function (ev, userId) {
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
                title: 'Consultar encargado',
                html: html,
                showCancelButton: true,
                showConfirmButton: false,
                customClass: "left_text",
                cancelButtonText: 'Cerrar'
            });
        });
    });

    $('#Id_Usuario').on('link_create', function () {
        swal({
            title: 'Crear un encargado',
            html: $('#CrearEncargado').html(),
            showCancelButton: true,
            showConfirmButton: false,
            customClass: "left_text",
            cancelButtonText: 'Cancelar',
            onOpen: function () {
                window.UsuarioHandler = new ltl.Form('CrearEncargadoForm', 'usuario');

                $('#CrearEncargadoBtn').click(function () {
                    UsuarioHandler.post()
                })

                UsuarioHandler.form.on('smt_success', function (ev, data) {
                    var value = data.Identificacion;
                    var text = data.Nombre_Completo + "(" + value + ")";

                    var option = new Option(text, value, true, true);

                    $('#Id_Usuario').trigger('add-link', [option]);
                });
            }
        });
    });

    window.GoogleMap = new ltl.Maps('map');
    GoogleMap.map.on('drop_marker', function (ev, el) {
        $('#LAT').val(el.getPosition().lat());
        $('#LONG').val(el.getPosition().lng());
    })

    $('#LAT, #LONG').on('change', function () {
        var location = {
            lat: parseFloat($('#LAT').val()),
            lng: parseFloat($('#LONG').val())
        }

        GoogleMap.RemoveMarkers();
        GoogleMap.AddMarker(location,
            {
                draggable: true
            });
        GoogleMap.Center(location);
    })
});
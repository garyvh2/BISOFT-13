$(document).ready(function () {
    $('#edit_user_photo').on('click', function (ev) {
        swal({
            title: 'Actualizar foto de perfil',
            html: $('#pictureUpload').html(),
            customClass: "left_text",
            onOpen: function () {
                ltl.ImageUploader(ltl.Session('Identificacion'));
            }
        });
    });
    // >> Form Usuario
    window.UsuarioForm = new ltl.Form('actualizarPerfil', 'usuario');
    UsuarioForm.SetData(ltl.Session());
    $(window).on('refresh_session', function () {
        UsuarioForm.SetData(ltl.Session());


        var randomId = new Date().getTime();
        var photo = ltl.api.root + "image/user/" + ltl.Session('Identificacion') + "?uuid=" + randomId;

        swal.close();
        $('#edit_user_photo, #user_photo').css({
            "background-image": `url(${photo})`
        })
    })
    // >> Form Clave
    window.ClaveForm = new ltl.Form('actualizarClave', 'usuario');
    ClaveForm.form.on('smt_success', function () {
        ltl.Session.Refresh();
    });
});


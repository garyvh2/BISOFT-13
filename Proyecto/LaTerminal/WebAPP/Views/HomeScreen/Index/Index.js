var config = {};
// >> Get JSON Configuration
ltl.loadJson('./Views/HomeScreen/Index/Index.json', function (err, doc) {
    if (err) console.log(err);
    else config = doc;
});

$(document).ready(function () {
    //=============================================================//
    //
    //                   === Inicializar Mapa ===
    //
    //=============================================================//
    // >> Init Map
    var initMap = function () {
        var custom_theme = new google.maps.StyledMapType(config.maps_theme, { name: 'Custom Map' });
        var map = new google.maps.Map(document.getElementById('hs-map'), {
            center: { lat: 9.93278, lng: -84.0781826 },
            zoom: 14,
            disableDefaultUI: true
        });
        map.mapTypes.set('custom_map', custom_theme);
        map.setMapTypeId('custom_map');
    };
    initMap();
    //=============================================================//
    //
    //                   === Metodos Visuales ===
    //
    //=============================================================//
    // =============== Show the ScrollToTop bottom =============== //
    var navBottom = $(window).height();
    // >> Display Button
    var scrollTopTop = function () {
        var scrollBottom = $(document).scrollTop();
        if (scrollBottom > navBottom) {
            $('#hs-back').addClass('hs-display');
        } else {
            $('#hs-back').removeClass('hs-display');
        }
    };
    // >> Check on loading and scroll if the button should be shown
    scrollTopTop();
    $(window).scroll(function () {
        scrollTopTop();
    });
    // >> When clicking on the button scroll to top
    $('#hs-back').click(function () {
        var body = $("html, body");
        body.stop().animate({ scrollTop: 0 }, 500, 'swing', function () {
        });
    });

    // ===================== Modify Viewports ===================== //
    // Store the window size
    var viewheight = $(window).height();
    var viewwidth = $(window).width();
    // Recalculate the viewport values
    var addJustMetaViewPorts = function (vh, vw) {
        setTimeout(function () {
            var viewport = $("meta[name=viewport]");
            viewport.attr("content", "viewport-fit=cover, height=" + vh + "px, width=" + vw + "px, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no");
        }, 300);
    };
    // >> Calculate the view height and width on load, orientationchange and resize
    addJustMetaViewPorts(viewheight, viewwidth);
    // Trigger on orientation change or resize
    $(window).on("orientationchange resize", function (ev) {
        if (ev.handleObj.type === 'resize') {
            viewheight = $(window).height();
            viewwidth = $(window).width();
        }
        if (window.matchMedia("(orientation: portrait)").matches)
            addJustMetaViewPorts(viewwidth, viewheight);
        else
            addJustMetaViewPorts(viewheight, viewwidth);
    });

    //=============================================================//
    //
    //                   === Metodos De Modals ===
    //
    //=============================================================//
    // ================ Seleccionar entidad juridica ============= //
    $("#entidadesJuridicas").click(function (ev) {
        swal({
            title: 'Tipo de entidad',
            type: 'question',
            customClass: 'left_text',
            html:
            `<p>Por favor, escoja un tipo de entidad juridica</p>
            <hr>
            <p><b>• Empresa de bus:</b> Nos encantaria que formaras parte de nuestro sistema</p>
            <p><b>• Convenio Empresarial:</b> ¿Representas una escuela o una empresa turistica? Nuestra empresa ofrece la facilidad de convenios con diversos beneficios.</p>
            <hr>
            <button id="CrearEmpresa" name="tipoEntidad" class='btn btn-custom' value="empresaBus"><i class='fas fa-bus'></i> Empresa de bus</button>
            <button id="CrearConvenio" name="tipoEntidad" class='btn btn-custom' value="convenio"><i class='fas fa-tags'></i> Convenio Empresarial</button>`,
            showCloseButton: true,
            showCancelButton: false,
            showConfirmButton: false,
            onOpen: function () {
                $('#CrearConvenio').click(CrearConvenio);
            }
        });
    });
    // >> Proseguir con las opciones respectivas
    var CrearConvenio = function (ev) {
        swal({
            title: 'Convenio jurídico',
            html: $('#UsuarioJuridicoTemplate').html(),
            showCancelButton: true,
            customClass: "left_text",
            confirmButtonText: 'Enviar',
            cancelButtonText: 'Cancelar',
            onOpen: function () {
                window.FormUsuarioJuridico = new ltl.Form('UsuarioJuridico', 'usuario')
            },
            preConfirm: function () {
                return new Promise(function (resolve, reject) {
                    FormUsuarioJuridico.form.on('smt_success', function (ev, data) {
                        ltl.Info('La solicitud ha sido enviada. Debe esperar aprobación');
                        resolve(data);
                    });
                    FormUsuarioJuridico.form.on('form_error', function (ev) {
                        swal.showValidationError(`El formulario posee errores`);
                        resolve();
                    });
                    FormUsuarioJuridico.post(null, false, true);
                });
            },
            allowOutsideClick: function () {
                !swal.isLoading();
            }
        })
    }
    // ===================== Iniciar Session ===================== //
    $('#iniciarSession').click(function (ev) {
        swal({
            title: 'Iniciar sesión',
            html: $('#iniciarSessionTemplate').html(),
            showCancelButton: true,
            customClass: "left_text",
            confirmButtonText: 'Enviar',
            cancelButtonText: 'Cancelar',
            onOpen: function () {
                $('#recuperarClave').click(function (ev) {
                    recuperarClave();
                });
            },
            preConfirm: function () {
                return new Promise(function (resolve, reject) {
                    $("form[name='iniciarSession']").validate({
                        rules: {
                            email: {
                                required: true,
                                email: true,
                                normalizer: function (value) {
                                    return $.trim(value);
                                }
                            },
                            password: {
                                required: true,
                                rangelength: [8, 16]
                            }
                        },
                        messages: {
                            email: {
                                required: "Por favor especifique un correo electrónico",
                                email: "El valor de correo electronico debe seguir el formato 'name@domain.com'"
                            },
                            password: {
                                required: "Por favor especifique una contraseña",
                                rangelength: "Su contraseña debe ser de 8 a 16 caracteres"
                            }
                        }
                    });

                    if ($("form[name='iniciarSession']").valid()) {
                        swal.resetValidationError();
                        // >> Capturar Valores
                        var email = $('#email').val();
                        var password = $('#password').val();

                        resolve({
                            formData: {
                                email: email,
                                password: password
                            }
                        });
                    } else {
                        swal.showValidationError(`El formulario posee errores`);
                        resolve();
                    }
                });
            },
            allowOutsideClick: function () {
                !swal.isLoading();
            }
        }).then(function (result) {
            if (result.value && result.value.formData) {
                var data = result.value.formData;
                swal({
                    title: 'Iniciando sesión',
                    text: 'Por favor espere',
                    onOpen: function () {
                        swal.showLoading();
                    },
                    allowOutsideClick: function () {
                        !swal.isLoading();
                    }
                });
                var usuario = new UsuarioHandler();
                ltl.Session.Login(data, function (err, data) {
                    if (err) {
                        swal.close();
                        swal({
                            type: 'error',
                            title: 'Ha sucedido un error con la solicitud',
                            text: reason.responseJSON && reason.responseJSON.ExceptionMessage || reason.message || ""
                        });
                        return;
                    }

                    var userData = data;
                    delete userData.Foto;
                    if (userData.First_Time) {
                        swal.setDefaults({
                            progressSteps: ['1', '2', '3']
                        });
                        var steps = [
                            {
                                title: 'Actualizar perfil',
                                html: $('#actualizarPerfilTemplate').html(),
                                showCancelButton: true,
                                customClass: "left_text",
                                confirmButtonText: 'Siguiente &rarr;',
                                cancelButtonText: 'Cancelar',
                                preConfirm: function () {
                                    return new Promise(function (resolve, reject) {
                                        $("form[name='actualizarPerfil']").validate({
                                            rules: {
                                                PNombre: {
                                                    required: true,
                                                    normalizer: function (value) {
                                                        return $.trim(value);
                                                    }
                                                },
                                                PApellido: {
                                                    required: true,
                                                    normalizer: function (value) {
                                                        return $.trim(value);
                                                    }
                                                },
                                                Genero: {
                                                    required: true
                                                },
                                                Fecha_Nac: {
                                                    required: true
                                                },
                                                Telefono: {
                                                    required: true
                                                },
                                                Direccion: {
                                                    required: true
                                                },
                                                Clave: {
                                                    required: true,
                                                    rangelength: [8, 16]
                                                },
                                                Clave_Rep: {
                                                    equalTo: "#Clave"
                                                }
                                            },
                                            messages: {
                                                PNombre: {
                                                    required: "Por favor especifique su primer nombre"
                                                },
                                                PApellido: {
                                                    required: "Por favor especifique su primer apellido"
                                                },
                                                Genero: {
                                                    required: "Por favor especifique un genero"
                                                },
                                                Fecha_Nac: {
                                                    required: "Por favor especifique una fecha de nacimiento"
                                                },
                                                Telefono: {
                                                    required: "Por favor especifique un numero telefonico"
                                                },
                                                Direccion: {
                                                    required: "Por favor especifique una direccion"
                                                },
                                                Clave: {
                                                    required: "Por favor especifique una contraseña",
                                                    rangelength: "Su contraseña debe ser de 8 a 16 caracteres"
                                                },
                                                Clave_Rep: {
                                                    equalTo: "Las contraseñas no coinciden"
                                                }
                                            }
                                        });

                                        if ($("form[name='actualizarPerfil']").valid()) {
                                            swal.resetValidationError();
                                            // >> Capturar Valores
                                            var data = usuario.GetDataForm("actualizarPerfil");
                                            data.Genero = $("#Genero").val();
                                            data.Direccion = $("#Direccion").val();

                                            resolve({
                                                formData: data
                                            });
                                        } else {
                                            swal.showValidationError(`El formulario posee errores`);
                                            resolve();
                                        }
                                    });
                                },
                                allowOutsideClick: function () {
                                    !swal.isLoading();
                                }
                            },
                            {
                                title: 'Subir una foto de perfil',
                                html: $('#pictureUpload').html(),
                                showCancelButton: true,
                                customClass: "left_text",
                                confirmButtonText: 'Siguiente &rarr;',
                                cancelButtonText: 'Cancelar',
                                onOpen: function () {
                                    ltl.ImageUploader(userData.Identificacion);
                                }
                            },
                            {
                                title: 'Active su tarjetas',
                                html: $('#activarTarjeta').html(),
                                showCancelButton: true,
                                customClass: "left_text",
                                confirmButtonText: 'Completar',
                                cancelButtonText: 'Cancelar',
                                onOpen: function () {
                                    ltl.CardActivator(userData.Identificacion);
                                }
                            }
                        ];
                        swal.queue(steps).then((result) => {
                            swal.resetDefaults();

                            if (result.value) {
                                var updateData = result.value[0].formData;
                                updateData = _.extend(userData, updateData);
                                updateData.First_Time = false;
                                actualizarUsuario(updateData);
                            }
                        });
                    } else {
                        // Ingresar
                        swal.close();
                        ltl.go.home();
                    }
                });
            }
        }).catch(function (reason) {
            swal.close();
            swal({
                type: 'error',
                title: 'Ha sucedido un error con la solicitud',
                text: reason.responseJSON && reason.responseJSON.ExceptionMessage || reason.message || ""
            });
        });
    });

    $(document).on('submit-card', function (ev, IdUsuario) {
        ev.preventDefault();
        try {
            var tarjeta = new TarjetaHandler();
            tarjeta.Activate({
                Id_Usuario: IdUsuario,
                Codigo: $('#cardId').val()
            }).then(function (result) {
                $(window).trigger('accept-card');
                swal.resetValidationError();
            }).catch(function (reason) {
                $(window).trigger('reject-card');
                swal.showValidationError(reason.responseJSON && reason.responseJSON.ExceptionMessage || `Ha sucedido un problem al activar la tarjeta`);
            });
        } catch (ex) {
            console.error(ex);
            swal.showValidationError(`Ha sucedido un problema al activar la tarjeta`);
            $(window).trigger('reject-card');
        }
        return false;
    });


    var recuperarClave = function () {
        swal.close();
        swal({
            title: 'Recuperar contraseña',
            text: "Ingrese su correo electronico para recibir una contraseña temporal.",
            input: 'email',
            inputPlaceholder: 'Correo electrónico',
            showCancelButton: true,
            confirmButtonText: 'Enviar',
            showLoaderOnConfirm: true,
            preConfirm: function (email) {
                return new Promise(function (resolve, reject) {
                    ltl.api.post('usuario/recover', {
                        Correo: email
                    }, true, function (err, res) {
                        if (err || !res) {
                            reject(err);
                        } else {
                            resolve(res);
                        }
                    });
                });
            },
            allowOutsideClick: function () {
                !swal.isLoading();
            }
        }).then(function (result) {
            ltl.Info(result.value);
        }).catch(function (reason) {
            ltl.Error(reason);
        });
    };

    var actualizarUsuario = function (updateData) {
        var usuario = new UsuarioHandler();
        usuario.put(updateData)
            .then(function (result) {
                // Ingresar
                ltl.Session.Refresh();
                $(window).on('refresh_session', function () {
                    ltl.go.home();
                })
            }).catch(function (reason) {
                swal({
                    type: 'error',
                    title: 'Ha sucedido un error con la solicitud',
                    text: reason.responseJSON && reason.responseJSON.ExceptionMessage || ""
                });
            });
    };
});
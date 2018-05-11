(function (w, d, u) {
    var alias = "ltl";
    var core = function () {

    };
    core.CardActivator = function (IdUsuario) {
        if (!$('.card-activator')[0]) {
            console.warn('Cannot Find .card-activator');
            return;
        }

        var regex = /[A-z0-9]{8}-([A-z0-9]{4}-){3}[A-z0-9]{12}/g;
        var Usuario = IdUsuario;


        $("#cardId").on("keyup", function (event) {
            $('.fa-credit-card').css({
                color: "#cbcbcb"
            });
            $('.submit-state').css({
                display: "none"
            });


            var selection = window.getSelection().toString();
            if (selection !== '') {
                return;
            }
            if ($.inArray(event.keyCode, [38, 40, 37, 39]) !== -1) {
                return;
            }

            var value = $(this).val();

            var valid = value.match(regex);
            if (!valid) {
                $("#valid-state").css({
                    background: "#F27474",
                    "border-color": "#FFA0A0"
                });
                $("#valid-state i").css({
                    color: "#AC2727"
                }).attr("class", "fas fa-times");
                $('#submitCard').attr('disabled', 'disabled');
            } else {
                $("#valid-state").css({
                    background: "#6EDD57",
                    "border-color": "#6EDD57"
                });
                $("#valid-state i").css({
                    color: "#167C00"
                }).attr("class", "fas fa-check");
                $('#submitCard').removeAttr('disabled');
            }
        });
        $('#submitCard').click(function (ev) {
            ev.preventDefault();
            $('.card-box i.fa-circle-notch').css({
                display: "table-cell"
            });
            $('.card-box i.fa-credit-card').css({
                display: "none"
            });
            $('#submitCard').attr('disabled', 'disabled');
            $('#submitCard').trigger('submit-card', [Usuario]);
            return false;
        });

        $(window).on('reject-card', function () {
            $('.card-box i.fa-circle-notch').css({
                display: "none"
            });
            $('.card-box i.fa-credit-card').css({
                display: "table-cell"
            });
            $('.fa-credit-card').css({
                color: "#F27474"
            });
            $('.submit-state').css({
                display: "block",
                color: "#AC2727"
            }).attr('class', 'submit-state fas fa-times-circle fa-4x');
        });

        $(window).on('accept-card', function () {
            $('.card-box i.fa-circle-notch').css({
                display: "none"
            });
            $('.card-box i.fa-credit-card').css({
                display: "table-cell"
            });
            $('.fa-credit-card').css({
                color: "#6EDD57"
            });
            $('.submit-state').css({
                display: "block",
                color: "#167C00"
            }).attr('class', 'submit-state fas fa-check-circle fa-4x');
        });
    };
    core.ImageUploader = function (id) {
        if (!$('#fileupload')[0]) {
            console.warn('Cannot Find #fileupload');
            return;
        }

        var url = 'http://localhost:54684/api/image/user/',
            uploadButton = $('<button/>')
                .addClass('btn btn-primary')
                .prop('disabled', true)
                .text('Procesando...')
                .on('click', function () {
                    var $this = $(this),
                        data = $this.data();
                    $this
                        .off('click')
                        .text('Cancelar')
                        .on('click', function () {
                            $this.remove();
                            data.abort();
                        });
                    
                    data.submit().always(function () {
                        $this.remove();
                    });
                });
        $('#fileupload').fileupload({
            url: url,
            dataType: 'json',
            autoUpload: false,
            formData: {
                id: id
            },
            acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i,
            maxFileSize: 999000,
            // Enable image resizing, except for Android and Opera,
            // which actually support image resizing, but fail to
            // send Blob objects via XHR requests:
            disableImageResize: /Android(?!.*Chrome)|Opera/
                .test(window.navigator.userAgent),
            previewMaxWidth: 100,
            previewMaxHeight: 100,
            previewCrop: true
        }).on('fileuploadadd', function (e, data) {
            $('#files').empty();
            data.context = $('<div/>').appendTo('#files');
            $.each(data.files, function (index, file) {
                var node = $('<p/>')
                    .append($('<span/>').text(file.name));
                if (!index) {
                    node
                        .append('<br>')
                        .append(uploadButton.clone(true).data(data));
                }
                node.appendTo(data.context);
            });
        }).on('fileuploadprocessalways', function (e, data) {
            var index = data.index,
                file = data.files[index],
                node = $(data.context.children()[index]);
            if (file.preview) {
                node
                    .prepend('<br>')
                    .prepend(file.preview);
            }
            if (file.error) {
                node
                    .append('<br>')
                    .append($('<span class="text-danger"/>').text(file.error));
            }
            if (index + 1 === data.files.length) {
                data.context.find('button')
                    .text('Subir')
                    .prop('disabled', !!data.files.error);
            }
        }).on('fileuploadprogressall', function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#progress .progress-bar').css(
                'width',
                progress + '%'
            );
        }).on('fileuploaddone', function (e, data) {
            $.each(data.result.files, function (index, file) {
                if (file.url) {
                    var link = $('<a>')
                        .attr('target', '_blank')
                        .prop('href', file.url);
                    $(data.context.children()[index])
                        .wrap(link);
                } else if (file.error) {
                    var error = $('<span class="text-danger"/>').text(file.error);
                    $(data.context.children()[index])
                        .append('<br>')
                        .append(error);
                }
            });
        }).on('fileuploadfail', function (e, data) {
            $('#progress .progress-bar').css(
                'width', "0%"
            );
            $.each(data.files, function (index) {
                var error = $('<span class="text-danger"/>').text('File upload failed.');
                $(data.context.children()[index])
                    .append('<br>')
                    .append(error);
            });
        }).prop('disabled', !$.support.fileInput)
            .parent().addClass($.support.fileInput ? undefined : 'disabled');
    };
    core.loadJson = function (path, cb) {
        $
            .getJSON(path, function (doc) {
                return cb(null, doc);
            })
            .fail(function () {
                return cb('Unable To Load View Properties');
            });
    };
    core.session = function (value) {
        if (typeof value === "object")
            sessionStorage.setItem('user_session', JSON.stringify(value));
        else if (typeof value === "string")
            return JSON.parse(sessionStorage.getItem('user_session'))[value];
        else
            return JSON.parse(sessionStorage.getItem('user_session'));
    };
    core.session.destroy = function () {
        sessionStorage.clear();

        $.post("http://localhost:56552/api/usuario/logout", {}, function (response) {
            console.log('[Cerrar Session] - Regresando al menu principal');
        }).fail(function (reason) {
            console.log('[Cerrar Session] - Ocurrio un problema cerrando la session', reason);
        });

    };
    core.go = function (sections, data) {
        var url = "/";
        _.each(sections, function (section) {
            url += section + "/";
        });
        url += data || "";
        window.location.href = url;
    };
    core.conf = function (value) {
        if (typeof value === "object") {
            sessionStorage.setItem('configuration', JSON.stringify(value));
        } else if (typeof value === "string") {
            var items = JSON.parse(sessionStorage.getItem('configuration'));
            var res = _.findWhere(items, function (item) {
                return item.Codigo = value;
            });


            try {
                value = JSON.parse(res.Valor);
            } catch (ex) {
                console.warn('Item is Text', ex);
                value = res.Valor;
            }
            return value;
        } else {
            return JSON.parse(sessionStorage.getItem('configuration'));
        }
    };
    w[alias] = core;
})(window, document);
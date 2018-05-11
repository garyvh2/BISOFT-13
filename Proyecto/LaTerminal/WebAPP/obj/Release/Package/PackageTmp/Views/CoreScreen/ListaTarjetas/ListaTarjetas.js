//ON DOCUMENT READY
$(document).ready(function () {
    // >> Inicializar Form de compra
    window.Recargar = function (codigo) {
        var payments;
        swal({
            title: 'Proceso de recarga de tarjetas',
            html: $('#pago').html(),
            showCancelButton: true,
            showConfirmButton: false,
            customClass: "left_text",
            cancelButtonText: 'Cancelar',
            onOpen: function () {
                $('#Codigo').val(codigo);

                window.RecargarTarjetaForm = new ltl.Form('RecargarTarjetaForm');
                payments = new ltl.Payments('RecargarTarjetaForm', 'payments/pay/recarga');
                payments.Init();

                payments.dropin.on('payment_success', function () {
                    var $this = $('#' + codigo + " #entry_saldo");
                    var formData = RecargarTarjetaForm.GetData();
                    var Saldo = parseInt($this.html());
                    $this.html(parseInt(formData.Saldo) + Saldo);
                });

            }
        });

    };

});
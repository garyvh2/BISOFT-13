//ON DOCUMENT READY
$(document).ready(function () {
    // >> Establecer el valor minimo
    var TARJETA_MINIMO = ltl.Conf('TARJETA_MINIMO')
    //$('#Monto').attr('min', TARJETA_MINIMO).val(TARJETA_MINIMO);


    window.ComprarTarjetaForm = new ltl.Form('ComprarTarjetaForm');

    // >> Inicializar Form de compra
    $('#comprar').click(function (ev) {
        if (!ComprarTarjetaForm.Validate()) {
            return;
        }

        var payments;
        swal({
            title: 'Proceso de pago de tarjetas',
            html: $('#pago').html(),
            showCancelButton: true,
            showConfirmButton: false,
            customClass: "left_text",
            cancelButtonText: 'Cancelar',
            onOpen: function () {
                payments = new ltl.Payments('ComprarTarjetaForm', 'payments/pay/tarjeta');
                payments.Init();
            }
        })
    })

});
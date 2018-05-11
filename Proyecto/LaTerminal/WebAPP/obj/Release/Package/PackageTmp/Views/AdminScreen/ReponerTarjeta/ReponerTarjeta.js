//ON DOCUMENT READY
$(document).ready(function () {
    var TARJETA_MINIMO = ltl.Conf('TARJETA_MINIMO')
    $('#Saldo').attr('min', TARJETA_MINIMO).val(TARJETA_MINIMO);

    window.TarjetaHandler = new TarjetaHandler('tarjeta', 'tblTarjetas', 'formTarjetas');
    TarjetaHandler.RetrieveAll();
});


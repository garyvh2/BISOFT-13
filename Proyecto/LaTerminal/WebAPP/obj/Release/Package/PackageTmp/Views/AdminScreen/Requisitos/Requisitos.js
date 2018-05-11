//ON DOCUMENT READY
$(document).ready(function () {
    window.RequisitoHandler = new ltl.Table('tblRequisito', 'Requisitos', 'formRequisito');
});

var datos = function () {
    var dato = $('#formRequisito').data();
    asignar(dato);
}

var asignar = function (dato) {

    ltl.api.post('RequisitoBus', dato, true, function (err, res) {
        if (err || !res.Data) {
            ltl.Error(err || res);
            return;
        } else {
            ltl.Info(res);
            _this.form.trigger('smt_success', [res.Data]);
        }

    });
}
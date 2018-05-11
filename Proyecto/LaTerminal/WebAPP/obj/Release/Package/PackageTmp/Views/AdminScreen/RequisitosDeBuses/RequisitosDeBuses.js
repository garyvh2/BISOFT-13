////ON DOCUMENT READY
$(document).ready(function () {
    window.RequisitoHandler = new ltl.Table('tblRequisito', 'RequisitoBus', 'formRequisito');
});

//var asignar = function () {
//    this.service = "RequisitoBus/post";
//    var data = this.GetDataForm(this.form);
//    return this.post(data);
//}

//var Listar = function () {
//    cargarTabla();
//}

////ajax.data = function () {
////    return JSON.stringify(ltl.Session());
////}
////ajax.contentType = "application/json";
////ajax.type = 'POST';

//var cargarTabla = function () {
//    var ID_BUS = document.querySelector('#NUMERO_PLACA').value;
//    var table = $('#tblRequisitos').DataTable({
//        processing: true,
//        ajax: {
//            data: JSON.stringify(ID_BUS),
//            contentType: 'application/json',
//            type : 'POST',
//            url: 'http://localhost:54684/api/RequisitosBus',
//            dataSrc: 'Data',
//        },
//        columns: [
//            {
//                "defaultContent": "<input type='button' class='agregar' value='Agregar'><input type='button' class='quitar' value='Quitar'>"
//            },
//            { "data": "ID" },
//            { "data": "ID_REQUISITO" },
//            { "data": "ESTADO" }
//        ],
//        rowReorder: {
//            selector: 'td:nth-child(2)'
//        },
//        responsive: true
//    });
//    lista_requisitos("#tblRequisitos tbody", table);
//    activar("#tblRequisitos tbody", table);
//    desacivar("#tblRequisitos tbody", table);
//}

//var activar = function (tbody, table) { 

//    $(tbody).on("click", "input.agregar", function () {

//        var data = table.row($(this).parents("tr")).data();

//        ltl.api.post('RequisitoBus/ActivarEstadoRequisito', data, true, function (err, res) {
//            if (err || !res.Data) {
//                ltl.Error(err || res);
//                return;
//            } else {
//                ltl.Info(res);
//                _this.form.trigger('smt_success', [res.Data]);
//            }

//        });
//    });
//}

//var desacivar = function (tbody, table) {

//    $(tbody).on("click", "input.quitar", function () {

//        var data = table.row($(this).parents("tr")).data();

//        ltl.api.post('RequisitoBus/desactivarEstadoRequisito', data, true, function (err, res) {
//            if (err || !res.Data) {
//                ltl.Error(err || res);
//                return;
//            } else {
//                ltl.Info(res);
//                _this.form.trigger('smt_success', [res.Data]);
//            }

//        });
//    });
//}

//var listaReq = [];
//var lista_requisitos = function (tbody, table) {
//    $(tbody).on("click", "input.estado", function () {
//        var data = table.row($(this).parents("tr")).data();
//        listaReq.push(data);
//        console.log(listaReq);
//    })
//}

//var cargarTabla2 = function () {
//    $.ajax({
//        url: 'http://localhost:54684/api/RequisitosBus',
//        method: 'post',
//        datatype: 'json',
//        success: function (data) {
//            var dataTableInstance = $('#tblRequisitos').dataTable({
//                paging: true,
//                sort: true,
//                searching: true,
//                data: data,
//                columns: [
//                    {
//                        "defaultContent": "<input type='button' class='agregar' value='Agregar'><input type='button' class='quitar' value='Quitar'>"
//                    },
//                    { "data": "ID" },
//                    { "data": "ID_REQUISITO" },
//                    { "data": "ESTADO" }
//                    ]
//            })
//        }
//    })
//}

$(document).ready(function () {

    var ctrlActions = new ControlActions();
    var columns = "Id,Email,Fecha,Comercio,Direccion,Total,Estado";

    ctrlActions.FillTable("pedido", 'tblPedidos');
});
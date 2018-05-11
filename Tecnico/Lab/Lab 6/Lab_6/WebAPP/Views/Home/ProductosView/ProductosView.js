$(document).ready(function () {

    var ctrlActions = new ControlActions();
    var columns = "Id,Nombre,Cantidad";

    ctrlActions.FillTable("producto", 'tblProductos');
});
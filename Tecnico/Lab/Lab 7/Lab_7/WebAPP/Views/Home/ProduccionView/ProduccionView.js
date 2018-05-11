$(document).ready(function () {

    var ctrlActions = new ControlActions();
    var columns = "Id,Cantidad,IdAnimal,FechaReg,IdTipoProduccion";

    ctrlActions.FillTable("produccion", 'tblProduccion');
});
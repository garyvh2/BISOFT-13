$(document).ready(function () {

    var ctrlActions = new ControlActions();
    var columns = "Id,IdTipoAnimal,Nombre,Alimento,Edad,FechaNac";

    ctrlActions.FillTable("animal", 'tblAnimales'); 
});
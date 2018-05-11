Imports System.ComponentModel
Imports AccesoDatos

Public Class Desarrolladores
    ' Variables Globales
    Private PROYECTO As Integer
    Private formPadre As Prioridades
    Private mapperDeveloper As DeveloperMapper
    ' ============================================================================
    '
    '                               Constructor
    '
    ' ============================================================================
    Public Sub New(parametroPadre As Prioridades, parametroProyecto As Integer)
        ' Inicializar Componente
        InitializeComponent()

        ' Inicializar Mappers
        mapperDeveloper = New DeveloperMapper()

        ' Captura variables
        formPadre = parametroPadre
        PROYECTO = parametroProyecto
    End Sub
    ' ============================================================================
    '
    '                            Metodos de formulario
    '
    ' ============================================================================
    ' FORM: Charger
    Private Sub Desarrolladores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Developers()
    End Sub
    ' FORM: Cerrando
    Private Sub Desarrolladores_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        formPadre.Show()
    End Sub
    ' ============================================================================
    '
    '                           CRUDS Metodos de llamada
    '
    ' ============================================================================
    ' Crear
    Private Sub BTNCrear_Click(sender As Object, e As EventArgs) Handles BTNCrear.Click
        Dim nuevoDeveloper As Developer
        nuevoDeveloper = New Developer()

        If validarCampos() = False Then
            ' Fill
            nuevoDeveloper.IdProyecto = PROYECTO
            nuevoDeveloper.Nombre = Me.TBNombre.Text
            nuevoDeveloper.Apellido = Me.TBApellido.Text
            nuevoDeveloper.Rol = Me.TBRol.Text

            ' Call Method
            mapperDeveloper.insert(nuevoDeveloper)

            ' Reload Grid
            Load_Developers()
        End If

    End Sub
    ' Eliminar
    Private Sub BTNEliminar_Click(sender As Object, e As EventArgs) Handles BTNEliminar.Click
        Dim eliminarDeveloper As Developer
        eliminarDeveloper = New Developer()

        ' Fill
        eliminarDeveloper.Id = TBID.Value

        ' Call Method
        mapperDeveloper.delete(eliminarDeveloper)

        ' Reload Grid
        Load_Developers()
    End Sub
    ' Actualizar
    Private Sub BTNActualizar_Click(sender As Object, e As EventArgs) Handles BTNMod.Click
        Dim actualizarDeveloper As Developer
        actualizarDeveloper = New Developer()

        If validarCampos() = False Then
            ' Fill
            actualizarDeveloper.Id = TBID.Value
            actualizarDeveloper.IdProyecto = PROYECTO
            actualizarDeveloper.Nombre = TBNombre.Text
            actualizarDeveloper.Apellido = TBApellido.Text
            actualizarDeveloper.Rol = TBRol.Text

            ' Call Method
            mapperDeveloper.update(actualizarDeveloper)

            ' Reload
            Load_Developers()
        End If
    End Sub
    ' Validacion
    Public Function validarCampos() As Boolean
        Dim bError As Boolean
        bError = False

        If TBApellido.Text = "" Then
            bError = True
        Else
            bError = False
        End If
        If TBNombre.Text = "" Then
            bError = True
        Else
            bError = False
        End If
        If TBRol.Text = "" Then
            bError = True
        Else
            bError = False
        End If
        Return bError
    End Function
    ' ============================================================================
    '
    '                           DataGridView Metodos
    '
    ' ============================================================================
    ' Refresh
    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click
        Load_Developers()
    End Sub
    ' Click en Celda
    Private Sub DGDevelopers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGDevelopers.CellClick
        ' Es posible clickar fuera de los rows por lo que se debe controlar el indice
        If (e.RowIndex >= 0) Then
            ' Get Grid Cell ID
            Dim cellID As DataGridViewTextBoxCell = CType(DGDevelopers.Rows(e.RowIndex).Cells("Id"), DataGridViewTextBoxCell)

            ' Get the Developer Object
            Dim obtenerDeveloper As Developer = mapperDeveloper.findById(cellID.Value)

            ' Fill the Inputs
            TBID.Value = obtenerDeveloper.Id
            TBNombre.Text = obtenerDeveloper.Nombre
            TBApellido.Text = obtenerDeveloper.Apellido
            TBRol.Text = obtenerDeveloper.Rol
        End If
    End Sub
    ' Llenar DataGrid
    Public Sub Load_Developers()
        ' Get Data
        Dim listaDevelopers = mapperDeveloper.findAll(PROYECTO)
        DGDevelopers.DataSource = listaDevelopers

        ' Configuration
        DGDevelopers.ReadOnly = True
        DGDevelopers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
End Class
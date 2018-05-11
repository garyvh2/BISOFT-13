Imports AccesoDatos

Public Class Requerimientos
    ' Variables Globales
    Private PROYECTO As Integer
    Private formPadre As Prioridades
    Private mapperCategoria As CategoriaMapper
    Private mapperRequerimientos As RequerimientoMapper
    Public Sub New(parametroPadre As Prioridades, parametroProyecto As Integer)
        ' Inicializar Componente
        InitializeComponent()

        ' Inicializar Mapper
        mapperCategoria = New CategoriaMapper()
        mapperRequerimientos = New RequerimientoMapper()

        ' Captura de parametros
        PROYECTO = parametroProyecto
        formPadre = parametroPadre
    End Sub
    ' ============================================================================
    '
    '                            Metodos de formulario
    '
    ' ============================================================================
    ' FORM: Carga
    Private Sub Requerimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_ComboBox()
        Load_Requerimientos()
        State_Provider_Categorias()
    End Sub
    ' FORM: Cerrando
    Private Sub Requerimientos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        formPadre.Show()
    End Sub
    ' ============================================================================
    '
    '                           CRUDS Metodos de llamada
    '
    ' ============================================================================
    ' Crear
    Private Sub BTNCrear_Click(sender As Object, e As EventArgs) Handles BTNCrear.Click
        Dim nuevoRequerimiento As Requerimiento
        nuevoRequerimiento = New Requerimiento()

        If validarCampos() = False Then
            ' Fill
            nuevoRequerimiento.Nombre = TBNombre.Text
            nuevoRequerimiento.IdProyecto = PROYECTO
            nuevoRequerimiento.Tipo = CType(CBTipo.SelectedValue, TipoRequerimiento)
            If (nuevoRequerimiento.Tipo = TipoRequerimiento.Functional) Then
                nuevoRequerimiento.IdCategoria = Nothing
            Else
                nuevoRequerimiento.IdCategoria = CBCategoria.SelectedValue
            End If

            ' Call Method
            mapperRequerimientos.insert(nuevoRequerimiento)

            ' Reload Grid
            Load_Requerimientos()
        End If
    End Sub
    ' Eliminar
    Private Sub BTNEliminar_Click(sender As Object, e As EventArgs) Handles BTNEliminar.Click
        Dim eliminarRequerimiento As Requerimiento
        eliminarRequerimiento = New Requerimiento()

        ' Fill
        eliminarRequerimiento.Id = TBID.Value

        ' Call Method
        mapperRequerimientos.delete(eliminarRequerimiento)

        ' Reload Grid
        Load_Requerimientos()
    End Sub
    ' Actualizar
    Private Sub BTNActualizar_Click(sender As Object, e As EventArgs) Handles BTNActualizar.Click
        Dim actualizarRequerimiento As Requerimiento
        actualizarRequerimiento = New Requerimiento()

        If validarCampos() = False Then
            ' Fill
            actualizarRequerimiento.Id = TBID.Value
            actualizarRequerimiento.IdProyecto = PROYECTO
            actualizarRequerimiento.Nombre = TBNombre.Text
            actualizarRequerimiento.Tipo = CType(CBTipo.SelectedValue, TipoRequerimiento)
            If (actualizarRequerimiento.Tipo = TipoRequerimiento.Functional) Then
                actualizarRequerimiento.IdCategoria = Nothing
            Else
                actualizarRequerimiento.IdCategoria = CBCategoria.SelectedValue
            End If

            ' Call Method
            mapperRequerimientos.update(actualizarRequerimiento)

            ' Reload Grid
            Load_Requerimientos()
        End If

    End Sub
    ' Validar
    Public Function validarCampos() As Boolean
        Dim bError As Boolean
        bError = False

        If TBNombre.Text = "" Then
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
        Load_Requerimientos()
    End Sub
    ' Click en Celda
    Private Sub DGRequerimientos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGRequerimientos.CellClick
        ' Dim cell As DataGridCell = 
        If (e.RowIndex >= 0) Then
            ' Get Cell ID
            Dim cellID As DataGridViewTextBoxCell = CType(DGRequerimientos.Rows(e.RowIndex).Cells("Id"), DataGridViewTextBoxCell)

            ' Obtener Objeto
            Dim requerimiento As Requerimiento = mapperRequerimientos.findById(cellID.Value)

            TBID.Value = requerimiento.Id
            TBNombre.Text = requerimiento.Nombre
            CBTipo.SelectedIndex = CBTipo.FindString(requerimiento.Tipo.ToString())
            CBCategoria.SelectedIndex = CBCategoria.FindString(requerimiento.NombreCategoria)

            State_Provider_Categorias()
        End If
    End Sub
    ' Llenar Data Grid
    Public Sub Load_Requerimientos()
        ' Get Data
        Dim listCategorias = mapperRequerimientos.findAll(PROYECTO)
        DGRequerimientos.DataSource = listCategorias

        ' Configuration
        DGRequerimientos.ReadOnly = True
        DGRequerimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Remove Columns
        If (listCategorias IsNot Nothing) Then
            DGRequerimientos.Columns.Remove("IdCategoria")
            DGRequerimientos.Columns.Remove("IdProyecto")
        End If
    End Sub
    ' ============================================================================
    '
    '                           Combo Box Metodos
    '
    ' ============================================================================
    ' Llenar
    Public Sub Load_ComboBox()
        ' Llenar categorias con list
        Dim listCategorias = mapperCategoria.findAll()
        CBCategoria.DataSource = listCategorias
        CBCategoria.DisplayMember = "Nombre"
        CBCategoria.ValueMember = "Id"

        ' Llenar Tipo con enum
        CBTipo.DataSource = [Enum].GetValues(GetType(TipoRequerimiento))
    End Sub
    ' Cambia valor
    Private Sub CBTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBTipo.SelectedIndexChanged
        State_Provider_Categorias()
    End Sub
    ' Proveedor de estado
    Public Sub State_Provider_Categorias()
        Dim value As Integer = CBTipo.SelectedValue

        If (CType(value, TipoRequerimiento) = TipoRequerimiento.Functional) Then
            CBCategoria.Hide()
        Else
            CBCategoria.Show()
        End If
    End Sub
End Class
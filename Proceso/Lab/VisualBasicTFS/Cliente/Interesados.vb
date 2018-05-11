Imports AccesoDatos
Imports Cliente

Public Class Interesados
    ' Variables Globales
    Private PROYECTO As Integer
    Private formPadre As Prioridades
    Private mapperInteresado As InteresadoMapper
    ' ============================================================================
    '
    '                               Constructor
    '
    ' ============================================================================
    Public Sub New(parametroPadre As Prioridades, parametroProyecto As Integer)
        ' Inicializar Componente
        InitializeComponent()

        ' Inicializar Mapper
        mapperInteresado = New InteresadoMapper()

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
    Private Sub Interesados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_ComboBox()
        Load_Interesados()
    End Sub
    ' FORM: Cerrando
    Private Sub Interesados_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        formPadre.Show()
    End Sub
    ' ============================================================================
    '
    '                           CRUDS Metodos de llamada
    '
    ' ============================================================================
    ' Crear
    Private Sub BTNCrear_Click(sender As Object, e As EventArgs) Handles BTNCrear.Click
        Dim nuevoInteresado As Interesado
        nuevoInteresado = New Interesado()

        If validarCampos() = False Then
            ' Fill
            nuevoInteresado.IdProyecto = PROYECTO
            nuevoInteresado.Nombre = TBNombre.Text
            nuevoInteresado.Apellido = TBApellido.Text
            nuevoInteresado.Peso = CType(CBNiveles.SelectedValue, TipoRequerimiento)

            ' Call MEthod
            mapperInteresado.insert(nuevoInteresado)

            ' Reload Grid
            Load_Interesados()
        End If
    End Sub
    ' Eliminar
    Private Sub BTNEliminar_Click(sender As Object, e As EventArgs) Handles BTNEliminar.Click
        Dim eliminarInteresado As Interesado
        eliminarInteresado = New Interesado()

        ' Fill
        eliminarInteresado.Id = TBID.Text

        ' Call Method
        mapperInteresado.Delete(eliminarInteresado)

        ' Reload Grid
        Load_Interesados()
    End Sub
    ' Actualizar
    Private Sub BTNActualizar_Click(sender As Object, e As EventArgs) Handles BTNActualizar.Click
        Dim actualizarInteresado As Interesado
        actualizarInteresado = New Interesado()

        If validarCampos() = False Then
            ' Fill
            actualizarInteresado.Id = TBID.Value
            actualizarInteresado.IdProyecto = PROYECTO
            actualizarInteresado.Nombre = TBNombre.Text
            actualizarInteresado.Apellido = TBApellido.Text
            actualizarInteresado.Peso = CType(CBNiveles.SelectedValue, TipoRequerimiento)

            ' Call Method
            mapperInteresado.Update(actualizarInteresado)

            ' Reload Grid
            Load_Interesados()
        End If
    End Sub
    ' Validar
    Public Function validarCampos() As Boolean
        Dim bError As Boolean
        bError = False

        If TBID.Text = "" Then
            bError = True
        Else
            bError = False
        End If
        If TBNombre.Text = "" Then
            bError = True
        Else
            bError = False
        End If
        If CBNiveles.Text = "Seleccione un nivel" Then
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
        Load_Interesados()
    End Sub
    ' Click en Celda
    Private Sub DGInteresados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGInteresados.CellClick
        ' Es posible clickar fuera de los rows por lo que se debe controlar el indice
        If (e.RowIndex >= 0) Then
            ' Get Cell ID
            Dim cellID As DataGridViewTextBoxCell = CType(DGInteresados.Rows(e.RowIndex).Cells("Id"), DataGridViewTextBoxCell)

            ' Get Object
            Dim interesado As Interesado = mapperInteresado.findById(cellID.Value)

            ' Fill the inputs
            TBID.Value = interesado.Id
            TBNombre.Text = interesado.Nombre
            TBApellido.Text = interesado.Apellido
            CBNiveles.SelectedIndex = CBNiveles.FindString(interesado.Peso.ToString())
        End If
    End Sub
    ' Llenar Data Grid
    Private Sub Load_Interesados()
        ' Get Data
        Dim listaInteresados = mapperInteresado.findAll(PROYECTO)
        DGInteresados.DataSource = listaInteresados

        ' Configuracion de DataGrid
        DGInteresados.ReadOnly = True
        DGInteresados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    ' Llenar Combo Box
    Private Sub Load_ComboBox()
        ' Llenar Tipo con enum
        CBNiveles.DataSource = [Enum].GetValues(GetType(NivelInteres))
    End Sub
End Class
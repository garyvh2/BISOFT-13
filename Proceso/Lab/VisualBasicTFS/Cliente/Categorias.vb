Imports System.ComponentModel
Imports AccesoDatos

Public Class Categorias
    ' Variables Globales
    Private formPadre As Prioridades
    Private mapperCategoria As CategoriaMapper
    ' ============================================================================
    '
    '                               Constructor
    '
    ' ============================================================================
    Public Sub New(parametroPadre As Prioridades)
        ' Inicializar el componente
        InitializeComponent()

        ' Inicializar Mappers
        mapperCategoria = New CategoriaMapper()

        ' Captura variable parametro
        formPadre = parametroPadre
    End Sub
    ' ============================================================================
    '
    '                            Metodos de formulario
    '
    ' ============================================================================
    ' FORM: Charger
    Private Sub Categorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Categorias()
    End Sub
    ' FORM: Cerrando
    Private Sub Categorias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        formPadre.Show()
    End Sub
    ' ============================================================================
    '
    '                           CRUDS Metodos de llamada
    '
    ' ============================================================================
    ' Crear
    Private Sub BTNCrear_Click(sender As Object, e As EventArgs) Handles BTNCrear.Click
        Dim nuevaCategoria As Categoria
        nuevaCategoria = New Categoria()
        If validarCampos() = False Then
            ' Fill
            nuevaCategoria.Nombre = TBNombre.Text

            ' Call Method
            mapperCategoria.insert(nuevaCategoria)

            ' Reload Grid
            Load_Categorias()
        End If
    End Sub
    ' Eliminar
    Private Sub BTNEliminar_Click(sender As Object, e As EventArgs) Handles BTNEliminar.Click
        Dim eliminarCategoria As Categoria
        eliminarCategoria = New Categoria()

        ' Fill
        eliminarCategoria.Id = TBID.Value

        ' Call Method
        mapperCategoria.delete(eliminarCategoria)

        ' Reload Grid
        Load_Categorias()
    End Sub
    ' Actualizar
    Private Sub BTNActualizar_Click(sender As Object, e As EventArgs) Handles BTNActualizar.Click
        Dim actualizarCategoria As Categoria
        actualizarCategoria = New Categoria()

        If validarCampos() = False Then
            ' Fill
            actualizarCategoria.Id = TBID.Value
            actualizarCategoria.Nombre = TBNombre.Text

            ' Call Method
            mapperCategoria.update(actualizarCategoria)

            ' Reload Grid
            Load_Categorias()
        End If
    End Sub
    ' Validacion
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
    ' Refrescar
    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click
        Load_Categorias()
    End Sub
    ' Click en Celda
    Private Sub DGCategorias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCategorias.CellClick
        ' Es posible clickar fuera de los rows por lo que se debe controlar el indice
        If (e.RowIndex >= 0) Then
            ' Get Cell ID
            Dim cellID As DataGridViewTextBoxCell = CType(DGCategorias.Rows(e.RowIndex).Cells("Id"), DataGridViewTextBoxCell)

            ' Get the Developer Object
            Dim obtenerCategoria As Categoria = mapperCategoria.findById(cellID.Value)

            ' Fill the inputs
            TBID.Value = obtenerCategoria.Id
            TBNombre.Text = obtenerCategoria.Nombre
        End If
    End Sub
    ' Llenar DataGrid
    Public Sub Load_Categorias()
        ' Get Data
        Dim listaCategorias = mapperCategoria.findAll()
        DGCategorias.DataSource = listaCategorias

        ' Configuracion del grid
        DGCategorias.ReadOnly = True ' No editable
        DGCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill ' Coincidir tamanno
    End Sub
End Class
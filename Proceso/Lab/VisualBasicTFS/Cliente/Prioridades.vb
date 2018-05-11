Imports AccesoDatos

Public Class Prioridades
    Private PROYECTO As Integer
    Private SelectedRow As Integer
    Private parent As Proyectos

    Private mapperPri As PrioridadMapper
    Private mapperReq As RequerimientoMapper
    Public Sub New(pParent As Proyectos, proyectoId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        parent = pParent
        PROYECTO = proyectoId
        mapperPri = New PrioridadMapper()
        mapperReq = New RequerimientoMapper()
    End Sub
    Private Sub Interesados_Click(sender As Object, e As EventArgs) Handles Interesados.Click
        ' Requerimientos
        ' Instanciate
        Dim formInt As Interesados
        formInt = New Interesados(Me, PROYECTO)
        ' Show
        formInt.Show()

        ' Hide
        Me.Hide()
    End Sub

    Private Sub Requerimientos_Click(sender As Object, e As EventArgs) Handles Requerimientos.Click
        ' Requerimientos
        ' Instanciate
        Dim formReq As Requerimientos
        formReq = New Requerimientos(Me, PROYECTO)
        ' Show
        formReq.Show()
        formReq = Nothing
        ' Hide
        Me.Hide()
    End Sub

    Private Sub Categorias_Click(sender As Object, e As EventArgs) Handles Categorias.Click
        ' Categorias
        ' Instanciate
        Dim formCat As Categorias
        formCat = New Categorias(Me)
        ' Show
        formCat.Show()
        formCat = Nothing
        ' Hide
        Me.Hide()
    End Sub

    Private Sub Desarrolladores_Click(sender As Object, e As EventArgs) Handles Desarrolladores.Click

        ' Desarrollaodores
        ' Instanciate
        Dim formDev As Desarrolladores
        formDev = New Desarrolladores(Me, PROYECTO)
        ' Show
        formDev.Show()
        formDev = Nothing
        ' Hide
        Me.Hide()


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Casos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Add Calculus Rows
        Load_ComboBox()
        Load_Prioridades()
    End Sub
    Public Sub Load_ComboBox()
        ' Llenar categorias con list
        Dim listRequerimientos As List(Of Requerimiento) = mapperReq.findAll(PROYECTO)
        CBRequerimientos.DataSource = listRequerimientos
        CBRequerimientos.DisplayMember = "Nombre"
        CBRequerimientos.ValueMember = "Id"
    End Sub

    Private Sub Casos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        parent.Show()
    End Sub
    Public Function validarCampos() As Boolean
        Dim bError As Boolean
        bError = False

        If TBBeneficio.Text = "" Then
            bError = True
        Else
            bError = False
        End If
        If TBCosto.Text = "" Then
            bError = True
        Else
            bError = False
        End If
        If TBPenalidad.Text = "" Then
            bError = True
        Else
            bError = False
        End If
        If TBRiesgo.Text = "" Then
            bError = True
        Else
            bError = False
        End If
        Return bError
    End Function
    Private Sub BTNCalcular_Click(sender As Object, e As EventArgs) Handles BTNCalcular.Click
        Dim newPrioridad As Prioridad
        newPrioridad = New Prioridad()
        If validarCampos() = False Then
            ' Fill
            Integer.TryParse(CBRequerimientos.SelectedValue, newPrioridad.IdRequerimiento)
            Integer.TryParse(TBBeneficio.Text, newPrioridad.Beneficio)
            Integer.TryParse(TBCosto.Text, newPrioridad.Costo)
            Integer.TryParse(TBPenalidad.Text, newPrioridad.Penalidad)
            Integer.TryParse(TBRiesgo.Text, newPrioridad.Riesgo)
            newPrioridad.IdProyecto = PROYECTO


            mapperPri.insert(newPrioridad)
            Load_Prioridades()
        End If
    End Sub
    Public Sub Load_Prioridades()
        ' Get Data
        Dim listPrioridades = mapperPri.findAll(PROYECTO)
        DGPrioridades.DataSource = listPrioridades

        ' Configuration
        DGPrioridades.ReadOnly = True
        DGPrioridades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        ' Remove Column
        If (listPrioridades IsNot Nothing) Then
            ' Auto Fit Column
            DGPrioridades.Columns("NombreRequerimiento").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' Remove Columns
            DGPrioridades.Columns.Remove("IdRequerimiento")
            DGPrioridades.Columns.Remove("IdProyecto")

            ' Add Rows
            If (DGPrioridades.Columns("Valor Total") Is Nothing) Then
                DGPrioridades.Columns.Add("Valor Total", "Valor Total")
                DGPrioridades.Columns("Valor Total").DisplayIndex = 4
                DGPrioridades.Columns.Add("Valor %", "Valor %")
                DGPrioridades.Columns("Valor %").DisplayIndex = 5
                DGPrioridades.Columns.Add("Costo %", "Costo %")
                DGPrioridades.Columns("Costo %").DisplayIndex = 7
                DGPrioridades.Columns.Add("Riesgo %", "Riego %")
                DGPrioridades.Columns("Riesgo %").DisplayIndex = 9
                DGPrioridades.Columns.Add("Prioridad", "Prioridad")
            End If

            ' Totals row calculations
            Dim totales As DataGridViewRow = DGPrioridades.Rows(DGPrioridades.Rows.Count - 1)
            Dim valorTotal As Double = (totales.Cells("Beneficio").Value * 2.0) + (totales.Cells("Penalidad").Value * 1.0)
            Dim costoTotal As Double = totales.Cells("Costo").Value
            Dim riesgoTotal As Double = totales.Cells("Riesgo").Value
            totales.Cells("Valor Total").Value = valorTotal
            totales.Cells("Valor %").Value = 100%
            totales.Cells("Costo %").Value = 100%
            totales.Cells("Riesgo %").Value = 100%


            For Each row As DataGridViewRow In DGPrioridades.Rows
                If (True) Then
                    Dim prioridad As Prioridad = RowFormatter(row)

                    ' Calculate
                    Dim valorTotalRow As Double = (prioridad.Beneficio * 2.0) + (prioridad.Penalidad * 1.0)
                    Dim valorPorcentualRow As Double = (100 * valorTotalRow) / valorTotal
                    Dim costoPorcentualRow As Double = (100 * prioridad.Costo) / costoTotal
                    Dim riesgoPorcentualRow As Double = (100 * prioridad.Riesgo) / riesgoTotal
                    Dim prioridadTotalRow As Double = valorPorcentualRow / ((costoPorcentualRow * 1) + (riesgoPorcentualRow * 0.5))

                    row.Cells("Valor Total").Value = valorTotalRow
                    row.Cells("Valor %").Value = valorPorcentualRow
                    row.Cells("Costo %").Value = costoPorcentualRow
                    row.Cells("Riesgo %").Value = riesgoPorcentualRow
                    row.Cells("Prioridad").Value = prioridadTotalRow
                End If
            Next
        End If

    End Sub
    Private Function RowFormatter(ByVal row As DataGridViewRow) As Prioridad
        Dim prioridad As Prioridad
        prioridad = New Prioridad()

        prioridad.Beneficio = CType(row.Cells("Beneficio"), DataGridViewTextBoxCell).Value
        prioridad.Penalidad = CType(row.Cells("Penalidad"), DataGridViewTextBoxCell).Value
        prioridad.Costo = CType(row.Cells("Costo"), DataGridViewTextBoxCell).Value
        prioridad.Riesgo = CType(row.Cells("Riesgo"), DataGridViewTextBoxCell).Value

        Return prioridad
    End Function
    Private Sub BTNDecartar_Click(sender As Object, e As EventArgs) Handles BTNDecartar.Click
        Dim prioridad As Prioridad
        prioridad = New Prioridad()

        If (SelectedRow <> Nothing) Then
            prioridad.Id = SelectedRow
            mapperPri.delete(prioridad)
            Load_Prioridades()
        End If
    End Sub

    Private Sub DGPrioridades_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGPrioridades.CellClick
        If (e.RowIndex >= 0) Then
            Dim cellID As DataGridViewTextBoxCell = CType(DGPrioridades.Rows(e.RowIndex).Cells("Id"), DataGridViewTextBoxCell)
            BTNDecartar.Text = "Descartar " + cellID.Value.ToString()
            SelectedRow = cellID.Value
        End If
    End Sub
End Class
Imports System.Reflection
Imports AccesoDatos

Public Class Proyectos
    Dim mapper As New ProyectoMapper

    Private Sub btnNew_Click_1(sender As Object, e As EventArgs) Handles btnNew.Click
        NuevoProyecto.Show()
    End Sub

    Private Sub Proyectos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mapper = New ProyectoMapper()
        Load_Proyectos()
    End Sub

    Public Sub Load_Proyectos()
        ' Get Data
        Dim listDevs = mapper.findAll()
        DGProyectos.DataSource = listDevs

        ' Configuration
        DGProyectos.ReadOnly = True
        DGProyectos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    End Sub
    Private Sub BtbDelete_Click(sender As Object, e As EventArgs)
        Dim i As Integer
        Dim proyect As New Proyecto
        i = DGProyectos.CurrentRow.Index

        mapper.Delete(DGProyectos.Item(0, i).Value)
        '   reload()
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub listProyect_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DGProyectos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGProyectos.CellClick
        If (e.RowIndex >= 0) Then
            Dim cellID As DataGridViewTextBoxCell = CType(DGProyectos.Rows(e.RowIndex).Cells("Id"), DataGridViewTextBoxCell)

            Dim casosForm As Prioridades
            casosForm = New Prioridades(Me, cellID.Value)

            casosForm.Show()
            Me.Hide()

        End If
    End Sub
End Class
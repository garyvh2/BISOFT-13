Imports AccesoDatos


Public Class NuevoProyecto
    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        If txtname.Text = "" Then 'Si el texto viene vacio
            'Mostrar mensaje
        Else ' Sino Guarde el nuevo proyecto y cierre el formulario
            Dim proyec As Proyecto = New Proyecto()
            proyec.nombre = txtname.Text
            Dim pMapper As ProyectoMapper = New ProyectoMapper()
            pMapper.Register(proyec.nombre)
            Proyectos.Load_Proyectos()
            Me.Close() 'Cerrar formulario
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub newProyect_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
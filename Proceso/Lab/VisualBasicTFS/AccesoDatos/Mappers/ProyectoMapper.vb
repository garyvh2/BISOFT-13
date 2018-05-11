Imports System.Data.SqlClient
Imports AccesoDatos

Public Class ProyectoMapper

    Private _Reader As SqlDataReader

    Public Function Register(ByVal nombre As String)
        Try
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()

            DB.SQLQuery("registrar_proyecto").IsStoredProcedure()
            DB.SQLParam("@NAME", nombre, SqlDbType.VarChar, 50)
            Me._Reader = DB.ExecuteStoredProcedure()

        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function Search(ByVal nombre As String) As List(Of Proyecto)
        Try
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()

            DB.SQLQuery("buscar_proyecto").IsStoredProcedure()
            DB.SQLParam("@NAME", nombre, SqlDbType.VarChar, 60)
            Me._Reader = DB.ExecuteStoredProcedure()
            Return Me.mapperMultiple()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function mapperMultiple() As List(Of Proyecto)
        Try
            Dim proyects As List(Of Proyecto) = New List(Of Proyecto)
            If (Me._Reader.HasRows()) Then
                While (Me._Reader.Read)
                    Dim proyect As Proyecto = New Proyecto()
                    Integer.TryParse(Me._Reader("ID"), proyect.Id)
                    proyect.Nombre = Me._Reader("NOMBRE").ToString()
                    proyects.Add(proyect)
                End While
                Return proyects
            End If

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function findAll() As List(Of Proyecto)
        Try
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()

            DB.SQLQuery("listar_proyectos").IsStoredProcedure()
            Me._Reader = DB.ExecuteStoredProcedure()
            Return Me.mapperMultiple()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Delete(ByVal pid As Int32)
        Try
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()

            DB.SQLQuery("borrar_proyecto").IsStoredProcedure()
            DB.SQLParam("@ID", pid, SqlDbType.Int, 11)
            Me._Reader = DB.ExecuteStoredProcedure()

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Update(ByVal pid As Int32, ByVal pnombre As String)
        Try
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()

            DB.SQLQuery("actualizar_proyecto").IsStoredProcedure()
            ' DB.SQLParam("@ID", Proyecto.id, SqlDbType.Int, 32)
            ' DB.SQLParam("@NOMBRE", Proyecto.nombre, SqlDbType.VarChar, 50)
            Me._Reader = DB.ExecuteStoredProcedure()



        Catch ex As Exception
            Return Nothing
        End Try
    End Function


End Class

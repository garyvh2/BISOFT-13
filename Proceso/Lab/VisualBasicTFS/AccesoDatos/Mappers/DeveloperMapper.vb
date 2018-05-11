Imports System.Data.SqlClient

Public Class DeveloperMapper

    Private _Reader As SqlDataReader

    Public Function findById(ByVal id As Integer) As Developer
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("buscar_dev").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@ID", id, SqlDbType.Int, 18)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
            Return Me.mapperSingle()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function insert(ByVal regDevs As Developer) As Integer
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("insert_dev").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@NOMBRE", regDevs.Nombre, SqlDbType.VarChar, 20)
            ' Add Params 
            DB.SQLParam("@APELLIDOS", regDevs.Apellido, SqlDbType.VarChar, 20)
            ' Add Params 
            DB.SQLParam("@ROL", regDevs.Rol, SqlDbType.VarChar, 20)
            ' Add Params 
            DB.SQLParam("@ID_PROYECTO", regDevs.IdProyecto, SqlDbType.Int, 15)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function mapperSingle() As Developer
        Try
            Dim regDevs As Developer = New Developer()
            If (Me._Reader.HasRows()) Then
                While Me._Reader.Read()
                    Integer.TryParse(Me._Reader("Id"), regDevs.Id)
                    Integer.TryParse(Me._Reader("id_proyecto"), regDevs.IdProyecto)
                    regDevs.Nombre = Me._Reader("Nombre").ToString()
                    regDevs.Apellido = Me._Reader("Apellidos").ToString()
                    regDevs.Rol = Me._Reader("Rol").ToString()
                End While
                Return regDevs
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function mapperMultiple() As List(Of Developer)
        Try
            Dim regDevss As List(Of Developer) = New List(Of Developer)
            If (Me._Reader.HasRows()) Then
                While Me._Reader.Read()
                    Dim regDevs As Developer = New Developer()
                    Integer.TryParse(Me._Reader("Id"), regDevs.Id)
                    Integer.TryParse(Me._Reader("id_proyecto"), regDevs.IdProyecto)
                    regDevs.Nombre = Me._Reader("Nombre").ToString()
                    regDevs.Apellido = Me._Reader("Apellidos").ToString()
                    regDevs.Rol = Me._Reader("Rol").ToString()
                    regDevss.Add(regDevs)
                End While
                Return regDevss
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function findAll(ByVal pProyecto) As List(Of Developer)
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("buscar_devs").IsStoredProcedure()
            ' Add Para
            DB.SQLParam("@ID_PROYECTO", pProyecto, SqlDbType.Int, 15)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
            ' Map Single Item
            Return Me.mapperMultiple()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function update(ByVal regDevs As Developer) As Integer
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("modify_dev").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@ID", regDevs.Id, SqlDbType.Int, 15)
            ' Add Params 
            DB.SQLParam("@NOMBRE", regDevs.Nombre, SqlDbType.VarChar, 20)
            ' Add Params 
            DB.SQLParam("@APELLIDOS", regDevs.Apellido, SqlDbType.VarChar, 20)
            ' Add Params 
            DB.SQLParam("@ROL", regDevs.Rol, SqlDbType.VarChar, 20)
            ' Add Params 
            DB.SQLParam("@ID_PROYECTO", regDevs.IdProyecto, SqlDbType.Int, 15)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function delete(ByVal regDevs As Developer) As Integer
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("delete_dev").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@ID", regDevs.Id, SqlDbType.Int, 20)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class

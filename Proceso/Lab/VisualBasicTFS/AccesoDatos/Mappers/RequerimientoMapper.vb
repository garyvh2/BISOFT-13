Imports System.Data.SqlClient

Public Class RequerimientoMapper
    Private _Reader As SqlDataReader
    Public Function findById(ByVal id As Integer) As Requerimiento
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("buscar_requerimiento").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@ID", id, SqlDbType.Int, 18)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
            ' Map Single Item
            Return Me.mapperSingle()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function findAll(ByVal pProyecto) As List(Of Requerimiento)
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("buscar_requerimientos").IsStoredProcedure()
            ' Add Param
            DB.SQLParam("@ID_PROYECTO", pProyecto, SqlDbType.Int, 15)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
            ' Map Single Item
            Return Me.mapperMultiple()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function insert(ByVal requerimiento As Requerimiento) As Integer
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("insert_requerimiento").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@NOMBRE", requerimiento.Nombre, SqlDbType.VarChar, 150)
            ' Add Params 
            DB.SQLParam("@TIPO", CType(requerimiento.Tipo, Integer), SqlDbType.Bit, 1)
            ' Add Params 
            DB.SQLParam("@ID_PROYECTO", requerimiento.IdProyecto, SqlDbType.Int, 15)
            ' Add Params 
            DB.SQLParam("@ID_CATEGORIA", If(requerimiento.IdCategoria, requerimiento.IdCategoria, DBNull.Value), SqlDbType.Int, 15)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function update(ByVal requerimiento As Requerimiento) As Integer
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("update_requerimiento").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@ID", requerimiento.Id, SqlDbType.Int, 15)
            ' Add Params 
            DB.SQLParam("@NOMBRE", requerimiento.Nombre, SqlDbType.VarChar, 150)
            ' Add Params 
            DB.SQLParam("@TIPO", CType(requerimiento.Tipo, Integer), SqlDbType.Bit, 1)
            ' Add Params 
            DB.SQLParam("@ID_PROYECTO", requerimiento.IdProyecto, SqlDbType.Int, 15)
            ' Add Params 
            DB.SQLParam("@ID_CATEGORIA", If(requerimiento.IdCategoria, requerimiento.IdCategoria, DBNull.Value), SqlDbType.Int, 15)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function delete(ByVal requerimiento As Requerimiento) As Integer
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("eliminar_requerimiento").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@ID", requerimiento.Id, SqlDbType.Int, 20)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function mapperSingle() As Requerimiento
        Try
            Dim requerimiento As Requerimiento = New Requerimiento()
            If (Me._Reader.HasRows()) Then
                While Me._Reader.Read()
                    Integer.TryParse(Me._Reader("ID"), requerimiento.Id)
                    requerimiento.Nombre = Me._Reader("NOMBRE").ToString()
                    requerimiento.Tipo = CType(Me._Reader("TIPO"), TipoRequerimiento)
                    Integer.TryParse(Me._Reader("ID_PROYECTO"), requerimiento.IdProyecto)
                    If (Me._Reader("ID_CATEGORIA") IsNot DBNull.Value) Then
                        Integer.TryParse(Me._Reader("ID_CATEGORIA"), requerimiento.IdCategoria)
                    Else
                        requerimiento.IdCategoria = Nothing
                    End If
                End While
                Return requerimiento
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function mapperMultiple() As List(Of Requerimiento)
        Try
            Dim requerimientos As List(Of Requerimiento) = New List(Of Requerimiento)
            If (Me._Reader.HasRows()) Then
                While Me._Reader.Read()
                    Dim requerimiento As Requerimiento = New Requerimiento()
                    Integer.TryParse(Me._Reader("ID"), requerimiento.Id)
                    requerimiento.Nombre = Me._Reader("NOMBRE").ToString()
                    requerimiento.Tipo = CType(Me._Reader("TIPO"), TipoRequerimiento)
                    Integer.TryParse(Me._Reader("ID_PROYECTO"), requerimiento.IdProyecto)
                    If (Me._Reader("ID_CATEGORIA") IsNot DBNull.Value) Then
                        Integer.TryParse(Me._Reader("ID_CATEGORIA"), requerimiento.IdCategoria)
                    Else
                        requerimiento.IdCategoria = Nothing
                    End If
                    requerimientos.Add(requerimiento)
                End While
                Return requerimientos
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class

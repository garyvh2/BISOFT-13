Imports System.Data.SqlClient

Public Class CategoriaMapper
    Private _Reader As SqlDataReader
    Public Function findById(ByVal id As Integer) As Categoria
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("buscar_categoria").IsStoredProcedure()
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
    Public Function findAll() As List(Of Categoria)
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("buscar_categorias").IsStoredProcedure()
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
            ' Map Single Item
            Return Me.mapperMultiple()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function insert(ByVal categoria As Categoria) As Boolean
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("insert_categoria").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@NOMBRE", categoria.Nombre, SqlDbType.VarChar, 20)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
            ' Success
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function update(ByVal categoria As Categoria) As Boolean
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("update_categoria").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@ID", categoria.Id, SqlDbType.Int, 15)
            ' Add Params 
            DB.SQLParam("@NOMBRE", categoria.Nombre, SqlDbType.VarChar, 20)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
            ' Success
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function delete(ByVal categoria As Categoria) As Integer
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("eliminar_categoria").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@ID", categoria.Id, SqlDbType.Int, 20)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
            ' Success
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function mapperSingle() As Categoria
        Try
            Dim categoria As Categoria = New Categoria()
            If (Me._Reader.HasRows()) Then
                While Me._Reader.Read()
                    Integer.TryParse(Me._Reader("ID"), categoria.Id)
                    categoria.Nombre = Me._Reader("NOMBRE").ToString()
                End While
                Return categoria
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function mapperMultiple() As List(Of Categoria)
        Try
            Dim categorias As List(Of Categoria) = New List(Of Categoria)
            If (Me._Reader.HasRows()) Then
                While Me._Reader.Read()
                    Dim categoria As Categoria = New Categoria()
                    Integer.TryParse(Me._Reader("ID"), categoria.Id)
                    categoria.Nombre = Me._Reader("NOMBRE").ToString()
                    categorias.Add(categoria)
                End While
                Return categorias
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class

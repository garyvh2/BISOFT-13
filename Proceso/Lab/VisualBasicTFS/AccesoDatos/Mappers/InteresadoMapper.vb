Imports System.Data.SqlClient

Public Class InteresadoMapper

    Private _Reader As SqlDataReader
    Public Function findById(ByVal id As Integer) As Interesado
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("buscar_interesado").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@pID", id, SqlDbType.Int, 18)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
            ' Map Single Item
            Return Me.mapperSingle()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function findAll(ByVal pProyecto) As List(Of Interesado)
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("listar_interesado").IsStoredProcedure()
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

    Public Function Listar() As List(Of Interesado)
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("listar_interesado").IsStoredProcedure()
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
            ' Map Single Item
            Return Me.mapperMultiple()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function insert(ByVal interes As Interesado) As Integer
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("registrar_interesado").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@id_proyecto", interes.IdProyecto, SqlDbType.Int, 15)
            ' Add Params 
            DB.SQLParam("@pNombre", interes.Nombre, SqlDbType.VarChar, 30)
            ' Add Params 
            DB.SQLParam("@pApellido", interes.Apellido, SqlDbType.VarChar, 30)
            ' Add Params
            DB.SQLParam("@pPeso", CType(interes.Peso, Integer), SqlDbType.VarChar, 20)
            ' Execute

            Me._Reader = DB.ExecuteStoredProcedure()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Delete(ByVal interes As Interesado) As Integer
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("eliminar_interesados").IsStoredProcedure()
            ' Add Params
            '  DB.SQLQuery("@id_proyecto", interes.proyecto.id, SqlDbType.Int)
            ' Add Params 
            DB.SQLParam("@pId", interes.Id, SqlDbType.Int, 30)
            ' Execute

            Me._Reader = DB.ExecuteStoredProcedure()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Update(ByVal interes As Interesado) As Integer
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("modificar_interesado").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@pId", interes.Id, SqlDbType.Int, 30)
            ' Add Params 
            DB.SQLParam("@id_proyecto", interes.IdProyecto, SqlDbType.VarChar, 30)
            ' Add Params 
            DB.SQLParam("@pNombre", interes.Nombre, SqlDbType.VarChar, 30)
            ' Add Params
            DB.SQLParam("@pApellido", interes.Apellido, SqlDbType.VarChar, 20)
            ' Add Params
            DB.SQLParam("@pPeso", CType(interes.Peso, Integer), SqlDbType.VarChar, 20)
            ' Execute

            Me._Reader = DB.ExecuteStoredProcedure()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function mapperSingle() As Interesado
        Try
            Dim interes As Interesado = New Interesado()
            If (Me._Reader.HasRows()) Then
                While Me._Reader.Read()
                    Integer.TryParse(Me._Reader("id"), interes.Id)
                    Integer.TryParse(Me._Reader("id_proyecto"), interes.IdProyecto)
                    interes.Nombre = Me._Reader("nombre").ToString()
                    interes.Apellido = Me._Reader("apellidos").ToString()
                    interes.Peso = CType(Me._Reader("peso"), NivelInteres)
                End While
                Return interes
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function mapperMultiple() As List(Of Interesado)
        Try
            Dim listaInteresados As List(Of Interesado) = New List(Of Interesado)
            If (Me._Reader.HasRows()) Then
                While Me._Reader.Read()
                    Dim interes As Interesado = New Interesado()
                    Integer.TryParse(Me._Reader("ID"), interes.Id)
                    Integer.TryParse(Me._Reader("id_proyecto"), interes.IdProyecto)
                    interes.Nombre = Me._Reader("NOMBRE").ToString()
                    interes.Apellido = Me._Reader("APELLIDOS").ToString()
                    interes.Peso = CType(Me._Reader("peso"), NivelInteres)
                    listaInteresados.Add(interes)
                End While
                Return listaInteresados
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class

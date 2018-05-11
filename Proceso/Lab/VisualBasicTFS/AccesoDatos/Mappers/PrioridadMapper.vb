Imports System.Data.SqlClient

Public Class PrioridadMapper
    Private _Reader As SqlDataReader
    Public Function findById(ByVal id As Double) As Prioridad
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("buscar_prioridad").IsStoredProcedure()
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
    Public Function findAll(ByVal pProyecto) As List(Of Prioridad)
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("buscar_prioridades").IsStoredProcedure()
            ' Add Param
            DB.SQLParam("@ID_PROYECTO", pProyecto, SqlDbType.Int, 15)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
            ' Map Single Item
            Return Me.mapperMultiple(True)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function insert(ByVal Prioridad As Prioridad) As Double
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("insert_prioridad").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@ID_PROYECTO", Prioridad.IdProyecto, SqlDbType.Int, 15)
            ' Add Params 
            DB.SQLParam("@ID_REQUERIMIENTO", Prioridad.IdRequerimiento, SqlDbType.Int, 15)
            ' Add Params 
            DB.SQLParam("@BENEFICIO", Prioridad.Beneficio, SqlDbType.Float)
            ' Add Params 
            DB.SQLParam("@PENALIDAD", Prioridad.Penalidad, SqlDbType.Float)
            ' Add Params 
            DB.SQLParam("@COSTO", Prioridad.Costo, SqlDbType.Float)
            ' Add Params 
            DB.SQLParam("@RIESGO", Prioridad.Riesgo, SqlDbType.Float)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function update(ByVal Prioridad As Prioridad) As Double
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("update_prioridad").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@ID", Prioridad.Id, SqlDbType.Int, 15)
            ' Add Params 
            DB.SQLParam("@ID_PROYECTO", Prioridad.IdProyecto, SqlDbType.Int, 15)
            ' Add Params 
            DB.SQLParam("@ID_REQUERIMIENTO", Prioridad.IdRequerimiento, SqlDbType.Int, 15)
            ' Add Params 
            DB.SQLParam("@BENEFICIO", Prioridad.Beneficio, SqlDbType.Float)
            ' Add Params 
            DB.SQLParam("@PENALIDAD", Prioridad.Penalidad, SqlDbType.Float)
            ' Add Params 
            DB.SQLParam("@COSTO", Prioridad.Costo, SqlDbType.Float)
            ' Add Params 
            DB.SQLParam("@RIESGO", Prioridad.Riesgo, SqlDbType.Float)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function delete(ByVal Prioridad As Prioridad) As Double
        Try
            ' Initialize DB Connection
            Dim DB As Conexion = New Conexion()
            DB.Bootstrap()
            ' Add Query
            DB.SQLQuery("delete_prioridad").IsStoredProcedure()
            ' Add Params 
            DB.SQLParam("@ID", Prioridad.Id, SqlDbType.Int, 20)
            ' Execute
            Me._Reader = DB.ExecuteStoredProcedure()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function mapperSingle() As Prioridad
        Try
            Dim Prioridad As Prioridad = New Prioridad()
            If (Me._Reader.HasRows()) Then
                While Me._Reader.Read()
                    Double.TryParse(Me._Reader("ID"), Prioridad.Id)
                    Double.TryParse(Me._Reader("ID_PROYECTO"), Prioridad.IdProyecto)
                    Double.TryParse(Me._Reader("ID_REQUERIMIENTO"), Prioridad.IdRequerimiento)
                    Double.TryParse(Me._Reader("BENEFICIO"), Prioridad.Beneficio)
                    Double.TryParse(Me._Reader("PENALIDAD"), Prioridad.Penalidad)
                    Double.TryParse(Me._Reader("COSTO"), Prioridad.Costo)
                    Double.TryParse(Me._Reader("RIESGO"), Prioridad.Riesgo)
                End While
                Return Prioridad
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function mapperMultiple(ByVal totals As Boolean) As List(Of Prioridad)
        Try
            Dim Prioridades As List(Of Prioridad) = New List(Of Prioridad)
            If (Me._Reader.HasRows()) Then
                While Me._Reader.Read()
                    Dim Prioridad As Prioridad = New Prioridad()
                    Double.TryParse(Me._Reader("ID"), Prioridad.Id)
                    Double.TryParse(Me._Reader("ID_PROYECTO"), Prioridad.IdProyecto)
                    Double.TryParse(Me._Reader("ID_REQUERIMIENTO"), Prioridad.IdRequerimiento)
                    Double.TryParse(Me._Reader("BENEFICIO"), Prioridad.Beneficio)
                    Double.TryParse(Me._Reader("PENALIDAD"), Prioridad.Penalidad)
                    Double.TryParse(Me._Reader("COSTO"), Prioridad.Costo)
                    Double.TryParse(Me._Reader("RIESGO"), Prioridad.Riesgo)
                    Prioridades.Add(Prioridad)
                End While
                If (totals) Then
                    Dim Prioridad As Prioridad = New Prioridad()
                    For Each el In Prioridades
                        Prioridad.Beneficio += el.Beneficio
                        Prioridad.Penalidad += el.Penalidad
                        Prioridad.Costo += el.Costo
                        Prioridad.Riesgo += el.Riesgo
                    Next
                    Prioridades.Add(Prioridad)
                End If
                Return Prioridades
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class

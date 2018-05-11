Imports System.Data.SqlClient

Public Class Conexion
    Private connection As SqlConnection
    Private connStr As String
    Private command As SqlCommand
    ' Constructor
    Public Sub New()
        Me.connStr = "Data Source=.;Initial Catalog=Laboratorio1Proceso;Integrated Security=True"
    End Sub
    ' Inicializar
    Public Function Bootstrap() As Conexion
        Try
            Me.connection = New SqlConnection(Me.connStr)
            Me.connection.Open()
            Return Me
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ' Finalizacion
    Public Function CloseConnection() As Boolean
        Try
            Me.connection.Close()
            Me.connection.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ' Agregar SQL Query
    Public Function SQLQuery(ByVal commStr) As Conexion
        Try
            Me.command = New SqlCommand(commStr, Me.connection)
            Return Me
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function IsStoredProcedure() As Conexion
        Try
            Me.command.CommandType = CommandType.StoredProcedure
            Return Me
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    ' Agregar Parametros
    Public Function SQLParam(ByVal _name As String, ByVal _value As Object, ByVal _type As SqlDbType, Optional ByVal _size As Integer = Nothing) As Boolean
        Try
            Dim parameter As SqlParameter
            If (_size <> Nothing) Then
                parameter = Me.command.Parameters.Add(_name, _type, _size)
            Else
                parameter = Me.command.Parameters.Add(_name, _type)
            End If
            parameter.Value = _value
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    ' Execute
    Public Function ExecuteStoredProcedure() As SqlDataReader
        Try
            Dim reader As SqlDataReader
            Me.command.Prepare()
            reader = Me.command.ExecuteReader()
            command.CommandTimeout = 0
            Return reader
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class

Imports System.Data.SqlClient

Module MainModule
    Sub Main()
        Dim ced As String
        Do
            Console.WriteLine("Inserte Su Numero De Cedula")
            ced = Console.ReadLine()
            If (ced <> "-1") Then
                SQLRequest(ced)
            End If
            Console.Clear()
        Loop While ced <> "-1"
    End Sub
    Sub SQLRequest(ByVal Optional cedula = "")
        Dim DB As SqlConnection = New SqlConnection("Data Source=.;Initial Catalog=SQLInjection;Integrated Security=True")
        DB.Open()
        ' Here You Should Set this as parameters otherwise you can send "116810122 or Nombre != ''"
        Dim Command As SqlCommand = New SqlCommand("SELECT * FROM USUARIO WHERE ID = " + cedula, DB)
        Command.Prepare()
        Dim Reader As SqlDataReader = Command.ExecuteReader()
        If Reader.HasRows Then
            While (Reader.Read())
                Console.WriteLine("ID:" + Reader("ID"))
                Console.WriteLine("Nombre:" + Reader("Nombre"))
                Console.WriteLine("Apellido:" + Reader("Apellido"))
                Console.WriteLine("Direccion:" + Reader("Direccion"))
                Console.WriteLine("Correo:" + Reader("Correo"))
            End While
        End If
        Console.ReadKey()
    End Sub
End Module

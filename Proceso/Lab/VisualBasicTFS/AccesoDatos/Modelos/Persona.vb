Public Class Persona
    ' Atributos encapsulados
    Protected _Id As Integer
    Protected _Nombre As String
    Protected _Apellido As String
    Protected _IdProyecto As Integer
    ' Constructores
    Public Sub New()
    End Sub
    ' Get / Set
    Public Property Id() As String
        Get
            Return Me._Id
        End Get
        Set(value As String)
            Me._Id = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return Me._Nombre
        End Get
        Set(Nombre As String)
            Me._Nombre = Nombre
        End Set
    End Property
    Public Property Apellido() As String
        Get
            Return Me._Apellido
        End Get
        Set(Apellido As String)
            Me._Apellido = Apellido
        End Set
    End Property
    Public Property IdProyecto() As Integer
        Get
            Return Me._IdProyecto
        End Get
        Set(IdProyecto As Integer)
            Me._IdProyecto = IdProyecto
        End Set
    End Property
End Class

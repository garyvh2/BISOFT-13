Public Class Developer
    ' Herencia de Persona
    Inherits Persona
    ' Atributos no comunes encapsulados
    Private _Rol As String
    ' Constructores
    Public Sub New()
        MyBase.New()
    End Sub
    ' Get / Set
    Public Property Rol() As String
        Get
            Return Me._Rol
        End Get
        Set(Rol As String)
            Me._Rol = Rol
        End Set
    End Property
End Class

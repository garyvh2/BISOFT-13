Public Class Interesado
    ' Herencia de persona
    Inherits Persona
    ' Atributos no comunes encapsulados
    Private _Peso As NivelInteres
    ' Constructor
    Public Sub New()
        MyBase.New()
    End Sub
    ' Get / Set
    Public Property Peso() As NivelInteres
        Get
            Return Me._Peso
        End Get
        Set(Peso As NivelInteres)
            Me._Peso = Peso
        End Set
    End Property
End Class

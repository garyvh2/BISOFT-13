Public Class Prioridad
    ' Atributos Encapsulados (Private)
    Private _Id As Integer
    Private _IdProyecto As Integer
    Private _IdRequerimiento As Integer
    Private _Requerimiento As Requerimiento
    Private _Beneficio As Double
    Private _Penalidad As Double
    Private _Costo As Double
    Private _Riesgo As Double
    ' Constructores
    Public Sub New()
    End Sub
    ' Get / Set
    Public Property Id() As Integer
        Get
            Return Me._Id
        End Get
        Set(Id As Integer)
            Me._Id = Id
        End Set
    End Property
    Public Property NombreRequerimiento As String
        Get
            If (Me._IdRequerimiento <> Nothing) Then
                Me._Requerimiento = (New RequerimientoMapper).findById(Me._IdRequerimiento)
                Return Me._Requerimiento.Nombre
            Else
                Return ""
            End If
        End Get
        Set
        End Set
    End Property
    Public Property Beneficio() As Double
        Get
            Return Me._Beneficio
        End Get
        Set(Beneficio As Double)
            Me._Beneficio = Beneficio
        End Set
    End Property
    Public Property Penalidad() As Double
        Get
            Return Me._Penalidad
        End Get
        Set(Penalidad As Double)
            Me._Penalidad = Penalidad
        End Set
    End Property
    Public Property Costo() As Double
        Get
            Return Me._Costo
        End Get
        Set(Costo As Double)
            Me._Costo = Costo
        End Set
    End Property
    Public Property Riesgo() As Double
        Get
            Return Me._Riesgo
        End Get
        Set(Riesgo As Double)
            Me._Riesgo = Riesgo
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
    Public Property IdRequerimiento() As Integer
        Get
            Return Me._IdRequerimiento
        End Get
        Set(IdRequerimiento As Integer)
            Me._IdRequerimiento = IdRequerimiento
        End Set
    End Property
End Class

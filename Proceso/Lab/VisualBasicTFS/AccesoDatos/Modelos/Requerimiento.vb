Public Class Requerimiento
    ' Atributos Encapsulados (Private)
    Private _Id As Integer
    Private _Nombre As String
    Private _Tipo As TipoRequerimiento
    Private _idCategoria As Integer
    Private _Categoria As Categoria
    Private _IdProyecto As Integer
    Private _Proyecto As Proyecto
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
    Public Property Nombre() As String
        Get
            Return Me._Nombre
        End Get
        Set(Nombre As String)
            Me._Nombre = Nombre
        End Set
    End Property
    Public Property Tipo() As TipoRequerimiento
        Get
            Return Me._Tipo
        End Get
        Set(Tipo As TipoRequerimiento)
            Me._Tipo = Tipo
        End Set
    End Property
    Public Property IdCategoria() As Integer
        Get
            Return Me._idCategoria
        End Get
        Set(IdCategoria As Integer)
            Me._idCategoria = IdCategoria
        End Set
    End Property
    Public Property NombreCategoria As String
        Get
            If (Me._idCategoria <> Nothing) Then
                Me._Categoria = (New CategoriaMapper).findById(Me._idCategoria)
                Return Me._Categoria.Nombre
            Else
                Return ""
            End If
        End Get
        Set
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

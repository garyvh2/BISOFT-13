﻿Public Class Proyecto
    ' Atributos Encapsulados
    Private _Id As Integer
    Private _Nombre As String
    ' Constructores
    Public Sub New()
    End Sub
    ' Get / Set
    Public Property Id() As String
        Get
            Return Me._Id
        End Get
        Set(Id As String)
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
End Class
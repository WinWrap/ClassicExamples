' *** AddExtOb: example
Public Class AppObject
    Private value_ As String

    Public Property Value() As String
        Get
            Return value_
        End Get
        Set(ByVal Value As String)
            value_ = Value
        End Set
    End Property
End Class
' ***

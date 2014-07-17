' *** AddEvent: example
<ComClass()> _
Public Class AppObject
    Private value_ As String

    Public Event ValueChanged()

    Public Property Value() As String
        Get
            Return value_
        End Get
        Set(ByVal Value As String)
            value_ = Value
            Try
                RaiseEvent ValueChanged()
            Catch
            End Try
        End Set
    End Property

    'VB.NET doesn't support non-parametric default properties.
    ' If DispID 0 can't be found WinWrap Basic looks for _DefaultProperty_ instead.
    Public Property _DefaultProperty_() As String
        Get
            Return Value
        End Get
        Set(ByVal NewValue As String)
            Value = NewValue
        End Set
    End Property
End Class
' ***

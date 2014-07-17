' *** AddEvtOb: example
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
End Class
' ***

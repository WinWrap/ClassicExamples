Imports WinWrap.Basic

' *** Handler: example
<ComClass()> _
Public Class AppHandler
    Implements IDisposable
    Private handler_ As Handler
    Private value_ As String

    Friend Sub New(ByVal handler As Handler)
        MyBase.New()
        handler_ = handler
    End Sub

    Public Property Value() As String
        Get
            Return value_
        End Get
        Set(ByVal NewValue As String)
            value_ = NewValue
            If Not handler_ Is Nothing AndAlso handler_.Exists Then
                Try
                    handler_.Call()
                Catch ex As TerminatedException
                    ' do nothing
                Catch ex As Exception
                    handler_.ReportError(ex)
                End Try
            End If
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

    Sub Dispose() Implements IDisposable.Dispose
        If Not handler_ Is Nothing Then
            handler_.Dispose()
            handler_ = Nothing
        End If
    End Sub
End Class
' ***

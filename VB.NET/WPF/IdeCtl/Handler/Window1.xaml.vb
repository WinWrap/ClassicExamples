Imports WinWrap.Basic

Class Window1
    ' *** Handler: example
    Private apphandler As AppHandler
    ' ***

    Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
        MyBase.OnActivated(e)
        ' *** Handler: example
        If apphandler Is Nothing Then
            Dim handler As Handler = basicIdeCtl1.CreateHandler("Sub AppHandlerChanged")
            apphandler = New AppHandler(handler)
            basicIdeCtl1.AddExtension("AppHandler.", apphandler)
        End If
        ' ***
    End Sub
End Class

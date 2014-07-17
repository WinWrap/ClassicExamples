Class Window1
    ' *** AddEvtOb: example
    Private appobject As AppObject
    ' ***

    Protected Overrides Sub OnActivated(ByVal e As EventArgs)
        MyBase.OnActivated(e)
        ' *** AddEvtOb: example
        If appobject Is Nothing Then
            appobject = New AppObject
            basicIdeCtl1.AddExtension("#", appobject.GetType().Assembly)
            basicIdeCtl1.AddExtensionObjectWithEvents("AppObject", appobject)
        End If
        ' ***
    End Sub
End Class

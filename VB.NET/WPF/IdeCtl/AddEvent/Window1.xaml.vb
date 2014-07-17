Class Window1
    ' *** AddEvent: example
    Private appobject As AppObject
    ' ***

    Protected Overrides Sub OnActivated(ByVal e As EventArgs)
        MyBase.OnActivated(e)
        ' *** AddEvent: example
        If appobject Is Nothing Then
            appobject = New AppObject
            basicIdeCtl1.AddExtensionWithEvents(".AppObject", appobject)
        End If
        ' ***
    End Sub
End Class

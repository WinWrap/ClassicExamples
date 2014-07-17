Class Window1
    ' *** AddExt: example
    Private appobject As AppObject
    ' ***

    Protected Overrides Sub OnActivated(ByVal e As EventArgs)
        MyBase.OnActivated(e)
        ' *** AddExt: example
        If appobject Is Nothing Then
            appobject = New AppObject
            basicIdeCtl1.AddExtension(".AppObject.", appobject)
        End If
        ' ***
    End Sub
End Class

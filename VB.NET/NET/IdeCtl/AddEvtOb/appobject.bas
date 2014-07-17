'#Language "WWB.NET"

Public Sub AppObject_ValueChanged() Handles AppObject.ValueChanged
    MsgBox(AppObject.Value)
End Sub

Sub Main
    AppObject.Value = "Hello World!"
End Sub

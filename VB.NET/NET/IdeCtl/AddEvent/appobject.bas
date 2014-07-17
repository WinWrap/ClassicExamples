Option Explicit

Sub Main
    AppObject = "Hello World!"
End Sub

Public Sub AppObject_ValueChanged()
    MsgBox(AppObject)
End Sub

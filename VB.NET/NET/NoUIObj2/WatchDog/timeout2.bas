Sub Main
    On Error GoTo ErrorHandler
    WatchDog.Start 5
    MsgBox "hi"
    WatchDog.Stop
    Exit Sub
ErrorHandler:
    MsgBox Err.Description
End Sub

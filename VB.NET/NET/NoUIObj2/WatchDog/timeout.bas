Sub Main
    On Error GoTo ErrorHandler
    WatchDog.Start 5
    Wait 10
    WatchDog.Stop
    Exit Sub
ErrorHandler:
    MsgBox Err.Description
End Sub

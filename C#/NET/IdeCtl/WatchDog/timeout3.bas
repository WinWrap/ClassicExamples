Sub Main
    On Error GoTo ErrorHandler
    WatchDog.Start 5
    Begin Dialog UserDialog 320,91 ' %GRID:10,7,1,1
        Text 70,14,90,14,"Hello",.Text1
        OKButton 110,56,90,21
    End Dialog
    Dim dlg As UserDialog
    Dialog dlg
    WatchDog.Stop
    Exit Sub
ErrorHandler:
    MsgBox Err.Description
End Sub

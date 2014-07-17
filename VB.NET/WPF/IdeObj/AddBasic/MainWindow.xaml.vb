' *** AddBasic: required
Imports WinWrap.Basic
Imports WinWrap.Basic.Classic
' ***

Class MainWindow
    Private WithEvents BasicIdeObj As New BasicIdeObj

    Private Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        ' *** AddBasic: required
        ' replace with your Application/Server certificate's secret
        BasicIdeObj.Secret = New Guid("{00000000-0000-0000-0000-000000000000}")
        BasicIdeObj.Initialize()
        ' ***

        ' *** AddBasic: optional
        ' turn on tracing
        BasicIdeObj.Trace(TraceConstants.All And Not TraceConstants.QueryEvent)
        ' ***

        ' *** AddBasic: recommended
        ' manage the Basic object/control using this form
        BasicIdeObj.AttachToWindow(Me, ManageConstants.All)
        ' ***

        ' *** AddBasic: optional
        ' load the file's most recently used file list from the registry
        Dim files() As String = BasicIdeObj.FileMRU
        Dim i As Integer
        For i = 0 To files.Length - 1
            files(i) = GetSetting("ideobj", "AddBasic", "FileMRU" & i + 1)
        Next i
        BasicIdeObj.FileMRU = files
        ' ***

        ' *** AddBasic: optional
        BasicIdeObj.FileDir = System.Reflection.Assembly.GetExecutingAssembly.Location & "\..\..\.."
        ' ***
    End Sub

    Private Sub BasicIdeObj_CloseWindow(ByVal sender As Object, ByVal e As WinWrap.Basic.Classic.CloseWindowEventArgs) Handles BasicIdeObj.CloseWindow
        ' *** AddBasic: required
        ' hide the Basic Ide Object instead of minimizing it
        e.MinimizeWindow = False
        BasicIdeObj.Visible = False
        ' ***
    End Sub

    Private Sub BasicIdeObj_DebugTrace(ByVal sender As Object, ByVal e As WinWrap.Basic.Classic.TextEventArgs) Handles BasicIdeObj.DebugTrace
        ' *** AddBasic: not recommended (users are not interested in seeing this)
        ' append the trace line to the trace output shown on the form
        If txtTrace.Text.Length > 30000 Then
            txtTrace.Text = ""
        End If

        If txtTrace.Text.Length > 0 Then
            txtTrace.AppendText(vbCrLf)
        End If

        txtTrace.AppendText(e.Text)
        txtTrace.ScrollToEnd()
        ' ***
    End Sub

    Private Sub BasicIdeObj_Disconnecting(ByVal sender As Object, ByVal e As System.EventArgs) Handles BasicIdeObj.Disconnecting
        ' *** AddBasic: optional
        ' save the file menu's most recently used file list in the registry
        Dim files() As String = BasicIdeObj.FileMRU
        Dim i As Integer
        For i = 0 To files.Length - 1
            SaveSetting("ideobj", "AddBasic", "FileMRU" & i + 1, files(i))
        Next i
        ' ***
    End Sub

    Private Sub miFileExit_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miFileExit.Click
        Close()
    End Sub

    Private Sub miViewBasicIde_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miViewBasicIde.Click
        ' *** AddBasic: optional
        BasicIdeObj.CreateOverlappedWindow()
        BasicIdeObj.ActivateWindow()
        ' ***
    End Sub

    Private Sub miTestRunMsgBox_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miTestRunMsgBox.Click
        ' *** AddBasic: test
        BasicIdeObj.RunFile("""" & System.Reflection.Assembly.GetExecutingAssembly.Location & "\..\..\..\msgbox.bas""")
        ' ***
    End Sub

    Private Sub miTestRunWait_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miTestRunWait.Click
        ' *** AddBasic: test
        BasicIdeObj.RunFile("""" & System.Reflection.Assembly.GetExecutingAssembly.Location & "\..\..\..\wait.bas""")
        ' ***
    End Sub

    Private Sub miTestRuntoError_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miTestRuntoError.Click
        ' *** AddBasic: test
        BasicIdeObj.RunThis("Error 1")
        ' ***
    End Sub

    Private Sub TraceToggle(ByVal sender As System.Object)
        ' *** AddBasic: test
        Dim mi As MenuItem = CType(sender, MenuItem)
        mi.IsChecked = Not mi.IsChecked
        Dim categories As Integer
        Dim i As Integer
        For i = 0 To 5
            If miTrace.Items(i).IsChecked Then
                categories = categories Or IIf(i < 4, 1 << i, 4 << i)
            End If
        Next
        BasicIdeObj.Trace(categories)
        ' ***
    End Sub


    Private Sub miTraceAction_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miTraceAction.Click
        ' *** AddBasic: test
        TraceToggle(sender)
        ' ***
    End Sub

    Private Sub miTraceQuery_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miTraceQuery.Click
        ' *** AddBasic: test
        TraceToggle(sender)
        ' ***
    End Sub

    Private Sub miTraceActionEvent_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miTraceActionEvent.Click
        ' *** AddBasic: test
        TraceToggle(sender)
        ' ***
    End Sub

    Private Sub miTraceQueryEvent_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miTraceQueryEvent.Click
        ' *** AddBasic: test
        TraceToggle(sender)
        ' ***
    End Sub

    Private Sub miTraceInternal_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miTraceInternal.Click
        ' *** AddBasic: test
        TraceToggle(sender)
        ' ***
    End Sub

    Private Sub miTraceExecution_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miTraceExecution.Click
        ' *** AddBasic: test
        TraceToggle(sender)
        ' ***
    End Sub

    Private Sub miTraceNone_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miTraceNone.Click
        ' *** AddBasic: test
        Dim i As Integer
        For i = 0 To 5
            miTrace.Items(i).IsChecked = False
        Next

        BasicIdeObj.Trace(TraceConstants.None)
        ' ***
    End Sub

    Private Sub miTraceAll_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miTraceAll.Click
        ' *** AddBasic: test
        Dim i As Integer
        For i = 0 To 5
            miTrace.Items(i).IsChecked = True
        Next

        BasicIdeObj.Trace(TraceConstants.All)
        ' ***
    End Sub

    Private Sub miTraceClear_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles miTraceClear.Click
        ' *** AddBasic: test
        txtTrace.Text = ""
        ' ***
    End Sub
End Class

' *** AddBasic: optional
Imports WinWrap.Basic
Imports WinWrap.Basic.Classic
' ***

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' *** AddBasic: required
    Friend WithEvents BasicNoUIObj As BasicNoUIObj = New BasicNoUIObj
    ' ***

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents txtTrace As System.Windows.Forms.TextBox
    Friend WithEvents miFile As System.Windows.Forms.MenuItem
    Friend WithEvents miFileExit As System.Windows.Forms.MenuItem
    Friend WithEvents miTest As System.Windows.Forms.MenuItem
    Friend WithEvents miTestRunMsgBox As System.Windows.Forms.MenuItem
    Friend WithEvents miTestRunWait As System.Windows.Forms.MenuItem
    Friend WithEvents miTrace As System.Windows.Forms.MenuItem
    Friend WithEvents miTraceAction As System.Windows.Forms.MenuItem
    Friend WithEvents miTraceQuery As System.Windows.Forms.MenuItem
    Friend WithEvents miTraceActionEvent As System.Windows.Forms.MenuItem
    Friend WithEvents miTraceQueryEvent As System.Windows.Forms.MenuItem
    Friend WithEvents miTraceInternal As System.Windows.Forms.MenuItem
    Friend WithEvents miTraceExecution As System.Windows.Forms.MenuItem
    Friend WithEvents miTraceSep1 As System.Windows.Forms.MenuItem
    Friend WithEvents miTraceNone As System.Windows.Forms.MenuItem
    Friend WithEvents miTraceAll As System.Windows.Forms.MenuItem
    Friend WithEvents miTraceSep2 As System.Windows.Forms.MenuItem
    Friend WithEvents miTraceClear As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.miFile = New System.Windows.Forms.MenuItem
        Me.miFileExit = New System.Windows.Forms.MenuItem
        Me.miTest = New System.Windows.Forms.MenuItem
        Me.miTestRunMsgBox = New System.Windows.Forms.MenuItem
        Me.miTestRunWait = New System.Windows.Forms.MenuItem
        Me.miTrace = New System.Windows.Forms.MenuItem
        Me.miTraceAction = New System.Windows.Forms.MenuItem
        Me.miTraceQuery = New System.Windows.Forms.MenuItem
        Me.miTraceActionEvent = New System.Windows.Forms.MenuItem
        Me.miTraceQueryEvent = New System.Windows.Forms.MenuItem
        Me.miTraceInternal = New System.Windows.Forms.MenuItem
        Me.miTraceExecution = New System.Windows.Forms.MenuItem
        Me.miTraceSep1 = New System.Windows.Forms.MenuItem
        Me.miTraceNone = New System.Windows.Forms.MenuItem
        Me.miTraceAll = New System.Windows.Forms.MenuItem
        Me.miTraceSep2 = New System.Windows.Forms.MenuItem
        Me.miTraceClear = New System.Windows.Forms.MenuItem
        Me.txtTrace = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFile, Me.miTest, Me.miTrace})
        '
        'miFile
        '
        Me.miFile.Index = 0
        Me.miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFileExit})
        Me.miFile.Text = "&File"
        '
        'miFileExit
        '
        Me.miFileExit.Index = 0
        Me.miFileExit.Text = "E&xit"
        '
        'miTest
        '
        Me.miTest.Index = 1
        Me.miTest.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miTestRunMsgBox, Me.miTestRunWait})
        Me.miTest.Text = "&Test"
        '
        'miTestRunMsgBox
        '
        Me.miTestRunMsgBox.Index = 0
        Me.miTestRunMsgBox.Text = "Run MsgBox.bas"
        '
        'miTestRunWait
        '
        Me.miTestRunWait.Index = 1
        Me.miTestRunWait.Text = "Run Wait.bas"
        '
        'miTrace
        '
        Me.miTrace.Index = 2
        Me.miTrace.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miTraceAction, Me.miTraceQuery, Me.miTraceActionEvent, Me.miTraceQueryEvent, Me.miTraceInternal, Me.miTraceExecution, Me.miTraceSep1, Me.miTraceNone, Me.miTraceAll, Me.miTraceSep2, Me.miTraceClear})
        Me.miTrace.Text = "&Trace"
        '
        'miTraceAction
        '
        Me.miTraceAction.Checked = True
        Me.miTraceAction.Index = 0
        Me.miTraceAction.Text = "&Action (propert set or method call)"
        '
        'miTraceQuery
        '
        Me.miTraceQuery.Checked = True
        Me.miTraceQuery.Index = 1
        Me.miTraceQuery.Text = "&Query (property get)"
        '
        'miTraceActionEvent
        '
        Me.miTraceActionEvent.Checked = True
        Me.miTraceActionEvent.Index = 2
        Me.miTraceActionEvent.Text = "Action &Event"
        '
        'miTraceQueryEvent
        '
        Me.miTraceQueryEvent.Index = 3
        Me.miTraceQueryEvent.Text = "Query &Event"
        '
        'miTraceInternal
        '
        Me.miTraceInternal.Checked = True
        Me.miTraceInternal.Index = 4
        Me.miTraceInternal.Text = "&Internal"
        '
        'miTraceExecution
        '
        Me.miTraceExecution.Checked = True
        Me.miTraceExecution.Index = 5
        Me.miTraceExecution.Text = "&Execution"
        '
        'miTraceSep1
        '
        Me.miTraceSep1.Index = 6
        Me.miTraceSep1.Text = "-"
        '
        'miTraceNone
        '
        Me.miTraceNone.Index = 7
        Me.miTraceNone.Text = "&None"
        '
        'miTraceAll
        '
        Me.miTraceAll.Index = 8
        Me.miTraceAll.Text = "A&ll"
        '
        'miTraceSep2
        '
        Me.miTraceSep2.Index = 9
        Me.miTraceSep2.Text = "-"
        '
        'miTraceClear
        '
        Me.miTraceClear.Index = 10
        Me.miTraceClear.Text = "&Clear"
        '
        'txtTrace
        '
        Me.txtTrace.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTrace.BackColor = System.Drawing.Color.Black
        Me.txtTrace.ForeColor = System.Drawing.Color.Lime
        Me.txtTrace.Location = New System.Drawing.Point(0, 0)
        Me.txtTrace.Multiline = True
        Me.txtTrace.Name = "txtTrace"
        Me.txtTrace.ReadOnly = True
        Me.txtTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTrace.Size = New System.Drawing.Size(688, 208)
        Me.txtTrace.TabIndex = 3
        Me.txtTrace.Text = ""
        Me.txtTrace.WordWrap = False
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(688, 209)
        Me.Controls.Add(Me.txtTrace)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "VB BasicNoUIObj (NOT on a form) - AddBasic"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' *** AddBasic: required
        ' replace with your Application/Server certificate's secret
        BasicNoUIObj.Secret = New Guid("{00000000-0000-0000-0000-000000000000}")
        BasicNoUIObj.Initialize()
        ' ***

        ' *** AddBasic: optional
        ' turn on tracing
        BasicNoUIObj.Trace(TraceConstants.All And Not TraceConstants.QueryEvent)
        ' ***

        ' *** AddBasic: recommended
        ' manage the Basic object/control using this form
        BasicNoUIObj.AttachToForm(Me, ManageConstants.All)
        ' ***
    End Sub

    Private Sub BasicNoUIObj_DebugTrace(ByVal sender As Object, ByVal e As WinWrap.Basic.Classic.TextEventArgs) Handles BasicNoUIObj.DebugTrace
        ' *** AddBasic: not recommended (users are not interested in seeing this)
        ' append the trace line to the trace output shown on the form
        If txtTrace.TextLength > 30000 Then
            txtTrace.Text = ""
        End If

        txtTrace.SelectionStart = txtTrace.TextLength + 1
        If txtTrace.TextLength > 0 Then
            txtTrace.SelectedText = vbCrLf
        End If

        txtTrace.SelectedText = e.Text
        ' ***
    End Sub

    Private Sub miFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFileExit.Click
        Close()
    End Sub

    Private Sub miTestRunMsgBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miTestRunMsgBox.Click
        ' *** AddBasic: test
        BasicNoUIObj.RunFile("""" & Application.ExecutablePath() & "\..\..\msgbox.bas""")
        ' ***
    End Sub

    Private Sub miTestRunWait_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miTestRunWait.Click
        ' *** AddBasic: test
        BasicNoUIObj.RunFile("""" & Application.ExecutablePath() & "\..\..\wait.bas""")
        ' ***
    End Sub

    Private Sub TraceToggle(ByVal sender As System.Object)
        ' *** AddBasic: test
        Dim mi As MenuItem = CType(sender, MenuItem)
        mi.Checked = Not mi.Checked
        Dim categories As Integer
        Dim i As Integer
        For i = 0 To 5
            If miTrace.MenuItems(i).Checked Then
                categories = categories Or IIf(i < 4, 1 << i, 4 << i)
            End If
        Next
        BasicNoUIObj.Trace(categories)
        ' ***
    End Sub

    Private Sub miTraceAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTraceAction.Click
        ' *** AddBasic: test
        TraceToggle(sender)
        ' ***
    End Sub

    Private Sub miTraceQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTraceQuery.Click
        ' *** AddBasic: test
        TraceToggle(sender)
        ' ***
    End Sub

    Private Sub miTraceActionEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTraceActionEvent.Click
        ' *** AddBasic: test
        TraceToggle(sender)
        ' ***
    End Sub

    Private Sub miTraceQueryEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTraceQueryEvent.Click
        ' *** AddBasic: test
        TraceToggle(sender)
        ' ***
    End Sub

    Private Sub miTraceInternal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTraceInternal.Click
        ' *** AddBasic: test
        TraceToggle(sender)
        ' ***
    End Sub

    Private Sub miTraceExecution_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTraceExecution.Click
        ' *** AddBasic: test
        TraceToggle(sender)
        ' ***
    End Sub

    Private Sub miTraceNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTraceNone.Click
        ' *** AddBasic: test
        Dim i As Integer
        For i = 0 To 5
            miTrace.MenuItems(i).Checked = False
        Next

        BasicNoUIObj.Trace(TraceConstants.None)
        ' ***
    End Sub

    Private Sub miTraceAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTraceAll.Click
        ' *** AddBasic: test
        Dim i As Integer
        For i = 0 To 5
            miTrace.MenuItems(i).Checked = True
        Next

        BasicNoUIObj.Trace(TraceConstants.All)
        ' ***
    End Sub

    Private Sub miTraceClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTraceClear.Click
        ' *** AddBasic: test
        txtTrace.Text = ""
        ' ***
    End Sub
End Class

' *** AddBasic: optional
Imports WinWrap.Basic
Imports WinWrap.Basic.Classic
' ***

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' *** AddEvtOb: example
    Private WithEvents appobject As appobject = New appobject
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
    Friend WithEvents BasicIdeCtl1 As WinWrap.Basic.BasicIdeCtl
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents txtTrace As System.Windows.Forms.TextBox
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
        Me.BasicIdeCtl1 = New WinWrap.Basic.BasicIdeCtl
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
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
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.txtTrace = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'BasicIdeCtl1
        '
        Me.BasicIdeCtl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BasicIdeCtl1.BackColor = System.Drawing.Color.White
        Me.BasicIdeCtl1.ForeColor = System.Drawing.Color.Black
        Me.BasicIdeCtl1.HighlightExtension = System.Drawing.Color.DarkBlue
        Me.BasicIdeCtl1.HighlightReserved = System.Drawing.Color.Blue
        Me.BasicIdeCtl1.Location = New System.Drawing.Point(0, 0)
        Me.BasicIdeCtl1.Name = "BasicIdeCtl1"
        Me.BasicIdeCtl1.SelBackColor = System.Drawing.Color.Aqua
        Me.BasicIdeCtl1.SelForeColor = System.Drawing.Color.Black
        Me.BasicIdeCtl1.Size = New System.Drawing.Size(552, 280)
        Me.BasicIdeCtl1.TabIndex = 0
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miTrace})
        '
        'miTrace
        '
        Me.miTrace.Index = 0
        Me.miTrace.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miTraceAction, Me.miTraceQuery, Me.miTraceActionEvent, Me.miTraceQueryEvent, Me.miTraceInternal, Me.miTraceExecution, Me.miTraceSep1, Me.miTraceNone, Me.miTraceAll, Me.miTraceSep2, Me.miTraceClear})
        Me.miTrace.MergeOrder = 45
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
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 286)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(552, 3)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'txtTrace
        '
        Me.txtTrace.BackColor = System.Drawing.Color.Black
        Me.txtTrace.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtTrace.ForeColor = System.Drawing.Color.Lime
        Me.txtTrace.Location = New System.Drawing.Point(0, 289)
        Me.txtTrace.Multiline = True
        Me.txtTrace.Name = "txtTrace"
        Me.txtTrace.ReadOnly = True
        Me.txtTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTrace.Size = New System.Drawing.Size(552, 152)
        Me.txtTrace.TabIndex = 2
        Me.txtTrace.WordWrap = False
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(552, 441)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.BasicIdeCtl1)
        Me.Controls.Add(Me.txtTrace)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "VB BasicIdeCtl - AddEvtOb"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' *** AddBasic: optional
        ' turn on tracing
        BasicIdeCtl1.Trace(TraceConstants.All And Not TraceConstants.QueryEvent)
        ' ***

        ' *** AddEvtOb: example
        BasicIdeCtl1.AddExtension("#", appobject.GetType().Assembly)
        BasicIdeCtl1.AddExtensionObjectWithEvents("AppObject", appobject)
        ' ***

        ' *** AddBasic: optional
        ' load the file's most recently used file list from the registry
        Dim files() As String = BasicIdeCtl1.FileMRU
        Dim i As Integer
        For i = 0 To files.Length - 1
            files(i) = GetSetting("idectl", "AddEvtOb", "FileMRU" & i + 1)
        Next i
        BasicIdeCtl1.FileMRU = files
        ' ***

		' *** AddBasic: optional
		basicIdeCtl1.FileDir = Application.ExecutablePath & "\..\.."
		' ***
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        BasicIdeCtl1.Height = Splitter1.Top
    End Sub

    Private Sub BasicIdeCtl1_DebugTrace(ByVal sender As Object, ByVal e As WinWrap.Basic.Classic.TextEventArgs) Handles BasicIdeCtl1.DebugTrace
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

    Private Sub BasicIdeCtl1_Disconnecting(ByVal sender As Object, ByVal e As System.EventArgs) Handles BasicIdeCtl1.Disconnecting
        ' *** AddBasic: optional
        ' save the file menu's most recently used file list in the registry
        Dim files() As String = BasicIdeCtl1.FileMRU
        Dim i As Integer
        For i = 0 To files.Length - 1
            SaveSetting("idectl", "AddEvtOb", "FileMRU" & i + 1, files(i))
        Next i
        ' ***
    End Sub

#Region " AddBasic: test "

    Private Sub Splitter1_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles Splitter1.SplitterMoved
        BasicIdeCtl1.Height = Splitter1.Top
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
        BasicIdeCtl1.Trace(categories)
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

        BasicIdeCtl1.Trace(TraceConstants.None)
        ' ***
    End Sub

    Private Sub miTraceAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTraceAll.Click
        ' *** AddBasic: test
        Dim i As Integer
        For i = 0 To 5
            miTrace.MenuItems(i).Checked = True
        Next

        BasicIdeCtl1.Trace(TraceConstants.All)
        ' ***
    End Sub

    Private Sub miTraceClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTraceClear.Click
        ' *** AddBasic: test
        txtTrace.Text = ""
        ' ***
    End Sub

#End Region
End Class

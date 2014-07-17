Imports Microsoft.Win32
' *** Threads: required
Imports WinWrap.Basic
Imports WinWrap.Basic.Classic
' ***

Public Class Form1
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents txtTrace As System.Windows.Forms.TextBox
    Friend WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents miFile As System.Windows.Forms.MenuItem
    Friend WithEvents miFileRun As System.Windows.Forms.MenuItem
    Friend WithEvents miFileSep2 As System.Windows.Forms.MenuItem
    Friend WithEvents miFileExit As System.Windows.Forms.MenuItem
    Friend WithEvents timer1 As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.txtTrace = New System.Windows.Forms.TextBox
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.miFile = New System.Windows.Forms.MenuItem
        Me.miFileRun = New System.Windows.Forms.MenuItem
        Me.miFileSep2 = New System.Windows.Forms.MenuItem
        Me.miFileExit = New System.Windows.Forms.MenuItem
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
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
        Me.txtTrace.Size = New System.Drawing.Size(712, 234)
        Me.txtTrace.TabIndex = 3
        Me.txtTrace.Text = ""
        Me.txtTrace.WordWrap = False
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFile})
        '
        'miFile
        '
        Me.miFile.Index = 0
        Me.miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFileRun, Me.miFileSep2, Me.miFileExit})
        Me.miFile.Text = "&File"
        '
        'miFileRun
        '
        Me.miFileRun.Index = 0
        Me.miFileRun.Text = "&Run test1.bas"
        '
        'miFileSep2
        '
        Me.miFileSep2.Index = 1
        Me.miFileSep2.Text = "-"
        '
        'miFileExit
        '
        Me.miFileExit.Index = 2
        Me.miFileExit.Text = "E&xit"
        '
        'timer1
        '
        Me.timer1.Enabled = True
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(712, 233)
        Me.Controls.Add(Me.txtTrace)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "VB BasicIdeObj - Threads"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' *** Threads: required
    Private WithEvents basicthreadcollection_ As BasicThreadCollection = New BasicThreadCollection
    ' ***

    ' *** Threads: optional
    Private tracedata_ As ArrayList = New ArrayList
    ' ***

    Private Sub AddDebugTraceData()
        ' *** Threads: optional
        ' This method executes in this form's thread
        ' write the trace data the debug output
        Dim n As Integer = tracedata_.Count
        If n = 0 Then Exit Sub

        Dim tracedata As Array = Array.CreateInstance(GetType(String), n)
        tracedata_.CopyTo(0, tracedata, 0, n)
        tracedata_.RemoveRange(0, n)
        Dim s As String = String.Join(vbCrLf, tracedata)

        ' don't add to txtTrace if the form has been destroyed
        If Not IsHandleCreated Then Exit Sub

        ' append the trace line to the trace output shown on the form
        If txtTrace.TextLength > 30000 Then
            txtTrace.Text = ""
        End If

        txtTrace.SelectionStart = txtTrace.TextLength + 1
        If txtTrace.TextLength > 0 Then
            txtTrace.SelectedText = vbCrLf
        End If

        txtTrace.SelectedText = s
        ' ***
    End Sub

    Private Sub basicthreadcollection__DebugTrace(ByVal sender As Object, ByVal e As WinWrap.Basic.Classic.TextEventArgs) Handles basicthreadcollection_.DebugTrace
        ' *** Threads: optional
        ' This method executes in the IBasicThread's thread
        ' add trace line to the debug output
        tracedata_.Add(e.Text)
        ' ***
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        ' *** Threads: optional
        AddDebugTraceData()
        ' ***
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' *** Threads: required
        ' Kill all basic thread, cancel close if not successful
        e.Cancel = Not basicthreadcollection_.KillAll()
        ' ***
    End Sub

    Private Sub miFileRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miFileRun.Click
        ' *** Threads: example
        Try
            Basic.Spawn(Me, basicthreadcollection_, Application.ExecutablePath + "\..\..\" + "test1.bas")
        Catch ex As Exception
            MessageBox.Show(Me, ex.ToString())
        End Try
        ' ***
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timer1.Tick
        ' *** Threads: optional
        AddDebugTraceData()
        ' ***
    End Sub

    Private Sub miFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFileExit.Click
        ' *** Threads: example
        Close()
        ' ***
    End Sub
End Class

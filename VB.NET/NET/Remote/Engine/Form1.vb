' *** AddBasic: optional
Imports WinWrap.Basic
Imports WinWrap.Basic.Classic
' ***
Imports System.Net
Imports System.Net.Sockets

Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim m_port As Integer = 1000
    Dim m_listenSocket As Socket
    Dim m_conns As New ArrayList

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
    Friend WithEvents BasicNoUIObj1 As WinWrap.Basic.BasicNoUIObj
    Friend WithEvents miFile As System.Windows.Forms.MenuItem
    Friend WithEvents miFileExit As System.Windows.Forms.MenuItem
    Friend WithEvents miTest As System.Windows.Forms.MenuItem
    Private WithEvents miTestRunMsgBox As System.Windows.Forms.MenuItem
    Private WithEvents miRunWait As System.Windows.Forms.MenuItem
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents txtSynchronizing As System.Windows.Forms.TextBox
    Private WithEvents txtSynchronize As System.Windows.Forms.TextBox
    Private WithEvents txtPort As System.Windows.Forms.TextBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents btnEnd As System.Windows.Forms.Button
    Private WithEvents btnPause As System.Windows.Forms.Button
    Private WithEvents btnRun As System.Windows.Forms.Button
    Private WithEvents lblInfo As System.Windows.Forms.Label
    Private WithEvents chkAllowRemoteControl As System.Windows.Forms.CheckBox
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents lblAddress As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.BasicNoUIObj1 = New WinWrap.Basic.BasicNoUIObj(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.miFile = New System.Windows.Forms.MenuItem
        Me.miFileExit = New System.Windows.Forms.MenuItem
        Me.miTest = New System.Windows.Forms.MenuItem
        Me.miTestRunMsgBox = New System.Windows.Forms.MenuItem
        Me.miRunWait = New System.Windows.Forms.MenuItem
        Me.label1 = New System.Windows.Forms.Label
        Me.txtSynchronizing = New System.Windows.Forms.TextBox
        Me.txtSynchronize = New System.Windows.Forms.TextBox
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.btnEnd = New System.Windows.Forms.Button
        Me.btnPause = New System.Windows.Forms.Button
        Me.btnRun = New System.Windows.Forms.Button
        Me.lblInfo = New System.Windows.Forms.Label
        Me.chkAllowRemoteControl = New System.Windows.Forms.CheckBox
        Me.lblAddress = New System.Windows.Forms.Label
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BasicNoUIObj1
        '
        Me.BasicNoUIObj1.LargeIcon = CType(resources.GetObject("BasicNoUIObj1.LargeIcon"), System.Drawing.Icon)
        Me.BasicNoUIObj1.Secret = New System.Guid("00000000-0000-0000-0000-000000000000")
        Me.BasicNoUIObj1.SmallIcon = CType(resources.GetObject("BasicNoUIObj1.SmallIcon"), System.Drawing.Icon)
        Me.BasicNoUIObj1.TaskbarIcon = CType(resources.GetObject("BasicNoUIObj1.TaskbarIcon"), System.Drawing.Icon)
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFile, Me.miTest})
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
        Me.miTest.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miTestRunMsgBox, Me.miRunWait})
        Me.miTest.Text = "&Test"
        '
        'miTestRunMsgBox
        '
        Me.miTestRunMsgBox.Index = 0
        Me.miTestRunMsgBox.Text = "Run MsgBox.bas"
        '
        'miRunWait
        '
        Me.miRunWait.Index = 1
        Me.miRunWait.Text = "Run Wait.bas"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(436, 4)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(32, 16)
        Me.label1.TabIndex = 17
        Me.label1.Text = "Port"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'txtSynchronizing
        '
        Me.txtSynchronizing.Location = New System.Drawing.Point(8, 16)
        Me.txtSynchronizing.Multiline = True
        Me.txtSynchronizing.Name = "txtSynchronizing"
        Me.txtSynchronizing.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSynchronizing.Size = New System.Drawing.Size(504, 80)
        Me.txtSynchronizing.TabIndex = 0
        '
        'txtSynchronize
        '
        Me.txtSynchronize.Location = New System.Drawing.Point(8, 16)
        Me.txtSynchronize.Multiline = True
        Me.txtSynchronize.Name = "txtSynchronize"
        Me.txtSynchronize.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSynchronize.Size = New System.Drawing.Size(504, 80)
        Me.txtSynchronize.TabIndex = 0
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(468, 4)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(64, 20)
        Me.txtPort.TabIndex = 16
        Me.txtPort.Text = "1000"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.txtSynchronize)
        Me.groupBox1.Location = New System.Drawing.Point(12, 84)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(520, 104)
        Me.groupBox1.TabIndex = 13
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Synchronize (command from remote)"
        '
        'btnEnd
        '
        Me.btnEnd.Enabled = False
        Me.btnEnd.Location = New System.Drawing.Point(188, 52)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(48, 24)
        Me.btnEnd.TabIndex = 12
        Me.btnEnd.Text = "End"
        '
        'btnPause
        '
        Me.btnPause.Enabled = False
        Me.btnPause.Location = New System.Drawing.Point(124, 52)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(48, 24)
        Me.btnPause.TabIndex = 11
        Me.btnPause.Text = "Pause"
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(60, 52)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(48, 24)
        Me.btnRun.TabIndex = 10
        Me.btnRun.Text = "Run"
        '
        'lblInfo
        '
        Me.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblInfo.Location = New System.Drawing.Point(12, 28)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(520, 16)
        Me.lblInfo.TabIndex = 9
        '
        'chkAllowRemoteControl
        '
        Me.chkAllowRemoteControl.AutoCheck = False
        Me.chkAllowRemoteControl.Location = New System.Drawing.Point(12, 12)
        Me.chkAllowRemoteControl.Name = "chkAllowRemoteControl"
        Me.chkAllowRemoteControl.Size = New System.Drawing.Size(160, 16)
        Me.chkAllowRemoteControl.TabIndex = 14
        Me.chkAllowRemoteControl.Text = "Allow Remote Control"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.txtSynchronizing)
        Me.groupBox2.Location = New System.Drawing.Point(12, 196)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(520, 104)
        Me.groupBox2.TabIndex = 15
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Synchronizing (response to remote)"
        ' 
        ' lblAddress
        ' 
        Me.lblAddress.Location = New System.Drawing.Point(168, 8)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(248, 16)
        Me.lblAddress.TabIndex = 9
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(544, 311)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.btnEnd)
        Me.Controls.Add(Me.btnPause)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.chkAllowRemoteControl)
        Me.Controls.Add(Me.groupBox2)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "VB BasicNoUIObj (on a form) - Remote"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Shared Function GetAddr() As String
        Dim addr As String = ""
        ' Then using host name, get the IP address list..
        Dim ipEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim ipaddrs() As IPAddress = ipEntry.AddressList

        For Each ipaddr As IPAddress In ipaddrs
            If addr <> "" Then addr &= " "

            addr &= ipaddr.ToString()
        Next

        Return addr
    End Function

    Private Sub Listen_Callback(ByVal ar As IAsyncResult)
        Dim s As Socket = DirectCast(ar.AsyncState, Socket)
        Dim s2 As Socket = s.EndAccept(ar)
        Dim conn As Connection = New Connection(s2, New ReceivedDataDelegate(AddressOf ReceivedDataAsync))
        If m_conns.Count = 0 Then
            BasicNoUIObj1.Synchronized = True
        End If

        m_conns.Add(conn)

        m_listenSocket.BeginAccept(AddressOf Listen_Callback, m_listenSocket)
    End Sub

    Public Sub ReceivedData(ByVal conn As Connection, ByVal data As String)
        txtSynchronize.Text = data
        BasicNoUIObj1.Synchronize(data, conn.Id)
    End Sub

    Public Sub ReceivedDataAsync(ByVal conn As Connection, ByVal data As String)
        BeginInvoke(New ReceivedDataDelegate(AddressOf ReceivedData), New Object() {conn, data})
    End Sub

    Private Sub StartListening()
        If m_listenSocket Is Nothing Then
            Dim skt As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            skt.Blocking = False
            Try
                Dim ep As IPEndPoint = New IPEndPoint(IPAddress.Any, m_port)
                skt.Bind(ep)
                skt.Listen(5)
                skt.BeginAccept(New AsyncCallback(AddressOf Listen_Callback), skt)
                m_listenSocket = skt
            Catch ex As Exception
                skt.Close()
                MessageBox.Show(ex.Message)
                Return
            End Try

            chkAllowRemoteControl.Checked = True
            txtPort.Enabled = False

            lblInfo.Text = GetAddr()
        End If
    End Sub

    Private Sub StopListening()
        If m_listenSocket IsNot Nothing Then
            While m_conns.Count > 0
                Dim conn As Connection = DirectCast(m_conns(0), Connection)
                conn.Close()
                m_conns.Remove(conn)
            End While

            m_listenSocket.Close()
            m_listenSocket = Nothing

            chkAllowRemoteControl.Checked = False
            txtPort.Enabled = True
            BasicNoUIObj1.Synchronized = False

            lblInfo.Text = "Not listening."
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' *** AddBasic: required
        ' set your Application/Server certificate's secret first
        BasicNoUIObj1.Initialize()
        ' ***

        ' *** AddBasic: optional
        ' turn on tracing
        BasicNoUIObj1.Trace(TraceConstants.All And Not TraceConstants.QueryEvent)
        ' ***

        ' *** AddBasic: recommended
        ' manage the Basic object/control using this form
        BasicNoUIObj1.AttachToForm(Me, ManageConstants.All)
        ' ***

        lblAddress.Text = GetAddr()
        lblInfo.Text = "Idle."

        BeginInvoke(New MethodInvoker(AddressOf StartListening))
    End Sub

    Private Sub miFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFileExit.Click
        Close()
    End Sub

    Private Sub miTestRunMsgBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTestRunMsgBox.Click
        BasicNoUIObj1.RunFile("""" & Application.ExecutablePath & "\..\..\msgbox.bas""")
    End Sub

    Private Sub miRunWait_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRunWait.Click
        BasicNoUIObj1.RunFile("""" & Application.ExecutablePath & "\..\..\wait.bas""")
    End Sub
    Private Sub basicNoUIObj1_DebugPrint(ByVal sender As Object, ByVal e As WinWrap.Basic.Classic.TextEventArgs) Handles BasicNoUIObj1.DebugPrint
        lblInfo.Text = e.Text
    End Sub

    Private Sub basicNoUIObj1_Begin(ByVal sender As Object, ByVal e As System.EventArgs) Handles BasicNoUIObj1.Begin
        lblInfo.Text = "Running..."
        btnRun.Enabled = False
        btnPause.Enabled = True
        btnEnd.Enabled = True
    End Sub

    Private Sub basicNoUIObj1_End(ByVal sender As Object, ByVal e As System.EventArgs) Handles BasicNoUIObj1.End
        lblInfo.Text = "Idle."
        btnRun.Enabled = True
        btnPause.Enabled = False
        btnEnd.Enabled = False
    End Sub

    Private Sub basicNoUIObj1_Pause_(ByVal sender As Object, ByVal e As System.EventArgs) Handles BasicNoUIObj1.Pause_
        lblInfo.Text = "Paused."
        btnRun.Enabled = True
        btnPause.Enabled = False
        btnEnd.Enabled = True
    End Sub

    Private Sub basicNoUIObj1_Resume(ByVal sender As Object, ByVal e As System.EventArgs) Handles BasicNoUIObj1.Resume
        lblInfo.Text = "Resuming..."
        btnRun.Enabled = False
        btnPause.Enabled = True
        btnEnd.Enabled = True
    End Sub

    Private Sub BasicNoUIObj1_Synchronizing(ByVal sender As Object, ByVal e As WinWrap.Basic.Classic.SynchronizingEventArgs) Handles BasicNoUIObj1.Synchronizing
        txtSynchronizing.Text = e.Param
        ' send to all connections 
        For i As Integer = 0 To m_conns.Count - 1
            Dim conn As Connection = DirectCast(m_conns(i), Connection)
            If conn.Connected Then
                If e.Id = -1 OrElse e.Id = conn.Id Then
                    conn.Send(e.Param)
                End If
            Else
                m_conns.Remove(conn)
                i -= 1
            End If
        Next

        If m_conns.Count = 0 Then
            BasicNoUIObj1.Synchronized = False
            lblInfo.Text = "All connections closed."
        End If
    End Sub

    Private Sub chkAllowRemoteControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAllowRemoteControl.Click
        If m_listenSocket IsNot Nothing Then
            StopListening()
        Else
            StartListening()
        End If
    End Sub

    Private Sub btnRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRun.Click
        If BasicNoUIObj1.Pause Then
            BasicNoUIObj1.Pause = False
        Else
            BasicNoUIObj1.Run = True
        End If
    End Sub

    Private Sub btnPause_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPause.Click
        BasicNoUIObj1.Pause = True
    End Sub

    Private Sub btnEnd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnd.Click
        BasicNoUIObj1.Run = False
    End Sub

    Private Sub txtPort_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPort.TextChanged
        m_port = Integer.Parse(txtPort.Text)
    End Sub
End Class

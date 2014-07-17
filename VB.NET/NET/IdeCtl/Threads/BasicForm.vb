Imports System.Threading
' *** Threads: required
Imports WinWrap.Basic
Imports WinWrap.Basic.Classic
' ***

Public Class BasicForm
    Inherits System.Windows.Forms.Form

    ' *** Thread: required
    Implements IBasicThread
    Private basicthreadcollection_ As IBasicThreadCollection
    ' ***

    Public Sub New(ByVal basicthreadcollection As IBasicThreadCollection)
        MyBase.New()

        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        '
        ' TODO: Add any constructor code after InitializeComponent call
        '

        ' *** Threads: required
        basicthreadcollection_ = BasicThreadCollection
        ' ***
    End Sub

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
    Friend WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents basicIdeCtl1 As WinWrap.Basic.BasicIdeCtl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.basicIdeCtl1 = New WinWrap.Basic.BasicIdeCtl
        Me.SuspendLayout()
        '
        'basicIdeCtl1
        '
        Me.basicIdeCtl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.basicIdeCtl1.BackColor = System.Drawing.Color.White
        Me.basicIdeCtl1.ForeColor = System.Drawing.Color.Black
        Me.basicIdeCtl1.Location = New System.Drawing.Point(0, 0)
        Me.basicIdeCtl1.Name = "basicIdeCtl1"
        Me.basicIdeCtl1.SelBackColor = System.Drawing.Color.Aqua
        Me.basicIdeCtl1.SelForeColor = System.Drawing.Color.White
        Me.basicIdeCtl1.Size = New System.Drawing.Size(560, 325)
        Me.basicIdeCtl1.TabIndex = 1
        '
        'BasicForm
        '
        Me.ClientSize = New System.Drawing.Size(560, 325)
        Me.Controls.Add(Me.basicIdeCtl1)
        Me.Menu = Me.mainMenu1
        Me.Name = "BasicForm"
        Me.Text = "VB BasicIdeCtl - Threads"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' *** Threads: example
    ' Implement the Spawn and ShowIDE WinWrap Basic language instructions
    <ComClass()> _
    Public Class BasicObject
        Private form1_ As BasicForm

        Friend Sub New(ByVal form1 As BasicForm)
            form1_ = form1
        End Sub

        Public Sub ShowIDE()
            form1_.ShowIDE()
        End Sub

        Public Sub Spawn(ByVal FileName As String)
            form1_.Spawn(FileName)
        End Sub
    End Class
    ' ***

    Friend Sub ShowIDE()
        ' *** Thread: test
        ' Help implement the ShowIDE WinWrap Basic instruction
        Me.Activate()
        ' ***
    End Sub

    Friend Sub Spawn(ByVal FileName As String)
        ' *** Thread: test
        ' Help implement the Spawn WinWrap Basic instruction
        Spawn(basicthreadcollection_, FileName)
        ' ***
    End Sub

    ' *** Threads: example
    Private started_ As AutoResetEvent = New AutoResetEvent(False)
    ' ***

    Public Shared Sub Spawn(ByVal basicthreadcollection As IBasicThreadCollection, ByVal FileName As String)
        ' *** Threads: example
        ' Create a new BasicForm (contains a BasicIdeCtl control)
        Dim form1 As BasicForm = New BasicForm(basicthreadcollection)
        ' Attach the new form to the collection and use it's IBasicThread implementation
        form1.basicIdeCtl1.AttachBasicThread(form1)
        ' Create a new thread
        Dim Thread As Thread = New Thread(AddressOf form1.ThreadProc)
        ' Must be a single threaded apartment
        Thread.SetApartmentState(ApartmentState.STA)
        ' Start the thread
        Thread.Start()
        ' Run the script in the new thread
        form1.Spawn_(FileName)
        ' ***
    End Sub

    ' *** Threads: example
    Private Delegate Function Spawn1Delegate(ByVal FileName As String) As Boolean
    Private Delegate Sub Spawn2Delegate()
    ' ***

    Friend Sub Spawn_(ByVal FileName As String)
        ' *** Threads: example
        ' Allow a new BasicForm to be created without running a script
        If FileName = Nothing Then Exit Sub

        ' Wait for the new thread to start
        If Not started_.WaitOne(10000, False) Then
            Throw New Exception("Spawn failed.")
        End If

        ' Invoke Spawn1 in the new thread
        Dim d1 As New Spawn1Delegate(AddressOf Spawn1)
        Dim args(0) As Object
        args(0) = FileName
        If Not Invoke(d1, args) Then
            Throw New Exception("Spawn failed.")
        End If

        ' Start Spawn2 in the new thread
        Dim d2 As New Spawn2Delegate(AddressOf Spawn2)
        BeginInvoke(d2, Nothing)
        ' ***
    End Sub

    Private Function Spawn1(ByVal StartFileName As String) As Boolean
        ' *** Threads: example
        ' Set the current file name so that Spawn2 can start the script
        Dim OldFileName As String = basicIdeCtl1.FileName
        basicIdeCtl1.FileName = StartFileName
        ' Return true if the script exists
        Return basicIdeCtl1.FileName <> OldFileName
        ' ***
    End Function

    Private Sub Spawn2()
        ' *** Threads: example
        ' Start the script execution
        basicIdeCtl1.Run = True
        ' ***
    End Sub

    Private Sub ThreadProc()
        ' *** Threads: required
        ' Add this IBasicThread object to the collection
        basicthreadcollection_.AddBasicThread(Me)
        ' Run this form's message loop
        Application.Run(Me)
        ' Remove this IBasicThread object from the collection
        basicthreadcollection_.RemoveBasicThread(Me)
        ' ***
    End Sub

    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        ' *** Thread: example
        ' Signal that the form's thread is ready
        started_.Set()
        ' ***
        MyBase.OnHandleCreated(e)
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        ' *** AddBasic: optional
        ' turn on tracing
        basicIdeCtl1.Trace(TraceConstants.All And Not TraceConstants.QueryEvent)
        ' ***

        ' *** Threads: example
        ' Add Spawn and ShowIDE instructions to WinWrap Basic language
        basicIdeCtl1.AddExtension("-", New BasicObject(Me))
        ' ***

        ' *** AddBasic: optional
        Dim files() As String = basicIdeCtl1.FileMRU
        Dim i As Integer
        For i = 0 To files.Length - 1
            files(i) = GetSetting("idectl", "Threads", "FileMRU" & i + 1)
        Next i
        basicIdeCtl1.FileMRU = files
        ' ***

        ' *** AddBasic: optional
        basicIdeCtl1.FileDir = Application.ExecutablePath + "\..\..\.."
        ' ***
    End Sub

    Private Sub basicIdeCtl1_Disconnecting(ByVal sender As Object, ByVal e As System.EventArgs) Handles basicIdeCtl1.Disconnecting
        ' *** AddBasic: optional
        ' save the file menu's most recently used file list in the registry
        Dim files() As String = basicIdeCtl1.FileMRU
        Dim i As Integer
        For i = 0 To files.Length - 1
            SaveSetting("idectl", "Threads", "FileMRU" & i + 1, files(i))
        Next i
        ' ***
    End Sub

#Region "IBasicThread Members"
    Public ReadOnly Property BasicThreadCollection() As WinWrap.Basic.IBasicThreadCollection Implements WinWrap.Basic.IBasicThread.BasicThreadCollection
        Get
            SyncLock Me
                Return basicthreadcollection_
            End SyncLock
        End Get
    End Property

    Private inkill_ As Boolean

    Public ReadOnly Property InKill() As Boolean Implements WinWrap.Basic.IBasicThread.InKill
        Get
            SyncLock Me
                Return inkill_
            End SyncLock
        End Get
    End Property

    Public ReadOnly Property IsAlive() As Boolean Implements WinWrap.Basic.IBasicThread.IsAlive
        Get
            SyncLock Me
                Return IsHandleCreated
            End SyncLock
        End Get
    End Property

    Private Delegate Sub CloseDelegate()

    Public Function Kill() As Boolean Implements WinWrap.Basic.IBasicThread.Kill
        If Not IsAlive Then Return True

        If Not InvokeRequired Then
            Close()
            Return True
        End If

        SyncLock Me
            If inkill_ Then Return False

            inkill_ = True
        End SyncLock

        Dim d As New CloseDelegate(AddressOf Close)
        Invoke(d, Nothing)

        SyncLock Me
            inkill_ = False
        End SyncLock

        Return Not IsAlive
    End Function
#End Region
End Class

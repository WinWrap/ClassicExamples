Imports System.Threading
' *** Threads: required
Imports WinWrap.Basic
Imports WinWrap.Basic.Classic
' ***

Public Class Basic
    Inherits BasicIdeObj

#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    ' *** Threads: example
    ' Implement the Spawn and ShowIDE WinWrap Basic language instructions
    <ComClass()> _
    Public Class BasicObject
        Private basic_ As Basic

        Friend Sub New(ByVal basic As Basic)
            basic_ = basic
        End Sub

        Public Sub ShowIDE()
            basic_.ShowIDE()
        End Sub

        Public Sub Spawn(ByVal FileName As String)
            basic_.Spawn(FileName)
        End Sub
    End Class
    ' ***

    ' *** Thread: test
    Private form_ As Form
    ' ***

    Public Sub New(ByVal form As Form)
        ' *** Thread: test
        form_ = form
        ' ***
    End Sub

    Friend Sub ShowIDE()
        ' *** Thread: test
        ' Help implement the ShowIDE WinWrap Basic instruction
        CreateOverlappedWindow()
        ActivateWindow()
        ' ***
    End Sub

    Friend Sub Spawn(ByVal FileName As String)
        ' *** Thread: test
        ' Help implement the Spawn WinWrap Basic instruction
        Spawn(form_, GetBasicThread().BasicThreadCollection, FileName)
        ' ***
    End Sub

    Public Shared Sub Spawn(ByVal form As Form, ByVal basicthreadcollection As IBasicThreadCollection, ByVal FileName As String)
        ' *** Threads: example
        ' Create a new Basic (BasicIdeObj) object
        Dim basic As Basic = New Basic(form)
        ' Begin a new Basic thread and run the script in the new thread
        basic.Spawn_(basicthreadcollection, FileName)
        ' ***
    End Sub

    ' *** Threads: example
    Private Delegate Function Spawn1Delegate(ByVal FileName As String) As Boolean
    Private Delegate Sub Spawn2Delegate()
    ' ***

    Friend Sub Spawn_(ByVal basicthreadcollection As IBasicThreadCollection, ByVal FileName As String)
        ' *** Threads: example
        ' Begin a new Basic thread and add it to the collection
        BeginBasicThread(basicthreadcollection)

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
        ' *** AddBasic: required
        Initialize()
        ' ***

        ' *** AddBasic: optional
        ' turn on tracing
        Trace(TraceConstants.All)
        ' ***

        ' *** AddBasic: recommended
        ' manage the Basic object/control using this form
        AttachToForm(form_, ManageConstants.All)
        ' ***

        ' *** Threads: example
        ' Add Spawn and ShowIDE instructions to WinWrap Basic language
        AddExtension("-", New BasicObject(Me))
        ' ***

        ' *** AddBasic: optional
        Dim files() As String = FileMRU
        Dim i As Integer
        For i = 0 To files.Length - 1
            files(i) = GetSetting("ideobj", "Threads", "FileMRU" & i + 1)
        Next i
        FileMRU = files
        ' ***

        ' *** AddBasic: optional
        FileDir = Application.ExecutablePath + "\..\.."
        ' ***

        ' *** Threads: example
        ' Set the current file name so that Spawn2 can start the script
        Dim OldFileName As String = FileName
        FileName = StartFileName
        ' Return true if the script exists
        Return FileName <> OldFileName
        ' ***
    End Function

    Private Sub Spawn2()
        ' *** Threads: example
        ' Start the script execution
        Run = True
        ' ***
    End Sub

    Protected Overrides Sub OnDisconnecting(ByVal e As System.EventArgs)
        ' *** AddBasic: optional
        ' save the file menu's most recently used file list in the registry
        Dim files() As String = FileMRU
        Dim i As Integer
        For i = 0 To files.Length - 1
            SaveSetting("ideobj", "Threads", "FileMRU" & i + 1, files(i))
        Next i
        ' ***
    End Sub
End Class

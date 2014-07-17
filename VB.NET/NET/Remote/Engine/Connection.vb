Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Delegate Sub ReceivedDataDelegate(ByVal conn As Connection, ByVal data As String)

''' <summary> 
''' Summary description for Connection. 
''' </summary> 
Public Class Connection
    Private Class StateObject
        Public buffer As Byte()

        Public Sub New(ByVal bufsize As Integer)
            buffer = New Byte(bufsize - 1) {}
        End Sub
    End Class

    Private m_socket As Socket
    Private m_id As Integer
    Private m_recvDelegate As ReceivedDataDelegate
    Private m_sbRecv As New StringBuilder()

    Private Shared s_id As Integer

    Public ReadOnly Property Socket() As Socket
        Get
            Return m_socket
        End Get
    End Property

    Public Sub New(ByVal socket As Socket, ByVal recvDelegate As ReceivedDataDelegate)
        m_id = s_id
        If System.Threading.Interlocked.Increment(s_id) < 0 Then
            s_id = 0
        End If

        m_socket = socket
        m_recvDelegate = recvDelegate
        Recv_Start()
    End Sub

    Public Sub Close()
        Try
            m_socket.Close()
        Catch
        End Try
    End Sub

    Public ReadOnly Property Connected() As Boolean
        Get
            Return m_socket.Connected
        End Get
    End Property

    Public ReadOnly Property Id() As Integer
        Get
            Return m_id
        End Get
    End Property

    Public Sub Recv_Start()
        Dim so As New StateObject(&H1000)
        m_socket.BeginReceive(so.buffer, 0, so.buffer.Length, 0, New AsyncCallback(AddressOf Recv_Callback), so)
    End Sub

    Public Sub Send(ByVal data As String)
        If data Is Nothing OrElse data = "" Then
            Exit Sub
        End If

        Dim encoding As New ASCIIEncoding()
        Dim send As Integer = encoding.GetByteCount(data)
        Dim so As New StateObject(send + 1)
        encoding.GetBytes(data, 0, send, so.buffer, 0)
        so.buffer(send) = &H1A
        m_socket.BeginSend(so.buffer, 0, so.buffer.Length, SocketFlags.None, New AsyncCallback(AddressOf Sent_Callback), so)
    End Sub

    Private Sub Recv_Callback(ByVal ar As IAsyncResult)
        Try
            Dim so As StateObject = DirectCast(ar.AsyncState, StateObject)
            Dim read As Integer = m_socket.EndReceive(ar)
            If read > 0 Then
                Dim first As Integer = 0
                For i As Integer = 0 To read - 1
                    If so.buffer(i) = &H1A Then
                        m_sbRecv.Append(Encoding.ASCII.GetString(so.buffer, first, i - first))
                        Dim s As [String] = m_sbRecv.ToString()
                        m_sbRecv.Length = 0
                        If s.Length > 0 Then
                            m_recvDelegate(Me, s)
                        End If

                        first = i + 1
                    End If
                Next

                m_sbRecv.Append(Encoding.ASCII.GetString(so.buffer, first, read - first))
            End If

            Recv_Start()
        Catch
            Close()
        End Try
    End Sub

    Private Sub Sent_Callback(ByVal ar As IAsyncResult)
        Dim so As StateObject = DirectCast(ar.AsyncState, StateObject)
    End Sub
End Class

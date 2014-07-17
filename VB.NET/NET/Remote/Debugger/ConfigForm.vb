Imports Microsoft.Win32

Public Class ConfigForm
    Private m_form1 As Form1

    Public Sub New(ByVal form1 As Form1)
        InitializeComponent()

        Using rk As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Polar Engineering\C#\Remote\Debugger")
            txtIPAddress.Text = CStr(rk.GetValue("IPAddress", "?.?.?.?"))
            txtPort.Text = CStr(rk.GetValue("Port", "1000"))
        End Using

        m_form1 = form1
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim port As Integer = 0
        Try
            port = Integer.Parse(txtPort.Text)
        Catch
        End Try

        If port <= 0 OrElse port > 65000 Then
            MessageBox.Show(Me, "Invalid port number.")
        ElseIf m_form1.Initialize(txtIPAddress.Text, port) Then
            Using rk As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Polar Engineering\C#\Remote\Debugger")
                rk.SetValue("IPAddress", txtIPAddress.Text)
                rk.SetValue("Port", txtPort.Text)
            End Using

            Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class
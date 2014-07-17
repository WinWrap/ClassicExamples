' *** WatchDog: example
Imports System.Timers
Imports WinWrap.Basic
Imports WinWrap.Basic.Classic

<ComClass()> _
Public Class WatchDog
    Private basic_ As IBasicNoUI
    Private WithEvents timer_ As Timer

    Friend Sub New(ByVal basic As IBasicNoUI)
        basic_ = basic
        timer_ = New Timer
        timer_.SynchronizingObject = basic
        timer_.AutoReset = False
    End Sub

    Public Sub Start(ByVal Interval As Double)
        timer_.Interval = Interval * 1000
        timer_.Enabled = True
    End Sub

    Public Sub [Stop]()
        timer_.Enabled = False
    End Sub

    Private Sub timer__Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles timer_.Elapsed
        If basic_.Run Then
            basic_.RunThis("Err.Raise 999,,""Watchdog timer expired.""")
            ' force language extension to return prematurely
        End If
    End Sub
End Class
' ***
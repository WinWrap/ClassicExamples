<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.txtIPAddress = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(205, 51)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 24)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(205, 19)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(64, 24)
        Me.btnOK.TabIndex = 10
        Me.btnOK.Text = "OK"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(85, 51)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(80, 20)
        Me.txtPort.TabIndex = 9
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(21, 51)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 16)
        Me.label2.TabIndex = 8
        Me.label2.Text = "Port"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Location = New System.Drawing.Point(85, 19)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(80, 20)
        Me.txtIPAddress.TabIndex = 7
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(21, 19)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(64, 16)
        Me.label1.TabIndex = 6
        Me.label1.Text = "IP Address"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ConfigForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 86)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.txtIPAddress)
        Me.Controls.Add(Me.label1)
        Me.Name = "ConfigForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ConfigForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnOK As System.Windows.Forms.Button
    Private WithEvents txtPort As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents txtIPAddress As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
End Class

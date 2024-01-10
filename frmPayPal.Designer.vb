<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayPal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPayPal))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lnkCopyToClipboard = New System.Windows.Forms.LinkLabel()
        Me.lblThankYou = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(336, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "I appreciate any and all support you want to throw my way via PayPal!"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(15, 25)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(237, 20)
        Me.txtEmail.TabIndex = 1
        Me.txtEmail.Text = "dankunkel@gmail.com"
        '
        'lnkCopyToClipboard
        '
        Me.lnkCopyToClipboard.AutoSize = True
        Me.lnkCopyToClipboard.Location = New System.Drawing.Point(258, 28)
        Me.lnkCopyToClipboard.Name = "lnkCopyToClipboard"
        Me.lnkCopyToClipboard.Size = New System.Drawing.Size(90, 13)
        Me.lnkCopyToClipboard.TabIndex = 2
        Me.lnkCopyToClipboard.TabStop = True
        Me.lnkCopyToClipboard.Text = "Copy to Clipboard"
        '
        'lblThankYou
        '
        Me.lblThankYou.AutoSize = True
        Me.lblThankYou.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThankYou.Location = New System.Drawing.Point(125, 60)
        Me.lblThankYou.Name = "lblThankYou"
        Me.lblThankYou.Size = New System.Drawing.Size(91, 13)
        Me.lblThankYou.TabIndex = 3
        Me.lblThankYou.Text = "THANK YOU!!!"
        '
        'frmPayPal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 82)
        Me.Controls.Add(Me.lblThankYou)
        Me.Controls.Add(Me.lnkCopyToClipboard)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPayPal"
        Me.Text = "Donate to the Cause"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lnkCopyToClipboard As LinkLabel
    Friend WithEvents lblThankYou As Label
End Class

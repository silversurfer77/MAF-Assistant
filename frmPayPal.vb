Public Class frmPayPal

    Private Sub frmPayPal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.CenterToParent()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub lnkCopyToClipboard_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCopyToClipboard.LinkClicked
        Try
            Dim f As New Font(lblThankYou.Font, FontStyle.Bold)
            lblThankYou.Font = f
            lblThankYou.ForeColor = System.Drawing.Color.ForestGreen
            Clipboard.SetText(txtEmail.Text.Trim)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
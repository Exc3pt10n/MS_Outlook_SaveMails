Public Class frmSettings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lblSaveRootPath.Text = My.Settings.SaveRootPath.ToString()
    End Sub

    Private Sub cmdChangeStartPath_Click(sender As Object, e As EventArgs) Handles cmdChangeStartPath.Click
        Dim fbd As New FolderBrowserDialog

        With fbd
            .RootFolder = Environment.SpecialFolder.MyComputer
            .SelectedPath = My.Settings.SaveRootPath.ToString()
            .Description = "Bitte wählen Sie einen Pfad"
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Settings.SaveRootPath = .SelectedPath.ToString()
                My.Settings.Save()
                Me.lblSaveRootPath.Text = My.Settings.SaveRootPath.ToString()
            End If
        End With
    End Sub
End Class
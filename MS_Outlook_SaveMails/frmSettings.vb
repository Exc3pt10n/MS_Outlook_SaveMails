Public Class frmSettings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With My.Settings
            lblSaveRootPath.Text = .SaveRootPath.ToString()
            txtLenSenderName.Text = .MaxLenSenderName.ToString()
            txtLenSubject.Text = .MaxLenSubject.ToString()
        End With
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

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Try
            My.Settings.MaxLenSenderName = CType(txtLenSenderName.Text.ToString(), Integer)
            My.Settings.MaxLenSubject = CType(txtLenSubject.Text.ToString(), Integer)
        Catch ex As Exception
            MsgBox("Es ist ein Fehler beim Speichern der Einstellungen aufgetreten, bitte passen Sie die Werte an.", MsgBoxStyle.Critical)
            Exit Sub
        End Try

        If CType(txtLenSenderName.Text.ToString(), Integer) < 0 Or CType(txtLenSubject.Text.ToString(), Integer) < 0 Then
            MsgBox("Die Werte für die maximale Länge dürfen nicht kleiner als 0 sein.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        My.Settings.Save()
        MsgBox("Die Einstellungen wurden erfolgreich gespeichert", MsgBoxStyle.Information)
    End Sub
End Class
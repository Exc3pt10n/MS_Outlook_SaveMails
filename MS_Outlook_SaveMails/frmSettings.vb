Public Class frmSettings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With My.Settings
            txtFileName.Text = .FileName.ToString()
            lblSaveRootPath.Text = .SaveRootPath.ToString()
            txtLenSubject.Text = .MaxLenSubject.ToString()
            txtRegExPattern.Text = .MailCleanRegex.ToString()
            chbUseBrowser.Checked = .UseBrowser
            chbSaveMailsWithoutAttachments.Checked = .SaveWithoutAttachments
            chbProtokoll.Checked = .Debug
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
            With My.Settings
                .MaxLenSubject = CType(txtLenSubject.Text.ToString(), Integer)
                .MailCleanRegex = txtRegExPattern.Text.ToString()
                .FileName = txtFileName.Text.ToString()
                .UseBrowser = chbUseBrowser.Checked
                .SaveWithoutAttachments = chbSaveMailsWithoutAttachments.Checked
                .Debug = chbProtokoll.Checked
            End With
        Catch ex As Exception
            MsgBox("Es ist ein Fehler beim Speichern der Einstellungen aufgetreten, bitte passen Sie die Werte an.", MsgBoxStyle.Critical)
            Exit Sub
        End Try

        If CType(txtLenSubject.Text.ToString(), Integer) < 0 Or
            txtRegExPattern.Text.ToString() = vbNullString Or
            txtFileName.Text.ToString() = vbNullString Then
            MsgBox("Das Speichern der Einstellungen ist nicht möglich, da " & vbCrLf &
                   "-der Maximalwert für den Betreff < 0 ist" & vbCrLf &
                   "-das RegEx-Pattern leer ist" & vbCrLf &
                   "-der Dateiname leer ist", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Try
            My.Settings.Save()
        Catch ex As Exception
            MsgBox("Es ist leider ein Fehler beim Speichern aufgetreten." & vbCrLf &
                   "Fehlernachricht: " & ex.Message, MsgBoxStyle.Critical, "Fehler beim Speichern")
            Exit Sub
        End Try

        MsgBox("Die Einstellungen wurden erfolgreich gespeichert", MsgBoxStyle.Information)
    End Sub
End Class
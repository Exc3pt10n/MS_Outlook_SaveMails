Public Class frmMain
    Private Delegate Sub dele_set_prgBar_max(ByVal max As Long)
    Private Delegate Sub dele_update_prgBar(ByVal value As Long)

    Private Sub set_prgBar_max(ByVal max As Long)
        prgBar.Maximum = CType(max, Integer)
    End Sub

    Private Sub update_prgBar(ByVal value As Long)
        prgBar.Value = CType(value, Integer)
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not isOutlookRunning() Then
            MsgBox("Outlook läuft nicht, starten der Anwendung nicht möglich.", CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle), "Outlook nicht gestartet")
            Application.Exit()
        End If

        If My.Settings.SaveRootPath = vbNullString Or Not My.Computer.FileSystem.DirectoryExists(My.Settings.SaveRootPath.ToString()) Then
            My.Settings.SaveRootPath = My.Computer.FileSystem.SpecialDirectories.Desktop.ToString()
            My.Settings.Save()
        End If

        TimerCheckSelection.Start()
    End Sub

    Private Sub cmdSaveSelectedItems_Click(sender As Object, e As EventArgs) Handles cmdSaveSelectedItems.Click
        Dim thrSaveMails As New Threading.Thread(AddressOf save_selected_mails_from_outlook)
        Dim fbd As New FolderBrowserDialog
        Dim strPfad As String

        If My.Settings.UseBrowser Then
            With fbd
                .RootFolder = Environment.SpecialFolder.MyComputer
                .SelectedPath = My.Settings.SaveRootPath.ToString()
                .Description = "Bitte wählen Sie einen Pfad"
                If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    strPfad = .SelectedPath.ToString()
                Else
                    Exit Sub
                End If
            End With
        Else
            strPfad = My.Settings.SaveRootPath.ToString()
        End If

        TimerCheckSelection.Stop()
        thrSaveMails.Start(strPfad)
    End Sub

    Private Sub save_selected_mails_from_outlook(ByVal args As Object)
        Dim appOut As New Microsoft.Office.Interop.Outlook.Application
        Dim outExplorer As Microsoft.Office.Interop.Outlook.Explorer
        Dim outMail As Microsoft.Office.Interop.Outlook.MailItem
        Dim strSubject As String, strFinalPath As String
        Dim l As Long = 0, m As Long = 0

        outExplorer = appOut.ActiveExplorer

        If outExplorer.Selection.Count = 0 Then
            MsgBox("Keine Mails in Outlook ausgewählt.", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle))
            Exit Sub
        Else
            Try
                outMail = CType(outExplorer.Selection(1), Microsoft.Office.Interop.Outlook.MailItem)
            Catch ex As Exception
                MsgBox("Speichern nicht möglich, keine Mail gewählt.", MsgBoxStyle.Critical, "Speichern nicht möglich")
                Exit Sub
            End Try

            Me.Invoke(New dele_set_prgBar_max(AddressOf set_prgBar_max), outExplorer.Selection.Count)
        End If

        Dim regex As New VBScript_RegExp_55.RegExp
        regex.Pattern = My.Settings.MailCleanRegex

        'Debugging!
        Dim strAusgabe As String
        strAusgabe = "Ausführung gestartet" & vbCrLf

        For Each outMail In outExplorer.Selection
            If Not Strings.Left(outMail.MessageClass.ToString(), 8) = "IPM.Note" Then
                'Debugging!
                strAusgabe = strAusgabe & "Kein Mailitem: " & outMail.Subject.ToString() & " MessageClass: " & outMail.MessageClass.ToString() & vbCrLf
                Continue For
            End If

            If outMail.Subject Is Nothing Then
                strSubject = "(leer)"
            Else
                strSubject = outMail.Subject.ToString()
            End If

            If Not regex.Test(strSubject) Then
                strFinalPath = String.Format("{0}\{1}.MSG", CType(args, String), replace_placeholder_filename(outMail, Strings.Left(strSubject, My.Settings.MaxLenSubject)))

                Try
                    'Debugging!
                    strAusgabe = strAusgabe & strFinalPath & vbCrLf
                    m = m + 1
                    outMail.SaveAs(strFinalPath, Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG)
                Catch ex As Exception
                    'Debugging!
                    strAusgabe = strAusgabe & "Fehler beim Speichern des MailItems. Fehlernachricht: " & ex.Message & vbCrLf
                    m = m - 1
                    MsgBox("Es ist leider ein Fehler beim Speichern aufgetreten." & vbCrLf & vbCrLf &
                       "Fehlercode: " & ex.HResult & vbCrLf &
                       "Fehlertext: " & ex.Message, CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle), "Fehler beim Speichern")
                End Try
            Else
                'Debugging!
                strAusgabe = strAusgabe & "RegEx(" & My.Settings.MailCleanRegex.ToString() & ") passt: " & strSubject & vbCrLf
            End If

            l = l + 1
            Me.Invoke(New dele_update_prgBar(AddressOf update_prgBar), l)
        Next

        strAusgabe = strAusgabe & "Die Schleife wurde " & l & " Mal durchlaufen"

        'Debugging!
        If My.Settings.Debug Then
            Dim sWriter As New IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.Desktop & "\MS_Outlook_SaveMails_Protokoll.txt")
            sWriter.Write(strAusgabe)
            sWriter.Close()
        End If

        MsgBox("Es wurden " & m & " Nachrichten gespeichert.", MsgBoxStyle.Information, "Vorgang abgeschlossen")
        Me.Invoke(New dele_update_prgBar(AddressOf update_prgBar), 0)
    End Sub

    Private Function replace_placeholder_filename(ByVal MailItem As Microsoft.Office.Interop.Outlook.MailItem, ByVal Subject As String) As String
        Dim strName As String, strDatePattern As String
        strName = My.Settings.FileName.ToString()
        strDatePattern = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern & " " & System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern

        strName = Strings.Replace(strName, "<Categories>", CType(If(MailItem.Categories Is Nothing, "(leer)", MailItem.Categories.ToString()), String))
        strName = Strings.Replace(strName, "<ReceivedByName>", CType(If(MailItem.ReceivedByName Is Nothing, "(leer)", MailItem.ReceivedByName.ToString()), String))
        strName = Strings.Replace(strName, "<ReceivedTime>", If(MailItem.ReceivedTime = DateTime.MinValue, "(leer)", Format(MailItem.ReceivedTime, strDatePattern)))
        strName = Strings.Replace(strName, "<SenderEmailAddress>", CType(If(MailItem.SenderEmailAddress Is Nothing, "(leer)", MailItem.SenderEmailAddress.ToString()), String))
        strName = Strings.Replace(strName, "<SenderName>", CType(If(MailItem.SenderName Is Nothing, "(leer)", MailItem.SenderName.ToString()), String))
        strName = Strings.Replace(strName, "<SentOn>", If(MailItem.SentOn = DateTime.MinValue, "(leer)", Format(MailItem.SentOn, strDatePattern)))
        strName = Strings.Replace(strName, "<Subject>", Subject)
        strName = ReplaceCharsForFileName(strName)

        Return strName
    End Function

    Private Function isOutlookRunning() As Boolean
        Dim p() As Process = Process.GetProcessesByName("Outlook")
        If p.Count = 0 Then Return False Else Return True
    End Function

    Private Function ReplaceCharsForFileName(ByVal strPath As String) As String
        Const c As String = vbNullString

        strPath = Strings.Trim(strPath)
        strPath = Strings.Replace(strPath, """", c)
        strPath = Strings.Replace(strPath, "'", c)
        strPath = Strings.Replace(strPath, "*", c)
        strPath = Strings.Replace(strPath, "/", c)
        strPath = Strings.Replace(strPath, "\", c)
        strPath = Strings.Replace(strPath, ":", c)
        strPath = Strings.Replace(strPath, "?", c)
        strPath = Strings.Replace(strPath, Chr(34), c)
        strPath = Strings.Replace(strPath, "<", c)
        strPath = Strings.Replace(strPath, ">", c)
        strPath = Strings.Replace(strPath, "|", c)

        Return strPath
    End Function

    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeendenToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub EinstellungenÄndernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EinstellungenÄndernToolStripMenuItem.Click
        Dim s As New frmSettings
        s.Show()
    End Sub

    Private Sub ÜberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÜberToolStripMenuItem.Click
        Dim frm As New AboutBox
        frm.Show()
    End Sub

    Private Sub TimerCheckSelection_Tick(sender As Object, e As EventArgs) Handles TimerCheckSelection.Tick
        Dim p() As Process = Process.GetProcessesByName("Outlook")

        If p.Count = 0 Then
            Application.Exit()
        End If

        Try
            Dim appOut As New Microsoft.Office.Interop.Outlook.Application
            Dim outExplorer As Microsoft.Office.Interop.Outlook.Explorer
            Dim strAusgabe As String
            outExplorer = appOut.ActiveExplorer

            strAusgabe = outExplorer.Selection.Count.ToString()

            If outExplorer.Selection.Count = 1 Then
                strAusgabe = strAusgabe & " Mail markiert"
            Else
                strAusgabe = strAusgabe & " Mails markiert"
            End If

            lblAnzahlMails.Text = strAusgabe
        Catch ex As Exception
            Application.Exit()
        End Try
    End Sub
End Class

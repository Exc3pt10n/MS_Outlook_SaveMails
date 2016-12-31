Public Class frmMain
    Private Delegate Sub dele_set_prgBar_max(ByVal max As Long)
    Private Delegate Sub dele_update_prgBar(ByVal value As Long)
    Private Delegate Sub dele_update_MailCountLabel(ByVal text As String)

    Private Sub set_prgBar_max(ByVal max As Long)
        prgBar.Maximum = CType(max, Integer)
    End Sub

    Private Sub update_prgBar(ByVal value As Long)
        prgBar.Value = CType(value, Integer)
    End Sub

    Private Sub update_MailCountLabel(ByVal text As String)
        lblAnzahlMails.Text = text
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim p() As Process = Process.GetProcessesByName("Outlook")

        If p.Count = 0 Then
            MsgBox("Outlook läuft nicht, starten der Anwendung nicht möglich.", CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle), "Outlook nicht gestartet")
            Application.Exit()
        End If

        If My.Settings.SaveRootPath = vbNullString Then
            My.Settings.SaveRootPath = My.Computer.FileSystem.SpecialDirectories.Desktop.ToString()
            My.Settings.Save()
        End If

        TimerCheckSelection.Start()
    End Sub

    Private Sub cmdSaveSelectedItems_Click(sender As Object, e As EventArgs) Handles cmdSaveSelectedItems.Click
        Dim thrAddItems As New Threading.Thread(AddressOf save_selected_mails_from_outlook)
        Dim fbd As New FolderBrowserDialog
        Dim strPfad As String

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

        thrAddItems.Start(strPfad)
    End Sub

    Private Sub save_selected_mails_from_outlook(ByVal args As Object)
        Dim appOut As New Microsoft.Office.Interop.Outlook.Application
        Dim outExplorer As Microsoft.Office.Interop.Outlook.Explorer
        Dim outMail As Microsoft.Office.Interop.Outlook.MailItem
        Dim strSubject As String, strFinalPath As String
        Dim l As Long = 0, f As Long = 0

        outExplorer = appOut.ActiveExplorer

        If outExplorer.Selection.Count = 0 Then
            MsgBox("Keine Mails in Outlook ausgewählt.", CType(MsgBoxStyle.Information + MsgBoxStyle.OkOnly, MsgBoxStyle))
            Exit Sub
        Else
            Me.Invoke(New dele_set_prgBar_max(AddressOf set_prgBar_max), outExplorer.Selection.Count)
        End If

        For Each outMail In outExplorer.Selection
            If Not outMail.MessageClass.ToString() = "IPM.Note" Then
                Continue For
            End If

            If CType(outMail.Subject, String) = vbNullString Then
                strSubject = "(leer)"
            Else
                strSubject = Strings.Left(outMail.Subject.ToString(), My.Settings.MaxLenSubject)
            End If

            strFinalPath = String.Format("{0}\{1}_{2}_{3}.MSG", CType(args, String), ReplaceCharsForFileName(FormatDateTime(outMail.ReceivedTime, DateFormat.GeneralDate)), ReplaceCharsForFileName(Strings.Left(outMail.SenderName.ToString(), My.Settings.MaxLenSenderName)), ReplaceCharsForFileName(strSubject))

            Try
                outMail.SaveAs(strFinalPath, Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG)
            Catch ex As Exception
                f = f + 1
                MsgBox("Es ist leider ein Fehler beim Speichern aufgetreten." & vbCrLf & vbCrLf &
                       "Fehlercode: " & ex.HResult & vbCrLf &
                       "Fehlbertext: " & ex.Message, CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle), "Fehler beim Speichern")
            End Try
            l = l + 1
            Me.Invoke(New dele_update_prgBar(AddressOf update_prgBar), l)
        Next

        MsgBox("Es wurden " & l - f & " Nachrichten gespeichert.", MsgBoxStyle.Information, "Vorgang abgeschlossen")
        Me.Invoke(New dele_update_prgBar(AddressOf update_prgBar), 0)
    End Sub

    Private Function ReplaceCharsForFileName(ByVal strPath As String) As String
        Const c As String = "-"

        strPath = Strings.Trim(strPath)
        strPath = Strings.Replace(strPath, " ", "_")
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

    Private Sub TimerCheckSelection_Tick(sender As Object, e As EventArgs) Handles TimerCheckSelection.Tick
        Dim thrTimer As New Threading.Thread(AddressOf check_for_Selection_Count)
        thrTimer.Start()
    End Sub

    Private Sub check_for_Selection_Count()
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

            Me.Invoke(New dele_update_MailCountLabel(AddressOf update_MailCountLabel), strAusgabe)
        Catch ex As Exception
            Application.Exit()
        End Try
    End Sub
End Class

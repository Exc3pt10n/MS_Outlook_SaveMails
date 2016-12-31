<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdSaveSelectedItems = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProgrammToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungenÄndernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÜberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.prgBar = New System.Windows.Forms.ProgressBar()
        Me.lblAnzahlMails = New System.Windows.Forms.Label()
        Me.TimerCheckSelection = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSaveSelectedItems
        '
        Me.cmdSaveSelectedItems.Location = New System.Drawing.Point(12, 27)
        Me.cmdSaveSelectedItems.Name = "cmdSaveSelectedItems"
        Me.cmdSaveSelectedItems.Size = New System.Drawing.Size(105, 23)
        Me.cmdSaveSelectedItems.TabIndex = 2
        Me.cmdSaveSelectedItems.Text = "Mails speichern"
        Me.cmdSaveSelectedItems.UseVisualStyleBackColor = True
        Me.cmdSaveSelectedItems.UseWaitCursor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgrammToolStripMenuItem, Me.ÜberToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(411, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.UseWaitCursor = True
        '
        'ProgrammToolStripMenuItem
        '
        Me.ProgrammToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EinstellungenÄndernToolStripMenuItem, Me.BeendenToolStripMenuItem})
        Me.ProgrammToolStripMenuItem.Name = "ProgrammToolStripMenuItem"
        Me.ProgrammToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.ProgrammToolStripMenuItem.Text = "Programm"
        '
        'EinstellungenÄndernToolStripMenuItem
        '
        Me.EinstellungenÄndernToolStripMenuItem.Name = "EinstellungenÄndernToolStripMenuItem"
        Me.EinstellungenÄndernToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EinstellungenÄndernToolStripMenuItem.Text = "Einstellungen"
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BeendenToolStripMenuItem.Text = "Beenden"
        '
        'ÜberToolStripMenuItem
        '
        Me.ÜberToolStripMenuItem.Name = "ÜberToolStripMenuItem"
        Me.ÜberToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ÜberToolStripMenuItem.Text = "Über"
        '
        'prgBar
        '
        Me.prgBar.Location = New System.Drawing.Point(12, 57)
        Me.prgBar.Name = "prgBar"
        Me.prgBar.Size = New System.Drawing.Size(387, 23)
        Me.prgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prgBar.TabIndex = 5
        Me.prgBar.UseWaitCursor = True
        '
        'lblAnzahlMails
        '
        Me.lblAnzahlMails.AutoSize = True
        Me.lblAnzahlMails.Location = New System.Drawing.Point(123, 33)
        Me.lblAnzahlMails.Name = "lblAnzahlMails"
        Me.lblAnzahlMails.Size = New System.Drawing.Size(0, 13)
        Me.lblAnzahlMails.TabIndex = 6
        Me.lblAnzahlMails.UseWaitCursor = True
        '
        'TimerCheckSelection
        '
        Me.TimerCheckSelection.Interval = 500
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 93)
        Me.Controls.Add(Me.lblAnzahlMails)
        Me.Controls.Add(Me.prgBar)
        Me.Controls.Add(Me.cmdSaveSelectedItems)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "SaveOutlookMails"
        Me.UseWaitCursor = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSaveSelectedItems As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ProgrammToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EinstellungenÄndernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BeendenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents prgBar As ProgressBar
    Friend WithEvents lblAnzahlMails As Label
    Friend WithEvents TimerCheckSelection As Timer
    Friend WithEvents ÜberToolStripMenuItem As ToolStripMenuItem
End Class

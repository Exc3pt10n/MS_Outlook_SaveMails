<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSaveRootPath = New System.Windows.Forms.Label()
        Me.cmdChangeStartPath = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLenSubject = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLenSenderName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblSaveRootPath)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(375, 56)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Startpfad Verzeichnisbrowser"
        '
        'lblSaveRootPath
        '
        Me.lblSaveRootPath.AutoSize = True
        Me.lblSaveRootPath.Location = New System.Drawing.Point(7, 20)
        Me.lblSaveRootPath.Name = "lblSaveRootPath"
        Me.lblSaveRootPath.Size = New System.Drawing.Size(30, 13)
        Me.lblSaveRootPath.TabIndex = 0
        Me.lblSaveRootPath.Text = "(leer)"
        '
        'cmdChangeStartPath
        '
        Me.cmdChangeStartPath.Location = New System.Drawing.Point(13, 76)
        Me.cmdChangeStartPath.Name = "cmdChangeStartPath"
        Me.cmdChangeStartPath.Size = New System.Drawing.Size(75, 23)
        Me.cmdChangeStartPath.TabIndex = 1
        Me.cmdChangeStartPath.Text = "ändern"
        Me.cmdChangeStartPath.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSave)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtLenSubject)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtLenSenderName)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 106)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(375, 100)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dateibezeichnung"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(294, 54)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 5
        Me.cmdSave.Text = "speichern"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Betreff"
        '
        'txtLenSubject
        '
        Me.txtLenSubject.Location = New System.Drawing.Point(96, 57)
        Me.txtLenSubject.Name = "txtLenSubject"
        Me.txtLenSubject.Size = New System.Drawing.Size(100, 20)
        Me.txtLenSubject.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Name Absender"
        '
        'txtLenSenderName
        '
        Me.txtLenSenderName.Location = New System.Drawing.Point(96, 31)
        Me.txtLenSenderName.Name = "txtLenSenderName"
        Me.txtLenSenderName.Size = New System.Drawing.Size(100, 20)
        Me.txtLenSenderName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "maximale Länge"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 216)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdChangeStartPath)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmSettings"
        Me.Text = "frmSettings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblSaveRootPath As Label
    Friend WithEvents cmdChangeStartPath As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmdSave As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLenSubject As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLenSenderName As TextBox
    Friend WithEvents Label1 As Label
End Class

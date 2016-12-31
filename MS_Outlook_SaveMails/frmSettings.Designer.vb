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
        Me.GroupBox1.SuspendLayout()
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
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 388)
        Me.Controls.Add(Me.cmdChangeStartPath)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmSettings"
        Me.Text = "frmSettings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblSaveRootPath As Label
    Friend WithEvents cmdChangeStartPath As Button
End Class

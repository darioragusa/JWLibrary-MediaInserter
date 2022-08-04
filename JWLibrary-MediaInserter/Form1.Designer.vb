<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ComboBoxPub = New System.Windows.Forms.ComboBox()
        Me.ComboBoxDocs = New System.Windows.Forms.ComboBox()
        Me.ButtonSelect = New System.Windows.Forms.Button()
        Me.ButtonDelete = New System.Windows.Forms.Button()
        Me.GroupBoxMedia = New System.Windows.Forms.GroupBox()
        Me.ListBoxMedia = New System.Windows.Forms.ListBox()
        Me.ButtonInsert = New System.Windows.Forms.Button()
        Me.GroupBoxPub = New System.Windows.Forms.GroupBox()
        Me.ButtonRestoreBackup = New System.Windows.Forms.Button()
        Me.GroupBoxAdvanced = New System.Windows.Forms.GroupBox()
        Me.ButtonJWPUB = New System.Windows.Forms.Button()
        Me.CheckBoxShowAll = New System.Windows.Forms.CheckBox()
        Me.GroupBoxMedia.SuspendLayout()
        Me.GroupBoxPub.SuspendLayout()
        Me.GroupBoxAdvanced.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBoxPub
        '
        Me.ComboBoxPub.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxPub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPub.FormattingEnabled = True
        Me.ComboBoxPub.IntegralHeight = False
        Me.ComboBoxPub.Location = New System.Drawing.Point(6, 22)
        Me.ComboBoxPub.Name = "ComboBoxPub"
        Me.ComboBoxPub.Size = New System.Drawing.Size(388, 23)
        Me.ComboBoxPub.TabIndex = 1
        '
        'ComboBoxDocs
        '
        Me.ComboBoxDocs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxDocs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDocs.FormattingEnabled = True
        Me.ComboBoxDocs.Location = New System.Drawing.Point(6, 60)
        Me.ComboBoxDocs.Name = "ComboBoxDocs"
        Me.ComboBoxDocs.Size = New System.Drawing.Size(300, 23)
        Me.ComboBoxDocs.TabIndex = 2
        '
        'ButtonSelect
        '
        Me.ButtonSelect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSelect.BackColor = System.Drawing.Color.Transparent
        Me.ButtonSelect.FlatAppearance.BorderSize = 0
        Me.ButtonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSelect.ForeColor = System.Drawing.Color.Blue
        Me.ButtonSelect.Location = New System.Drawing.Point(6, 16)
        Me.ButtonSelect.Name = "ButtonSelect"
        Me.ButtonSelect.Size = New System.Drawing.Size(275, 23)
        Me.ButtonSelect.TabIndex = 4
        Me.ButtonSelect.Text = "Select medias to insert"
        Me.ButtonSelect.UseVisualStyleBackColor = False
        '
        'ButtonDelete
        '
        Me.ButtonDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDelete.BackColor = System.Drawing.Color.Transparent
        Me.ButtonDelete.FlatAppearance.BorderSize = 0
        Me.ButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDelete.ForeColor = System.Drawing.Color.Red
        Me.ButtonDelete.Location = New System.Drawing.Point(286, 16)
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(107, 23)
        Me.ButtonDelete.TabIndex = 5
        Me.ButtonDelete.Text = "Delete"
        Me.ButtonDelete.UseVisualStyleBackColor = False
        '
        'GroupBoxMedia
        '
        Me.GroupBoxMedia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxMedia.BackColor = System.Drawing.Color.White
        Me.GroupBoxMedia.Controls.Add(Me.ListBoxMedia)
        Me.GroupBoxMedia.Controls.Add(Me.ButtonInsert)
        Me.GroupBoxMedia.Controls.Add(Me.ButtonSelect)
        Me.GroupBoxMedia.Controls.Add(Me.ButtonDelete)
        Me.GroupBoxMedia.Location = New System.Drawing.Point(12, 114)
        Me.GroupBoxMedia.Name = "GroupBoxMedia"
        Me.GroupBoxMedia.Size = New System.Drawing.Size(400, 251)
        Me.GroupBoxMedia.TabIndex = 3
        Me.GroupBoxMedia.TabStop = False
        Me.GroupBoxMedia.Text = "Media"
        '
        'ListBoxMedia
        '
        Me.ListBoxMedia.AllowDrop = True
        Me.ListBoxMedia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBoxMedia.BackColor = System.Drawing.SystemColors.Window
        Me.ListBoxMedia.FormattingEnabled = True
        Me.ListBoxMedia.ItemHeight = 15
        Me.ListBoxMedia.Location = New System.Drawing.Point(6, 46)
        Me.ListBoxMedia.Name = "ListBoxMedia"
        Me.ListBoxMedia.Size = New System.Drawing.Size(388, 169)
        Me.ListBoxMedia.TabIndex = 6
        '
        'ButtonInsert
        '
        Me.ButtonInsert.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonInsert.BackColor = System.Drawing.Color.Transparent
        Me.ButtonInsert.FlatAppearance.BorderSize = 0
        Me.ButtonInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonInsert.ForeColor = System.Drawing.Color.Blue
        Me.ButtonInsert.Location = New System.Drawing.Point(6, 221)
        Me.ButtonInsert.Name = "ButtonInsert"
        Me.ButtonInsert.Size = New System.Drawing.Size(388, 23)
        Me.ButtonInsert.TabIndex = 7
        Me.ButtonInsert.Text = "Insert"
        Me.ButtonInsert.UseVisualStyleBackColor = False
        '
        'GroupBoxPub
        '
        Me.GroupBoxPub.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxPub.Controls.Add(Me.ButtonRestoreBackup)
        Me.GroupBoxPub.Controls.Add(Me.ComboBoxPub)
        Me.GroupBoxPub.Controls.Add(Me.ComboBoxDocs)
        Me.GroupBoxPub.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxPub.Name = "GroupBoxPub"
        Me.GroupBoxPub.Size = New System.Drawing.Size(400, 96)
        Me.GroupBoxPub.TabIndex = 0
        Me.GroupBoxPub.TabStop = False
        Me.GroupBoxPub.Text = "Publication"
        '
        'ButtonRestoreBackup
        '
        Me.ButtonRestoreBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRestoreBackup.BackColor = System.Drawing.Color.Transparent
        Me.ButtonRestoreBackup.Enabled = False
        Me.ButtonRestoreBackup.FlatAppearance.BorderSize = 0
        Me.ButtonRestoreBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRestoreBackup.Font = New System.Drawing.Font("Segoe UI", 7.6!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ButtonRestoreBackup.ForeColor = System.Drawing.Color.Red
        Me.ButtonRestoreBackup.Location = New System.Drawing.Point(308, 51)
        Me.ButtonRestoreBackup.Name = "ButtonRestoreBackup"
        Me.ButtonRestoreBackup.Size = New System.Drawing.Size(90, 39)
        Me.ButtonRestoreBackup.TabIndex = 6
        Me.ButtonRestoreBackup.Text = "Restore backup"
        Me.ButtonRestoreBackup.UseVisualStyleBackColor = False
        '
        'GroupBoxAdvanced
        '
        Me.GroupBoxAdvanced.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxAdvanced.Controls.Add(Me.ButtonJWPUB)
        Me.GroupBoxAdvanced.Controls.Add(Me.CheckBoxShowAll)
        Me.GroupBoxAdvanced.Location = New System.Drawing.Point(12, 369)
        Me.GroupBoxAdvanced.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.GroupBoxAdvanced.Name = "GroupBoxAdvanced"
        Me.GroupBoxAdvanced.Padding = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.GroupBoxAdvanced.Size = New System.Drawing.Size(400, 43)
        Me.GroupBoxAdvanced.TabIndex = 4
        Me.GroupBoxAdvanced.TabStop = False
        Me.GroupBoxAdvanced.Text = "Advanced"
        '
        'ButtonJWPUB
        '
        Me.ButtonJWPUB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonJWPUB.BackColor = System.Drawing.Color.Transparent
        Me.ButtonJWPUB.FlatAppearance.BorderSize = 0
        Me.ButtonJWPUB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonJWPUB.ForeColor = System.Drawing.Color.Blue
        Me.ButtonJWPUB.Location = New System.Drawing.Point(248, 15)
        Me.ButtonJWPUB.Name = "ButtonJWPUB"
        Me.ButtonJWPUB.Size = New System.Drawing.Size(146, 23)
        Me.ButtonJWPUB.TabIndex = 5
        Me.ButtonJWPUB.Text = "Export JWPUB"
        Me.ButtonJWPUB.UseVisualStyleBackColor = False
        '
        'CheckBoxShowAll
        '
        Me.CheckBoxShowAll.AutoSize = True
        Me.CheckBoxShowAll.Location = New System.Drawing.Point(6, 18)
        Me.CheckBoxShowAll.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.CheckBoxShowAll.Name = "CheckBoxShowAll"
        Me.CheckBoxShowAll.Size = New System.Drawing.Size(138, 19)
        Me.CheckBoxShowAll.TabIndex = 0
        Me.CheckBoxShowAll.Text = "Show all publications"
        Me.CheckBoxShowAll.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(424, 416)
        Me.Controls.Add(Me.GroupBoxAdvanced)
        Me.Controls.Add(Me.GroupBoxPub)
        Me.Controls.Add(Me.GroupBoxMedia)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(440, 1000)
        Me.MinimumSize = New System.Drawing.Size(440, 360)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JWLibrary-MediaInserter"
        Me.GroupBoxMedia.ResumeLayout(False)
        Me.GroupBoxPub.ResumeLayout(False)
        Me.GroupBoxAdvanced.ResumeLayout(False)
        Me.GroupBoxAdvanced.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBoxPub As ComboBox
    Friend WithEvents ComboBoxDocs As ComboBox
    Friend WithEvents ButtonSelect As Button
    Friend WithEvents ButtonDelete As Button
    Friend WithEvents GroupBoxMedia As GroupBox
    Friend WithEvents ListBoxMedia As ListBox
    Friend WithEvents ButtonInsert As Button
    Friend WithEvents GroupBoxPub As GroupBox
    Friend WithEvents ButtonRestoreBackup As Button
    Friend WithEvents GroupBoxAdvanced As GroupBox
    Friend WithEvents CheckBoxShowAll As CheckBox
    Friend WithEvents ButtonJWPUB As Button
End Class

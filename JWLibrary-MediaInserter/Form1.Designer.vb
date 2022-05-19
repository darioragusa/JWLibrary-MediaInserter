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
        Me.ComboBoxWeek = New System.Windows.Forms.ComboBox()
        Me.ButtonSelect = New System.Windows.Forms.Button()
        Me.ButtonDelete = New System.Windows.Forms.Button()
        Me.GroupBoxMedia = New System.Windows.Forms.GroupBox()
        Me.ListBoxMedia = New System.Windows.Forms.ListBox()
        Me.ButtonInsert = New System.Windows.Forms.Button()
        Me.GroupBoxPub = New System.Windows.Forms.GroupBox()
        Me.GroupBoxMedia.SuspendLayout()
        Me.GroupBoxPub.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBoxPub
        '
        Me.ComboBoxPub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPub.FormattingEnabled = True
        Me.ComboBoxPub.Location = New System.Drawing.Point(6, 22)
        Me.ComboBoxPub.Name = "ComboBoxPub"
        Me.ComboBoxPub.Size = New System.Drawing.Size(388, 23)
        Me.ComboBoxPub.TabIndex = 1
        '
        'ComboBoxWeek
        '
        Me.ComboBoxWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxWeek.FormattingEnabled = True
        Me.ComboBoxWeek.Location = New System.Drawing.Point(6, 51)
        Me.ComboBoxWeek.Name = "ComboBoxWeek"
        Me.ComboBoxWeek.Size = New System.Drawing.Size(388, 23)
        Me.ComboBoxWeek.TabIndex = 2
        '
        'ButtonSelect
        '
        Me.ButtonSelect.BackColor = System.Drawing.Color.Transparent
        Me.ButtonSelect.FlatAppearance.BorderSize = 0
        Me.ButtonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSelect.ForeColor = System.Drawing.Color.Blue
        Me.ButtonSelect.Location = New System.Drawing.Point(6, 22)
        Me.ButtonSelect.Name = "ButtonSelect"
        Me.ButtonSelect.Size = New System.Drawing.Size(275, 23)
        Me.ButtonSelect.TabIndex = 4
        Me.ButtonSelect.Text = "Select medias to insert"
        Me.ButtonSelect.UseVisualStyleBackColor = False
        '
        'ButtonDelete
        '
        Me.ButtonDelete.BackColor = System.Drawing.Color.Transparent
        Me.ButtonDelete.FlatAppearance.BorderSize = 0
        Me.ButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDelete.ForeColor = System.Drawing.Color.Red
        Me.ButtonDelete.Location = New System.Drawing.Point(287, 22)
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(107, 23)
        Me.ButtonDelete.TabIndex = 5
        Me.ButtonDelete.Text = "Delete"
        Me.ButtonDelete.UseVisualStyleBackColor = False
        '
        'GroupBoxMedia
        '
        Me.GroupBoxMedia.Controls.Add(Me.ListBoxMedia)
        Me.GroupBoxMedia.Controls.Add(Me.ButtonSelect)
        Me.GroupBoxMedia.Controls.Add(Me.ButtonDelete)
        Me.GroupBoxMedia.Location = New System.Drawing.Point(12, 101)
        Me.GroupBoxMedia.Name = "GroupBoxMedia"
        Me.GroupBoxMedia.Size = New System.Drawing.Size(400, 230)
        Me.GroupBoxMedia.TabIndex = 3
        Me.GroupBoxMedia.TabStop = False
        Me.GroupBoxMedia.Text = "Media"
        '
        'ListBoxMedia
        '
        Me.ListBoxMedia.FormattingEnabled = True
        Me.ListBoxMedia.ItemHeight = 15
        Me.ListBoxMedia.Location = New System.Drawing.Point(6, 51)
        Me.ListBoxMedia.Name = "ListBoxMedia"
        Me.ListBoxMedia.Size = New System.Drawing.Size(388, 169)
        Me.ListBoxMedia.TabIndex = 6
        '
        'ButtonInsert
        '
        Me.ButtonInsert.BackColor = System.Drawing.Color.Transparent
        Me.ButtonInsert.FlatAppearance.BorderSize = 0
        Me.ButtonInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonInsert.ForeColor = System.Drawing.Color.Blue
        Me.ButtonInsert.Location = New System.Drawing.Point(12, 337)
        Me.ButtonInsert.Name = "ButtonInsert"
        Me.ButtonInsert.Size = New System.Drawing.Size(400, 23)
        Me.ButtonInsert.TabIndex = 7
        Me.ButtonInsert.Text = "Insert"
        Me.ButtonInsert.UseVisualStyleBackColor = False
        '
        'GroupBoxPub
        '
        Me.GroupBoxPub.Controls.Add(Me.ComboBoxPub)
        Me.GroupBoxPub.Controls.Add(Me.ComboBoxWeek)
        Me.GroupBoxPub.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxPub.Name = "GroupBoxPub"
        Me.GroupBoxPub.Size = New System.Drawing.Size(400, 83)
        Me.GroupBoxPub.TabIndex = 0
        Me.GroupBoxPub.TabStop = False
        Me.GroupBoxPub.Text = "Publication"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(424, 369)
        Me.Controls.Add(Me.GroupBoxPub)
        Me.Controls.Add(Me.ButtonInsert)
        Me.Controls.Add(Me.GroupBoxMedia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JWLibrary-MediaInserter"
        Me.GroupBoxMedia.ResumeLayout(False)
        Me.GroupBoxPub.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBoxPub As ComboBox
    Friend WithEvents ComboBoxWeek As ComboBox
    Friend WithEvents ButtonSelect As Button
    Friend WithEvents ButtonDelete As Button
    Friend WithEvents GroupBoxMedia As GroupBox
    Friend WithEvents ListBoxMedia As ListBox
    Friend WithEvents ButtonInsert As Button
    Friend WithEvents GroupBoxPub As GroupBox
End Class

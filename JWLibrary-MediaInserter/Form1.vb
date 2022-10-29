' Imports System.Threading
Public Class Form1

    Dim pubs As List(Of Publication)
    Dim documents As List(Of Document)
    Dim mediaList As New List(Of String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-6.0
        ' Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("en-us")
        ' Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("it-IT")
        ' Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("es-ES")
        ' Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("pt-BR")

        Me.Icon = My.Resources.Ico
        ButtonSelect.Text = My.Resources.buttonSelect
        ButtonDelete.Text = My.Resources.buttonDelete
        ButtonInsert.Text = My.Resources.buttonInsert
        ButtonRestoreBackup.Text = My.Resources.buttonRestore
        ButtonJWPUB.Text = My.Resources.buttonExport
        CheckBoxShowAll.Text = My.Resources.checkShowAll
        GroupBoxPub.Text = My.Resources.groupPub
        GroupBoxAdvanced.Text = My.Resources.groupAdvanced

        pubs = New List(Of Publication)
        UpdatePubs(False)
    End Sub

    Sub UpdatePubs(Advanced As Boolean)
        pubs.Clear()
        pubs.AddRange(FindPubs.getPubs(Advanced))
        pubs = pubs.OrderBy(Function(p) p.title).ToList()
        pubs = pubs.OrderByDescending(Function(p) p.tag).ToList()

        ComboBoxPub.DataSource = Nothing
        ComboBoxPub.Items.Clear()
        ComboBoxPub.DataSource = pubs
        ComboBoxPub.DisplayMember = "title"

        setCurrentPub()
    End Sub

    Sub setCurrentPub()
        Dim today = Now.DayOfWeek ' Fix localization
        Dim wDay = (today = DayOfWeek.Friday) Or (today = DayOfWeek.Saturday) Or (today = DayOfWeek.Sunday)

        Dim currentPubs = From pub In pubs Where pub.current And If(wDay, pub.symbol = PubSymbol.w, pub.symbol = PubSymbol.mwb)
        If currentPubs.Count = 0 Then currentPubs = From pub In pubs Where pub.current
        If currentPubs.Count > 0 Then
            Dim currentPub = currentPubs(0)
            ComboBoxPub.SelectedItem = currentPub
        End If
    End Sub

    Private Sub ComboBoxPub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPub.SelectedIndexChanged
        documents = New List(Of Document)
        If ComboBoxPub.SelectedIndex = -1 Then Exit Sub
        Dim pub As Publication = ComboBoxPub.SelectedItem
        documents.AddRange(FindDocuments.getDocuments(pub))

        documents = If(pub.symbol = PubSymbol.other, documents.OrderBy(Function(d) d.documentId).ToList(), documents.OrderByDescending(Function(d) d.firstDate).ToList())

        ComboBoxDocs.DataSource = documents
        ComboBoxDocs.DisplayMember = "docTitle"

        Dim currentDocs = From doc In documents Where doc.current
        If currentDocs.Count > 0 Then
            Dim currentDoc = currentDocs(0)
            ComboBoxDocs.SelectedItem = currentDoc
        End If

        ButtonRestoreBackup.Enabled = pub.hasBackup
    End Sub

    Private Sub ButtonSelect_Click(sender As Object, e As EventArgs) Handles ButtonSelect.Click
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Filter = My.Resources.dialogFiler + "| *.jpg; *.jpeg; *.png; *.mp4; *.JPG; *.JPEG; *.PNG; *.MP4"

        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        OpenFileDialog1.Multiselect = True
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each mediaFile In OpenFileDialog1.FileNames
                mediaList.Add(mediaFile)
            Next
        End If

        ListBoxMedia.DataSource = Nothing
        ListBoxMedia.Items.Clear()
        ListBoxMedia.DataSource = mediaList
        ButtonDelete.Enabled = Not mediaList.Count = 0
    End Sub

    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        If ListBoxMedia.SelectedIndex = -1 Then mediaList.Clear() Else mediaList.RemoveAt(ListBoxMedia.SelectedIndex)
        ListBoxMedia.DataSource = Nothing
        ListBoxMedia.Items.Clear()
        ListBoxMedia.DataSource = mediaList
    End Sub

    Private Sub ButtonInsert_Click(sender As Object, e As EventArgs) Handles ButtonInsert.Click
        If ComboBoxDocs.SelectedIndex = -1 Then Return
        Dim doc As Document = ComboBoxDocs.SelectedItem
        doc.pub.makeBackup()
        For Each mediaPath In mediaList
            If LCase(mediaPath).EndsWith(".mp4") Then
                Dim videoDir As String = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) & "\JWLibrary"
                If Not System.IO.Directory.Exists(videoDir) Then System.IO.Directory.CreateDirectory(videoDir)
                System.IO.File.Copy(mediaPath, videoDir & "\" & mediaPath.ToString.Split("\").Last, True)
                AddVideo(doc, mediaPath)
            Else
                System.IO.File.Copy(mediaPath, doc.pub.path & "\" & mediaPath.ToString.Split("\").Last, True)
                AddImg(doc, mediaPath)
            End If
        Next

        mediaList.Clear()
        ListBoxMedia.DataSource = Nothing
        ListBoxMedia.Items.Clear()
        ListBoxMedia.DataSource = mediaList
        ButtonDelete.Enabled = Not mediaList.Count = 0

        ComboBoxPub.DisplayMember = ""
        ComboBoxPub.DisplayMember = "title"
    End Sub

    Private Sub ButtonRestoreBackup_Click(sender As Object, e As EventArgs) Handles ButtonRestoreBackup.Click
        If ComboBoxPub.SelectedIndex = -1 Then Return
        If Not CheckJW() Then Return

        Dim pub As Publication = ComboBoxPub.SelectedItem
        pub.restoreBackup()

        ComboBoxPub.DisplayMember = ""
        ComboBoxPub.DisplayMember = "title"
    End Sub

    Function CheckJW() As Boolean
        Dim proc() As Process
        proc = Process.GetProcessesByName("JWLibrary")
        If proc.Count > 0 Then
            Dim result = MsgBox(My.Resources.errorJWL, MsgBoxStyle.RetryCancel, Me.Text)
            If result = MsgBoxResult.Cancel Then
                Return False
            Else
                Return CheckJW()
            End If
        End If
        Return True
    End Function

    Private Sub ListBoxMedia_DragEnter(sender As Object, e As DragEventArgs) Handles ListBoxMedia.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub ListBoxMedia_DragDrop(sender As Object, e As DragEventArgs) Handles ListBoxMedia.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each filePath In files
            If Not IO.File.Exists(filePath) Then Continue For
            Dim lCasedPath = LCase(filePath)
            If Not ((lCasedPath.EndsWith(".jpg")) Or (lCasedPath.EndsWith(".jpeg")) Or (lCasedPath.EndsWith(".png")) Or (lCasedPath.EndsWith(".mp4"))) Then Continue For
            mediaList.Add(filePath)
        Next

        ListBoxMedia.DataSource = Nothing
        ListBoxMedia.Items.Clear()
        ListBoxMedia.DataSource = mediaList
        ButtonDelete.Enabled = Not mediaList.Count = 0
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then setCurrentPub()
    End Sub

    Private Sub CheckBoxShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowAll.CheckedChanged
        UpdatePubs(True)
    End Sub

    Private Sub ButtonJWPUB_Click(sender As Object, e As EventArgs) Handles ButtonJWPUB.Click
        If ComboBoxPub.SelectedIndex = -1 Then Return

        Dim pub As Publication = ComboBoxPub.SelectedItem
        pub.export()
    End Sub
End Class
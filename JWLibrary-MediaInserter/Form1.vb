Public Class Form1

    Dim pubs As List(Of Publication)
    Dim weeks As List(Of Week)
    Dim mediaList As New List(Of String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Ico
        ButtonSelect.Text = My.Resources.buttonSelect
        ButtonDelete.Text = My.Resources.buttonDelete
        ButtonInsert.Text = My.Resources.buttonInsert
        GroupBoxPub.Text = My.Resources.groupPub

        pubs = New List(Of Publication)
        pubs.AddRange(FindPubs.getPubs())
        pubs = pubs.OrderByDescending(Function(p) p.tag).ToList()

        ComboBoxPub.DataSource = pubs
        ComboBoxPub.DisplayMember = "title"

        Dim currentPubs = From pub In pubs Where pub.current And If(Now.DayOfWeek > 4, pub.symbol = PubSymbol.w, pub.symbol = PubSymbol.mwb)
        If currentPubs.Count = 0 Then currentPubs = From pub In pubs Where pub.current
        If currentPubs.Count > 0 Then
            Dim currentPub = currentPubs(0)
            ComboBoxPub.SelectedItem = currentPub
        End If
    End Sub

    Private Sub ComboBoxPub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPub.SelectedIndexChanged
        weeks = New List(Of Week)
        Dim pub = ComboBoxPub.SelectedItem
        weeks.AddRange(FindWeeks.getWeeks(pub))
        weeks = weeks.OrderByDescending(Function(w) w.firstDate).ToList()

        ComboBoxWeek.DataSource = weeks
        ComboBoxWeek.DisplayMember = "dateString"

        Dim currentWeeks = From wk In weeks Where wk.current
        If currentWeeks.Count > 0 Then
            Dim currentWeek = currentWeeks(0)
            ComboBoxWeek.SelectedItem = currentWeek
        End If
    End Sub

    Private Sub ComboBoxWeek_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxWeek.SelectedIndexChanged

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
        If ComboBoxWeek.SelectedIndex = -1 Then Return
        Dim wk As Week = ComboBoxWeek.SelectedItem
        For Each mediaPath In mediaList
            If LCase(mediaPath).EndsWith(".mp4") Then
                Dim videoDir As String = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) & "\JWLibrary"
                System.IO.File.Copy(mediaPath, videoDir & "\" & mediaPath.ToString.Split("\").Last, True)
                AddVideo(wk, mediaPath)
            Else
                System.IO.File.Copy(mediaPath, wk.pub.path & "\" & mediaPath.ToString.Split("\").Last, True)
                AddImg(wk, mediaPath)
            End If
        Next

        mediaList.Clear()
        ListBoxMedia.DataSource = Nothing
        ListBoxMedia.Items.Clear()
        ListBoxMedia.DataSource = mediaList
        ButtonDelete.Enabled = Not mediaList.Count = 0
    End Sub
End Class

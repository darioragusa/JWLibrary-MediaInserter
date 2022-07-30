Imports System.IO
Imports System.IO.Compression

Class Publication
    Property name As String
    Property tag As Integer
    Property path As String
    Property current As Boolean
    Property symbol As PubSymbol
    Property title As String
        Get
            Return getTitle()
        End Get
        Set(value As String)
        End Set
    End Property
    Property hasBackup As Boolean
        Get
            Return IO.Directory.Exists(path + ".bak")
        End Get
        Set(value As Boolean)
        End Set
    End Property
    Function getTitle() As String
        Try
            Dim manifestPath As String = path & "\manifest.json"
            Dim manifest = File.ReadAllText(manifestPath)
            Dim manifestJObj As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(manifest)
            Dim title = CStr(manifestJObj.SelectToken(If(symbol = PubSymbol.other, "publication.title", "publication.issueProperties.title")))
            Return title & If(hasBackup, "*", "")
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Sub makeBackup()
        If hasBackup Then Return
        My.Computer.FileSystem.CopyDirectory(path, path + ".bak")
    End Sub

    Sub restoreBackup()
        If Not hasBackup Then Return
        Try
            My.Computer.FileSystem.DeleteFile(path + "\" & name & ".db")
        Catch ex As Exception
            MsgBox(My.Resources.errorRestoreGeneric, MsgBoxStyle.Critical, "JWLibrary-MediaInserter")
            Return
        End Try
        My.Computer.FileSystem.DeleteDirectory(path, FileIO.DeleteDirectoryOption.DeleteAllContents)
        My.Computer.FileSystem.MoveDirectory(path + ".bak", path)
    End Sub

    Sub export()
        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.Filter = "JWPUB file | *.jwpub"
        SaveFileDialog1.FileName = name & ".jwpub"
        SaveFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        If Not SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub

        'https://stackoverflow.com/questions/37442059/create-in-memory-zip-from-a-file
        If System.IO.File.Exists(path & "\contents") Then System.IO.File.Delete(path & "\contents")
        Dim fileList = System.IO.Directory.EnumerateFiles(path)
        Dim contentsMemoryStream = New MemoryStream
        Using contentsArchive = New System.IO.Compression.ZipArchive(contentsMemoryStream, IO.Compression.ZipArchiveMode.Create, True)
            For Each file In fileList
                If file.EndsWith(".json") Then Continue For
                contentsArchive.CreateEntryFromFile(file, file.Split("\").Last())
            Next
        End Using

        Dim pubMemoryStream = New MemoryStream
        Using pubArchive = New System.IO.Compression.ZipArchive(pubMemoryStream, IO.Compression.ZipArchiveMode.Create, True)
            Dim contentsEntry = pubArchive.CreateEntry("contents")
            Using contentsStream = contentsEntry.Open()
                contentsMemoryStream.Seek(0, SeekOrigin.Begin)
                contentsMemoryStream.CopyTo(contentsStream)
            End Using
            pubArchive.CreateEntryFromFile(path & "\manifest.json", "manifest.json")
        End Using

        Using fileStream = New FileStream(SaveFileDialog1.FileName, FileMode.Create)
            pubMemoryStream.Seek(0, SeekOrigin.Begin)
            pubMemoryStream.CopyTo(fileStream)
        End Using
    End Sub
End Class
Class Document
    Property pub As Publication
    Property documentId As Integer
    Property current As Boolean
    Property firstDate As Integer
    Property lastDate As Integer
    Private Property title As String
    Property docTitle As String
        Get
            Return getDocTitle()
        End Get
        Set(value As String)
            title = value
        End Set
    End Property

    Function getDocTitle() As String
        If pub.symbol = PubSymbol.other Then Return title
        Try
            Dim fDate = Format(firstDate).Insert(4, "-").Insert(7, "-")
            Dim lDate = Format(lastDate).Insert(4, "-").Insert(7, "-")
            Return My.Resources.dateStringFrom + " " + fDate + " " + My.Resources.dateStringTo + " " + lDate
        Catch ex As Exception
            Return ""
        End Try
    End Function

End Class

Enum PubSymbol As Byte
    w
    mwb
    other
End Enum
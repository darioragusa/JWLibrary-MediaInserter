Imports System.IO
Imports System.Data.SQLite

Module AddMedia
    Sub AddImg(wk As Week, ByVal imgPath As String)
        Dim dbPath As String = wk.pub.path & "\" & wk.pub.name & ".db"
        If Not System.IO.File.Exists(dbPath) Then Return
        Using SQLCon As New SQLiteConnection(String.Format("Data Source = {0}", dbPath))
            Dim insertMultimediaQuery As String = "INSERT INTO Multimedia(DataType, MajorType, MinorType, MimeType, Caption, FilePath, CategoryType) VALUES(@Data, @Major, @Minor, @Mime, @Caption, @File, @Category)"
            Dim insertDocumentMultimediaQuery As String = "INSERT INTO DocumentMultimedia(DocumentId, MultimediaId) VALUES(@Document, @Multimedia)"
            Dim mediaID As Integer = getLastMultimediaID(dbPath) + 1
            If mediaID > 0 Then
                SQLCon.Open()
                Dim imageName = imgPath.Split("\").Last()

                Dim multimediaCMD As New SQLiteCommand(insertMultimediaQuery, SQLCon)
                multimediaCMD.Parameters.AddWithValue("@Data", 0)
                multimediaCMD.Parameters.AddWithValue("@Major", 1)
                multimediaCMD.Parameters.AddWithValue("@Minor", 1)
                multimediaCMD.Parameters.AddWithValue("@Mime", "image/" & If(LCase(imageName).EndsWith("png"), "png", "jpeg"))
                multimediaCMD.Parameters.AddWithValue("@Caption", imageName)
                multimediaCMD.Parameters.AddWithValue("@Category", 15)
                multimediaCMD.Parameters.AddWithValue("@File", imageName)
                multimediaCMD.ExecuteNonQuery()

                Dim documentMultimediaCMD As New SQLiteCommand(insertDocumentMultimediaQuery, SQLCon)
                documentMultimediaCMD.Parameters.AddWithValue("@Document", CStr(wk.documentId))
                documentMultimediaCMD.Parameters.AddWithValue("@Multimedia", CStr(mediaID))
                documentMultimediaCMD.ExecuteNonQuery()

                SQLCon.Close()
            End If
        End Using
    End Sub

    Sub AddVideo(wk As Week, videoPath As String)
        Dim dbPath As String = wk.pub.path & "\" & wk.pub.name & ".db"
        If Not System.IO.File.Exists(dbPath) Then Return

        Dim collectionPath As String = findCollectionDirectory()
        If collectionPath = "" Then
            MsgBox(My.Resources.errorCollection404, MsgBoxStyle.Exclamation, "")
            Exit Sub
        End If
        Dim track = AddVideoToCollection(collectionPath, videoPath)

        Using SQLCon As New SQLiteConnection(String.Format("Data Source = {0}", dbPath))
            Dim insertMultimediaQuery As String = "INSERT INTO Multimedia(MultimediaId, DataType, MajorType, MinorType, MimeType, KeySymbol, Track, CategoryType, MepsLanguageIndex) VALUES(@MultimediaId, @Data, @Major, @Minor, @Mime, @KeySymbol, @Track, @Category, @Meps)"
            Dim insertDocumentMultimediaQuery As String = "INSERT INTO DocumentMultimedia(DocumentId, MultimediaId) VALUES(@Document, @Multimedia)"
            Dim mediaID As Integer = getLastMultimediaID(dbPath) + 1
            If mediaID > 0 Then
                SQLCon.Open()

                Dim multimediaCMD As New SQLiteCommand(insertMultimediaQuery, SQLCon)
                multimediaCMD.Parameters.AddWithValue("@MultimediaId", mediaID)
                multimediaCMD.Parameters.AddWithValue("@Data", 2)
                multimediaCMD.Parameters.AddWithValue("@Major", 2)
                multimediaCMD.Parameters.AddWithValue("@Minor", 3)
                multimediaCMD.Parameters.AddWithValue("@Mime", "video/mp4")
                multimediaCMD.Parameters.AddWithValue("@KeySymbol", "sjjm")
                multimediaCMD.Parameters.AddWithValue("@Track", track)
                multimediaCMD.Parameters.AddWithValue("@Category", -1)
                multimediaCMD.Parameters.AddWithValue("@Meps", 4)
                multimediaCMD.ExecuteNonQuery()

                Dim documentMultimediaCMD As New SQLiteCommand(insertDocumentMultimediaQuery, SQLCon)
                documentMultimediaCMD.Parameters.AddWithValue("@Document", CStr(wk.documentId))
                documentMultimediaCMD.Parameters.AddWithValue("@Multimedia", mediaID)
                documentMultimediaCMD.ExecuteNonQuery()
            End If
            SQLCon.Close()
        End Using
    End Sub

    Function AddVideoToCollection(dbDir As String, videoPath As String) As Integer
        Using SQLCon As New SQLiteConnection(String.Format("Data Source = {0}", dbDir))
            Dim insertMediaKeyQuery As String = "INSERT INTO MediaKey(MediaKeyId, KeySymbol, MediaType, DocumentId, MepsLanguageIndex, IssueTagNumber, Track, BookNumber) VALUES(@MediaKeyId, @KeySymbol, @MediaType, @DocumentId, @MepsLanguageIndex, @IssueTagNumber, @Track, @BookNumber)"
            Dim insertVideoQuery As String = "INSERT INTO Video(MediaKeyId, Title, Version, MimeType, BitRate, FrameRate, Duration, Checksum, FileSize, FrameHeight, FrameWidth, Label, Subtitled, DownloadUrl, FilePath, Source) VALUES(@MediaKeyId, @Title, @Version, @MimeType, @BitRate, @FrameRate, @Duration, @Checksum, @FileSize, @FrameHeight, @FrameWidth, @Label, @Subtitled, @DownloadUrl, @FilePath, @Source)"
            SQLCon.Open()
            Dim videoName = videoPath.Split("\").Last
            Dim NewID = getLastMediaKeyID(dbDir) + 1
            Dim trackNo = NewID + 1000

            Dim mediaKeyCMD As New SQLiteCommand(insertMediaKeyQuery, SQLCon)
            mediaKeyCMD.Parameters.AddWithValue("@MediaKeyId", NewID)
            mediaKeyCMD.Parameters.AddWithValue("@KeySymbol", "sjjm") ' Fake song
            mediaKeyCMD.Parameters.AddWithValue("@MediaType", 1)
            mediaKeyCMD.Parameters.AddWithValue("@DocumentId", 0)
            mediaKeyCMD.Parameters.AddWithValue("@MepsLanguageIndex", 4)
            mediaKeyCMD.Parameters.AddWithValue("@IssueTagNumber", 0)
            mediaKeyCMD.Parameters.AddWithValue("@Track", trackNo)
            mediaKeyCMD.Parameters.AddWithValue("@BookNumber", "0")
            mediaKeyCMD.ExecuteNonQuery()

            Dim videoCMD As New SQLiteCommand(insertVideoQuery, SQLCon)
            videoCMD.Parameters.AddWithValue("@MediaKeyId", NewID)
            videoCMD.Parameters.AddWithValue("@Title", videoName.Replace(".mp4", "").Replace(".MP4", ""))
            videoCMD.Parameters.AddWithValue("@Version", 1)
            videoCMD.Parameters.AddWithValue("@MimeType", "video/mp4")
            videoCMD.Parameters.AddWithValue("@BitRate", 1000) 'No matter
            videoCMD.Parameters.AddWithValue("@FrameRate", 30) 'No matter
            videoCMD.Parameters.AddWithValue("@Duration", 1) 'No matter
            videoCMD.Parameters.AddWithValue("@Checksum", "") 'No matter
            videoCMD.Parameters.AddWithValue("@FileSize", CStr(FileLen(videoPath)))
            videoCMD.Parameters.AddWithValue("@FrameHeight", 720) 'No matter
            videoCMD.Parameters.AddWithValue("@FrameWidth", 1280) 'No matter
            videoCMD.Parameters.AddWithValue("@Label", "720p") 'No matter
            videoCMD.Parameters.AddWithValue("@Subtitled", 0)
            videoCMD.Parameters.AddWithValue("@DownloadUrl", "https://github.com/darioragusa") 'No matter
            videoCMD.Parameters.AddWithValue("@FilePath", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) & "\JWLibrary\" & videoName)
            videoCMD.Parameters.AddWithValue("@Source", 0)
            videoCMD.ExecuteNonQuery()

            SQLCon.Close()
            Return trackNo
        End Using
    End Function

    Function getLastMediaKeyID(ByVal dbDir As String) As Integer
        getLastMediaKeyID = -1
        If Not System.IO.File.Exists(dbDir) Then Exit Function
        Using sqlCon As New SQLiteConnection(String.Format("Data Source = {0}", dbDir))
            Dim readIdQuery As String = "SELECT MAX(MediaKeyId) FROM MediaKey"
            sqlCon.Open()
            Using command = sqlCon.CreateCommand()
                command.CommandText = readIdQuery
                Using reader = command.ExecuteReader()
                    Try
                        If reader.Read() Then getLastMediaKeyID = reader.GetInt32(0)
                    Catch ex As Exception
                        getLastMediaKeyID = 1
                    End Try
                End Using
            End Using
            sqlCon.Close()
        End Using
    End Function

    Function getLastMultimediaID(ByVal dbDir As String) As Integer
        getLastMultimediaID = -1
        If Not System.IO.File.Exists(dbDir) Then Exit Function
        Using sqlCon As New SQLiteConnection(String.Format("Data Source = {0}", dbDir))
            Dim readWeekQuery As String = "SELECT Max(MultimediaId) FROM Multimedia"
            sqlCon.Open()
            Using command = sqlCon.CreateCommand()
                command.CommandText = readWeekQuery
                Using reader = command.ExecuteReader()
                    Try
                        If reader.Read() Then getLastMultimediaID = reader.GetInt32(0)
                    Catch ex As Exception
                        getLastMultimediaID = 1
                    End Try
                End Using
            End Using
            sqlCon.Close()
        End Using
    End Function

    Function findCollectionDirectory() As String
        findCollectionDirectory = ""
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Packages"
        If IO.Directory.Exists(path) Then
            For Each Dir As String In Directory.GetDirectories(path)
                If LCase(Dir).Contains("watchtower") Then
                    path = Dir & "\LocalState\Data\mediaCollection.db"
                    Exit For
                End If
            Next
        End If
        If IO.File.Exists(path) Then findCollectionDirectory = path
    End Function
End Module

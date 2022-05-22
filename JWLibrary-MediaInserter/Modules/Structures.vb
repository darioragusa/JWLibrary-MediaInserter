Imports System.IO
Imports Newtonsoft.Json

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
            Dim title = CStr(manifestJObj.SelectToken("publication.issueProperties.title"))
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
End Class
Class Week
    Property pub As Publication
    Property documentId As Integer
    Property current As Boolean
    Property firstDate As Integer
    Property lastDate As Integer
    Property dateString As String
        Get
            Return getDateString()
        End Get
        Set(value As String)
        End Set
    End Property

    Function getDateString() As String
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
End Enum
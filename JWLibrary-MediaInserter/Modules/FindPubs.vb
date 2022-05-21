Imports System.IO
Imports System.Data.SQLite

Module FindPubs
    Function getPubsDirectory() As String
        getPubsDirectory = ""
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Packages"
        If IO.Directory.Exists(path) Then
            For Each Dir As String In Directory.GetDirectories(path)
                If LCase(Dir).Contains("watchtower") Then
                    path = Dir & "\LocalState\Publications"
                    Exit For
                End If
            Next
        End If
        If IO.Directory.Exists(path) Then getPubsDirectory = path
    End Function

    Function getPubs() As List(Of Publication)
        getPubs = New List(Of Publication)
        Dim pubsPath As String = getPubsDirectory()
        If pubsPath = "" Then Exit Function
        Dim collectionPath As String = pubsPath.Replace("\Publications", "\Data\pub_collections.db")
        Dim currDate = Now.Date.ToString("yyyyMMdd")
        Dim tagNumberw As String = "000000"
        Dim tagNumbermwb As String = "000000"

        If System.IO.File.Exists(collectionPath) Then
            Using sqlCon As New SQLiteConnection(String.Format("Data Source = {0}", collectionPath))
                Dim queryw As String = "SELECT SUBSTR(IssueTagNumber, 1, 6) FROM Publication WHERE KeySymbol = 'w' AND " & currDate & " BETWEEN FirstDatedTextDateOffset AND LastDatedTextDateOffset"
                Dim querymwb As String = "SELECT SUBSTR(IssueTagNumber, 1, 6) FROM Publication WHERE KeySymbol = 'mwb' AND " & currDate & " BETWEEN FirstDatedTextDateOffset AND LastDatedTextDateOffset"
                sqlCon.Open()
                Using commandW = sqlCon.CreateCommand()
                    commandW.CommandText = queryw
                    Using reader = commandW.ExecuteReader()
                        If reader.Read() Then tagNumberw = reader.GetString(0)
                    End Using
                End Using
                Using commandmwb = sqlCon.CreateCommand()
                    commandmwb.CommandText = querymwb
                    Using reader = commandmwb.ExecuteReader()
                        If reader.Read() Then tagNumbermwb = reader.GetString(0)
                    End Using
                End Using
                sqlCon.Close()
            End Using
        End If

        For Each pubDirectory In IO.Directory.EnumerateDirectories(pubsPath)
            Dim pubName As String = pubDirectory.ToString.Split("\").Last
            If pubName.StartsWith("w_") Or pubName.StartsWith("mwb_") Then
                Try
                    Dim pub As Publication = New Publication
                    pub.name = pubName
                    pub.tag = CInt(pubName.Substring(pubName.Length - 6))
                    pub.path = pubDirectory
                    pub.symbol = If(pubName.StartsWith("w_"), PubSymbol.w, PubSymbol.mwb)
                    pub.current = If(pubName.StartsWith("w_"), pubName.EndsWith(tagNumberw), pubName.EndsWith(tagNumbermwb))
                    getPubs.Add(pub)
                Catch ex As Exception
                    ' It doesn't matter
                End Try
            End If
        Next
    End Function
End Module

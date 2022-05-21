Imports System.Data.SQLite

Module FindWeeks
    Function getWeeks(pub As Publication) As List(Of Week)
        getWeeks = New List(Of Week)
        Dim dbPath As String = pub.path & "\" & pub.name & ".db"
        If Not System.IO.File.Exists(dbPath) Then Exit Function
        Dim currDate = CInt(Now.Date.ToString("yyyyMMdd"))

        Using sqlCon As New SQLiteConnection(String.Format("Data Source = {0}", dbPath))
            Dim readWeekQuery As String = "SELECT DatedTextId, DocumentId, FirstDateOffset, LastDateOffset FROM DatedText"
            sqlCon.Open()
            Using command = sqlCon.CreateCommand()
                command.CommandText = readWeekQuery
                Using reader = command.ExecuteReader()
                    While reader.Read()
                        Try
                            Dim pubWeek As Week = New Week
                            pubWeek.pub = pub
                            If pub.symbol = PubSymbol.w Then
                                Dim datedTextId = reader.GetInt32(0)
                                pubWeek.documentId = getWDocumentID(dbPath, datedTextId)
                                If pubWeek.documentId = -1 Then Continue While
                            Else
                                pubWeek.documentId = reader.GetInt32(1) + 1 ' Must use an article
                            End If
                            pubWeek.firstDate = reader.GetInt32(2)
                            pubWeek.lastDate = reader.GetInt32(3)
                            pubWeek.current = pubWeek.firstDate <= currDate And currDate <= pubWeek.lastDate
                            getWeeks.Add(pubWeek)
                        Catch ex As Exception
                            ' Invalid week?
                        End Try
                    End While
                End Using
            End Using
            sqlCon.Close()
        End Using
    End Function

    Function getWDocumentID(dbPath As String, weekN As Integer) As Integer
        If Not System.IO.File.Exists(dbPath) Then Return -1
        Dim returnID As Integer = -1
        Using sqlCon As New SQLiteConnection(String.Format("Data Source = {0}", dbPath))
            Dim readWeekQuery As String = "SELECT DocumentId FROM Document WHERE Class = 40 LIMIT " & (weekN - 1) & ", 1"
            sqlCon.Open()
            Using command = sqlCon.CreateCommand()
                command.CommandText = readWeekQuery
                Dim actWeekN As Integer = 1
                Using reader = command.ExecuteReader()
                    If reader.Read() Then returnID = reader.GetInt32(0)
                End Using
            End Using
            sqlCon.Close()
        End Using
        Return returnID
    End Function
End Module

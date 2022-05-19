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
    Function getTitle() As String
        Try
            Dim manifestPath As String = path & "\manifest.json"
            Dim manifest = File.ReadAllText(manifestPath)
            Dim manifestJObj As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(manifest)
            Return CStr(manifestJObj.SelectToken("publication.issueProperties.title"))
        Catch ex As Exception
            Return ""
        End Try
    End Function
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
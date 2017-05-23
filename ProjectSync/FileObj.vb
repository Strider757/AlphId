Public Class FileObj
    Private fName As String
    Private fLocation As String

    Public Property Name() As String
        Get
            Return fName
        End Get
        Set(value As String)
            fName = value
        End Set
    End Property

    Public Property Location() As String
        Get
            Return fLocation
        End Get
        Set(value As String)
            fLocation = value
        End Set
    End Property
End Class

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
            If Right(value, Len(value) - Len(value) + 1) = "\" Then
                value = Left(value, Len(value) - 1)
            End If
            fLocation = value
        End Set
    End Property
End Class

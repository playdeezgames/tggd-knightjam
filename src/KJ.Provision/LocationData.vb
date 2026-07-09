Public Class LocationData
    Inherits KJEntityData
    Public Property CharacterIds As New HashSet(Of Guid)
    Public Property RouteIds As New Dictionary(Of String, Guid)(StringComparer.InvariantCultureIgnoreCase)
End Class

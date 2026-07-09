Imports TGGD.Provision

Public Class WorldData
    Inherits EntityData
    Public Property Messages As New List(Of MessageData)
    Public Property Locations As New Dictionary(Of Guid, LocationData)
End Class

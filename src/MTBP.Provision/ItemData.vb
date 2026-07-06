Public Class ItemData
    Inherits MTBPEntityData
    Public Property InventoryId As Guid
    Public Property VerbIds As New HashSet(Of Guid)
End Class

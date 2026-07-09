Imports KJ.Provision

Friend Class Item
    Inherits KJEntity(Of ItemData)
    Implements IItem

    Private Sub New(world As IWorld, data As WorldData, itemId As Guid)
        MyBase.New(world, data)
        Me.ItemId = itemId
    End Sub

    Public ReadOnly Property ItemId As Guid Implements IItem.ItemId

    Protected Overrides ReadOnly Property Data As ItemData
        Get
            Return _data.Items(ItemId)
        End Get
    End Property

    Friend Shared Function Create(world As IWorld, data As WorldData, itemId As Guid?) As IItem
        Return If(
            itemId.HasValue,
            New Item(world, data, itemId.Value),
            Nothing)
    End Function
End Class

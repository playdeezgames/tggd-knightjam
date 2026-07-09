Imports KJ.Provision

Friend Class Inventory
    Implements IInventory

    Private ReadOnly world As IWorld
    Private ReadOnly _data As WorldData

    Public Sub New(world As IWorld, data As WorldData, inventoryId As Guid)
        Me.world = world
        Me._data = data
        Me.InventoryId = inventoryId
    End Sub

    Private ReadOnly Property Data As InventoryData
        Get
            Return _data.Inventories(InventoryId)
        End Get
    End Property

    Public ReadOnly Property InventoryId As Guid Implements IInventory.InventoryId

    Friend Shared Function Create(world As IWorld, data As WorldData, inventoryId As Guid?) As IInventory
        Return If(inventoryId.HasValue, New Inventory(world, data, inventoryId.Value), Nothing)
    End Function
End Class

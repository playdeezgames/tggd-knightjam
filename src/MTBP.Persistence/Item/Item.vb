Imports MTBP.Provision

Friend Class Item
    Inherits MTBPEntity(Of ItemData)
    Implements IItem

    Private Sub New(world As IWorld, data As WorldData, itemId As Guid)
        MyBase.New(world, data)
        Me.ItemId = itemId
    End Sub

    Public ReadOnly Property ItemId As Guid Implements IItem.ItemId

    Public Property Inventory As IInventory Implements IItem.Inventory
        Get
            Return Persistence.Inventory.Create(World, _data, Data.InventoryId)
        End Get
        Set(value As IInventory)
            _data.Inventories(Data.InventoryId).ItemIds.Remove(ItemId)
            Data.InventoryId = value.InventoryId
            _data.Inventories(Data.InventoryId).ItemIds.Add(ItemId)
        End Set
    End Property

    Public ReadOnly Property Verbs As IEnumerable(Of IVerb) Implements IItem.Verbs
        Get
            Return Data.VerbIds.Select(Function(x) Verb.Create(World, _data, x))
        End Get
    End Property

    Public ReadOnly Property Exists As Boolean Implements IItem.Exists
        Get
            Return _data.Items.ContainsKey(ItemId)
        End Get
    End Property

    Protected Overrides ReadOnly Property Data As ItemData
        Get
            Return _data.Items(ItemId)
        End Get
    End Property

    Public Sub Destroy() Implements IItem.Destroy
        _data.Inventories(Data.InventoryId).ItemIds.Remove(ItemId)
        _data.Items.Remove(ItemId)
    End Sub

    Friend Shared Function Create(world As IWorld, data As WorldData, itemId As Guid) As IItem
        Return New Item(world, data, itemId)
    End Function

    Public Function CreateVerb(Optional initializer As VerbInitializer = Nothing) As IVerb Implements IItem.CreateVerb
        Dim verbId = Guid.NewGuid
        _data.Verbs(verbId) = New VerbData
        Data.VerbIds.Add(verbId)
        Dim result As IVerb = Verb.Create(World, _data, verbId)
        initializer?.Invoke(result)
        Return result
    End Function
End Class

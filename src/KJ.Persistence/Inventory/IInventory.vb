Public Interface IInventory
    ReadOnly Property InventoryId As Guid
    Function CreateItem(Optional initializer As ItemInitializer = Nothing) As IItem
    ReadOnly Property HasItems As Boolean
    ReadOnly Property Items As IEnumerable(Of IItem)
End Interface

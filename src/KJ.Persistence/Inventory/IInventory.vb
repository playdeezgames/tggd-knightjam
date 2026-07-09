Public Interface IInventory
    ReadOnly Property InventoryId As Guid
    Function CreateItem(Optional initializer As ItemInitializer = Nothing) As IItem
End Interface

Public Delegate Sub ItemInitializer(item As IItem)
Public Interface IItem
    Inherits IMTBPEntity
    ReadOnly Property ItemId As Guid
    Property Inventory As IInventory
    Function CreateVerb(Optional initializer As VerbInitializer = Nothing) As IVerb
    Sub Destroy()
    ReadOnly Property Verbs As IEnumerable(Of IVerb)
    ReadOnly Property Exists As Boolean
End Interface

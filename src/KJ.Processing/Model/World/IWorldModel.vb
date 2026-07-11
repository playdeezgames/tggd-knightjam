Imports TGGD.Persistence
Imports TGGD.Processing

Public Interface IWorldModel
    Inherits IModel
    ReadOnly Property IsQuittable As Boolean
    Sub Embark(chosenName As String)
    Sub Abandon()
    Sub Look()
    ReadOnly Property Messages As IEnumerable(Of IMessage)
    ReadOnly Property Exits As IExitsModel
    ReadOnly Property Ground As IGroundModel
    ReadOnly Property Inventory As IInventoryModel
    ReadOnly Property Features As IFeaturesModel
    ReadOnly Property Characters As ICharactersModel
End Interface

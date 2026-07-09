Imports TGGD.Persistence
Imports TGGD.Processing

Public Interface IWorldModel
    Inherits IModel
    ReadOnly Property IsQuittable As Boolean
    Sub Embark(chosenName As String)
    Sub Abandon()
    ReadOnly Property Messages As IEnumerable(Of IMessage)
    ReadOnly Property Exits As IExitsModel
End Interface

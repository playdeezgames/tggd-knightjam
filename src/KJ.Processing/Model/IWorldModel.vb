Imports TGGD.Processing

Public Interface IWorldModel
    Inherits IModel
    ReadOnly Property IsQuittable As Boolean
    Sub Embark()
    Sub Abandon()
    'TODO: ReadOnly Property Messages As IEnumerable(Of String)
End Interface

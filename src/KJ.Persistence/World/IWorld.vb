Imports TGGD.Persistence

Public Interface IWorld
    Inherits IEntity
    Function Save(filename As String) As Task

    'TODO: messages? (become its own thing in TGGD.Persistence)
    'ReadOnly Property Messages As IEnumerable(Of String)
    'Sub ClearMessages()
    'Sub AddMessage(message As String)
End Interface

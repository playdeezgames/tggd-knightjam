Imports TGGD.Persistence

Public Interface IWorld
    Inherits IEntity
    Function Save(filename As String) As Task
    ReadOnly Property Messages As IEnumerable(Of IMessage)
    Sub ClearMessages()
    Sub AddMessage(text As String, Optional hints As IDictionary(Of String, String) = Nothing)
End Interface

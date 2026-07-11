Public Delegate Sub CharacterInitializer(character As ICharacter)
Public Interface ICharacter
    Inherits IInventoriedEntity
    ReadOnly Property CharacterId As Guid
    Property Location As ILocation
    Function CreateVerb(verbType As String, Optional initializer As VerbInitializer = Nothing) As IVerb
    ReadOnly Property Verbs As IEnumerable(Of IVerb)
End Interface

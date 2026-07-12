Public Delegate Sub CharacterInitializer(character As ICharacter)
Public Interface ICharacter
    Inherits IVerbableEntity
    ReadOnly Property CharacterId As Guid
    Property Location As ILocation
End Interface

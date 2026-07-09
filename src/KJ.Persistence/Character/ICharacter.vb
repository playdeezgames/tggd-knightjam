Public Delegate Sub CharacterInitializer(character As ICharacter)
Public Interface ICharacter
    Inherits IKJEntity
    ReadOnly Property CharacterId As Guid
End Interface

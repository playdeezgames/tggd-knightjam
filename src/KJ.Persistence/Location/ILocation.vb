Public Delegate Sub LocationInitializer(location As ILocation)
Public Interface ILocation
    Inherits IKJEntity
    ReadOnly Property LocationId As Guid
    Function CreateCharacter(Optional initialize As CharacterInitializer = Nothing) As ICharacter
End Interface

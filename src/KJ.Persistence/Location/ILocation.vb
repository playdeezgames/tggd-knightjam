Public Delegate Sub LocationInitializer(location As ILocation)
Public Interface ILocation
    Inherits IKJEntity
    ReadOnly Property LocationId As Guid
    Function CreateCharacter(Optional initialize As CharacterInitializer = Nothing) As ICharacter
    Function CreateRoute(direction As String, destination As ILocation, Optional initialize As RouteInitializer = Nothing) As IRoute
End Interface

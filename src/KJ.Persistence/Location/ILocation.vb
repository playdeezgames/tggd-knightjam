Public Delegate Sub LocationInitializer(location As ILocation)
Public Interface ILocation
    Inherits IVerbableEntity
    ReadOnly Property LocationId As Guid
    ReadOnly Property HasRoutes As Boolean
    Function CreateCharacter(Optional initialize As CharacterInitializer = Nothing) As ICharacter
    Function CreateRoute(direction As String, destination As ILocation, Optional initialize As RouteInitializer = Nothing) As IRoute
    ReadOnly Property Routes As IEnumerable(Of IRoute)
    Function CreateFeature(Optional initializer As FeatureInitializer = Nothing) As IFeature
    ReadOnly Property Features As IEnumerable(Of IFeature)
    ReadOnly Property HasFeatures As Boolean
    Function GetOtherCharacters(character As ICharacter) As IEnumerable(Of ICharacter)
    Function HasOtherCharacters(character As ICharacter) As Boolean
End Interface

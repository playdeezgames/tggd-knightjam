Imports KJ.Provision

Friend Class Location
    Inherits KJEntity(Of LocationData)
    Implements ILocation

    Private Sub New(world As IWorld, data As WorldData, locationId As Guid)
        MyBase.New(world, data)
        Me.LocationId = locationId
    End Sub

    Public ReadOnly Property LocationId As Guid Implements ILocation.LocationId

    Public ReadOnly Property HasRoutes As Boolean Implements ILocation.HasRoutes
        Get
            Return Data.RouteIds.Count <> 0
        End Get
    End Property

    Public ReadOnly Property Routes As IEnumerable(Of IRoute) Implements ILocation.Routes
        Get
            Return Data.RouteIds.Select(Function(x) Route.Create(World, _data, x.Key, x.Value))
        End Get
    End Property

    Protected Overrides ReadOnly Property Data As LocationData
        Get
            Return _data.Locations(LocationId)
        End Get
    End Property

    Friend Shared Function Create(world As IWorld, data As WorldData, locationId As Guid?) As ILocation
        Return If(locationId.HasValue, New Location(world, data, locationId.Value), Nothing)
    End Function

    Public Function CreateCharacter(Optional initialize As CharacterInitializer = Nothing) As ICharacter Implements ILocation.CreateCharacter
        Dim characterId = Guid.NewGuid
        _data.Characters(characterId) = New CharacterData With
            {
                .LocationId = LocationId
            }
        Data.CharacterIds.Add(characterId)
        Dim result = Character.Create(World, _data, characterId)
        initialize?.Invoke(result)
        Return result
    End Function

    Public Function CreateRoute(direction As String, destination As ILocation, Optional initialize As RouteInitializer = Nothing) As IRoute Implements ILocation.CreateRoute
        Dim routeId = Guid.NewGuid
        _data.Routes(routeId) = New RouteData With
            {
                .DestinationLocationId = destination.LocationId
            }
        Data.RouteIds(direction) = routeId
        Dim result As IRoute = Route.Create(World, _data, direction, routeId)
        initialize?.Invoke(result)
        Return result
    End Function
End Class

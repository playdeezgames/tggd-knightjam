Imports KJ.Provision

Friend Class Location
    Inherits KJEntity(Of LocationData)
    Implements ILocation

    Private Sub New(world As IWorld, data As WorldData, locationId As Guid)
        MyBase.New(world, data)
        Me.LocationId = locationId
    End Sub

    Public ReadOnly Property LocationId As Guid Implements ILocation.LocationId

    Protected Overrides ReadOnly Property Data As LocationData
        Get
            Return _data.Locations(LocationId)
        End Get
    End Property

    Friend Shared Function Create(world As World, data As WorldData, locationId As Guid?) As ILocation
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
End Class

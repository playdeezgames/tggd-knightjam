Imports KJ.Persistence

Friend Class CharactersModel
    Implements ICharactersModel

    Private ReadOnly world As IWorld

    Private Sub New(world As IWorld)
        Me.world = world
    End Sub

    Public ReadOnly Property HasAny As Boolean Implements ICharactersModel.HasAny
        Get
            Return world.Avatar.Location.HasOtherCharacters(world.Avatar)
        End Get
    End Property

    Public ReadOnly Property Characters As IEnumerable(Of ICharacterModel) Implements ICharactersModel.Characters
        Get
            Return world.Avatar.Location.GetOtherCharacters(world.Avatar).Select(AddressOf CharacterModel.Create)
        End Get
    End Property

    Friend Shared Function Create(entity As IWorld) As ICharactersModel
        Return New CharactersModel(entity)
    End Function
End Class

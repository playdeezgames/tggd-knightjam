Imports KJ.Provision

Friend Class Character
    Inherits KJEntity(Of CharacterData)
    Implements ICharacter

    Private Sub New(world As IWorld, data As WorldData, characterId As Guid)
        MyBase.New(world, data)
        Me.CharacterId = characterId
    End Sub

    Public ReadOnly Property CharacterId As Guid Implements ICharacter.CharacterId

    Protected Overrides ReadOnly Property Data As CharacterData
        Get
            Return _data.Characters(CharacterId)
        End Get
    End Property

    Friend Shared Function Create(world As IWorld, data As WorldData, characterId As Guid?) As ICharacter
        Return If(characterId.HasValue, New Character(world, data, characterId.Value), Nothing)
    End Function
End Class

Imports KJ.Persistence

Friend Class CharacterModel
    Implements ICharacterModel

    Private ReadOnly character As ICharacter

    Private Sub New(character As ICharacter)
        Me.character = character
    End Sub

    Public ReadOnly Property Name As String Implements ICharacterModel.Name
        Get
            Return character.GetName
        End Get
    End Property

    Friend Shared Function Create(character As ICharacter) As ICharacterModel
        Return New CharacterModel(character)
    End Function
End Class

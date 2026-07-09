Imports System.Runtime.CompilerServices
Imports KJ.Persistence

Friend Module CharacterExtensions
    <Extension>
    Private Function IsAvatar(character As ICharacter) As Boolean
        Return If(character.World.Avatar?.CharacterId = character.CharacterId, False)
    End Function
    <Extension>
    Private Sub AddMessage(
                          character As ICharacter,
                          text As String,
                          Optional hints As IDictionary(Of String, String) = Nothing)
        If character.IsAvatar() Then
            character.World.AddMessage(text, hints)
        End If
    End Sub
    <Extension>
    Friend Sub Look(character As ICharacter)
        Dim location = character.Location
        character.AddMessage($"{character.GetName()} is in {location.GetName()}!")
    End Sub
End Module

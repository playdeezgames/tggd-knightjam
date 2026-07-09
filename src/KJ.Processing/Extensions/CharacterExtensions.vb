Imports System.Runtime.CompilerServices
Imports KJ.Persistence

Friend Module CharacterExtensions
    <Extension>
    Private Function IsAvatar(character As ICharacter) As Boolean
        Return If(character.World.Avatar?.CharacterId = character.CharacterId, False)
    End Function
    <Extension>
    Friend Sub AddMessage(
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
        character.AddMessage(location.GetDescription())
        Dim routes = location.Routes
        If routes.Any() Then
            character.AddMessage($"Exits:")
            For Each route In routes
                character.AddMessage($"- {route.Direction}({route.GetName})")
            Next
        End If
    End Sub
End Module

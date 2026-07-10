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
        character.AddMessage(location.GetFlavor())
        ShowExits(character, location)
        ShowFeatures(character, location)
        If location.Inventory.HasItems Then
            character.AddMessage("There are items on the ground.")
        End If
    End Sub

    Private Sub ShowFeatures(character As ICharacter, location As ILocation)
        Dim features = location.Features
        If features.Any Then
            character.AddMessage($"Features:")
            For Each feature In features
                character.AddMessage($"- {feature.GetName}")
            Next
        End If
    End Sub

    Private Sub ShowExits(character As ICharacter, location As ILocation)
        Dim routes = location.Routes
        If routes.Any() Then
            character.AddMessage($"Exits:")
            For Each route In routes
                character.AddMessage($"- {route.Direction}({route.GetName})")
            Next
        End If
    End Sub
End Module

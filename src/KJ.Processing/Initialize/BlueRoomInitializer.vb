Imports KJ.Persistence

Friend Module BlueRoomInitializer
    Friend Function Initialize(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("The Blue Room")
                   location.SetDescription("This is the Blue Room. You feel like you may have been here before.")
                   context.BlueRoom = location
                   location.CreateCharacter(InitializeAvatar(context))
               End Sub
    End Function

    Private Function InitializeAvatar(context As IInitializationContext) As CharacterInitializer
        Return Sub(character)
                   character.SetName(context.ChosenName)
                   character.SetDescription("Yer pronouns are he/him. It makes sense if you know Finnish.")
                   character.World.Avatar = character
               End Sub
    End Function
End Module

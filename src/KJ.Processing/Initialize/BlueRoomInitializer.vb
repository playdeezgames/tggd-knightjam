Imports KJ.Persistence

Friend Module BlueRoomInitializer
    Friend Function Initialize(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("The Blue Room")
                   location.SetFlavor("This is the Blue Room. You feel like you may have been here before.")
                   context.BlueRoom = location
                   location.CreateCharacter(InitializeAvatar(context))
                   location.CreateRoute(Directions.OUT, context.SouthWestTown, AddressOf InitializeBlueRoomDoor)
                   context.SouthWestTown.CreateRoute(Directions.[IN], location, AddressOf InitializeBlueRoomDoor)
#If DEBUG Then
                   location.CreateRoute(Directions.SIDEWAYS, context.PortalDestination, AddressOf InitializePortal)
#End If
               End Sub
    End Function

#If DEBUG Then
    Private Sub InitializePortal(route As IRoute)
        route.SetName("Debug Portal")
        route.SetFlavor("You use the magical debug portal to go to the place that yer actively testing.")
    End Sub
#End If

    Private Sub InitializeBlueRoomDoor(route As IRoute)
        route.SetName("Blue Door")
        route.SetFlavor("You open the blue door, go through it, and gently close it behind you.")
    End Sub

    Private Function InitializeAvatar(context As IInitializationContext) As CharacterInitializer
        Return Sub(character)
                   character.SetName(context.ChosenName)
                   character.SetFlavor("Yer pronouns are he/him. It makes sense if you know Finnish.")
                   character.World.Avatar = character
               End Sub
    End Function
End Module

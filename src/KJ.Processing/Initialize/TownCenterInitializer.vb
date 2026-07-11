Imports KJ.Persistence

Friend Module TownCenterInitializer

    Friend Function Initialize(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("town center")
                   location.SetFlavor("You find yerself in the town center.")
                   location.CreateCharacter(AddressOf InitializeZooperdan)
                   context.PortalDestination = location
                   context.CenterTown = location
               End Sub
    End Function

    Private Sub InitializeZooperdan(character As ICharacter)
        character.SetName("Zooperdan the Town Elder")
        character.SetFlavor("""Hello, my friend! Stay a while, and listen!""")
    End Sub
End Module

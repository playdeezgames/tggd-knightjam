Imports System.Runtime.CompilerServices
Imports KJ.Persistence

Friend Module EastSideInitializer
    <Extension>
    Friend Function InitializeEastTown(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("East Side of Town")
                   location.SetFlavor("You find yerself in the east side of town.")
                   context.EastTown = location
                   location.World.CreateLocation(InitializeInn(context))
                   location.CreateFeature(AddressOf InitializeSign)
               End Sub
    End Function

    Private Sub InitializeSign(feature As IFeature)
        feature.SetName("Sign")
        feature.SetFlavor("The sign reads `Jusdatip Inn`, and below it reads `Gorachan: Proprietor`.")
    End Sub

    Private Function InitializeInn(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("Inn")
                   location.SetFlavor("Yer inside Jusdatip Inn. Which is ironic, if you think about it.")
                   location.CreateRoute(Directions.OUT, context.EastTown, AddressOf InitializeInnDoor)
                   context.EastTown.CreateRoute(Directions.IN, location, AddressOf InitializeInnDoor)
#If DEBUG Then
                   context.PortalDestination = location
#End If
                   location.CreateCharacter(AddressOf InitializeGorachan)
               End Sub
    End Function

    Private Sub InitializeGorachan(character As ICharacter)
        character.SetName("Gorachan")
        character.SetFlavor("""Welcome to Jusdatip Inn, ya cunt!""(he's not vulgar, just Australian)")
        character.CreateVerb(VerbTypes.CHECK_BUTTHOLE, AddressOf InitializeCheckButthole)
    End Sub
    Private Sub InitializeCheckButthole(verb As IVerb)
        verb.SetName("Check Butthole")
        verb.SetFlavor("Gorachan sez: ""If you wanna check my butthole, you'll have to buy me dinner first, mate!"" He MIGHT be kidding.")
    End Sub

    Private Sub InitializeInnDoor(route As IRoute)
        route.SetName("Inn Door")
        route.SetFlavor("You go through a door. It is made of wood. Hard, HARD wood. So hard, you can't believe it.")
    End Sub
End Module

Imports KJ.Persistence

Friend Module AbandonedHouseInitializer
    Friend Function Initialize(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("Abandoned House")
                   location.SetFlavor("This house is abandoned. The yard is overgrown. The doors are ripped off, and the windows are made of sheetgoods. You detect the unmistakable odor of a klonkku.")
                   location.CreateRoute(Directions.OUT, context.SouthTown, AddressOf InitializeOpenDoorway)
                   context.SouthTown.CreateRoute(Directions.IN, location, AddressOf InitializeOpenDoorway)
                   location.Inventory.CreateItem(AddressOf InitializeDestroyedPrinter)
                   location.Inventory.CreateItem(AddressOf InitializePkasticBag)
                   context.AbandonedHouse = location
                   Dim basement = location.World.CreateLocation(InitializeBasement(location))
               End Sub
    End Function

    Private Function InitializeBasement(house As ILocation) As LocationInitializer
        Return Sub(location)
                   location.SetName("basement")
                   location.SetFlavor("This is the basement of the abandoned house. The stench of klonkku is overpowering.")
                   location.CreateRoute(Directions.UP, house, AddressOf InitializeStairs)
                   house.CreateRoute(Directions.DOWN, location, AddressOf InitializeStairs)
                   location.CreateFeature(AddressOf InitializeKlonkkuCorpse)
               End Sub
    End Function

    Private Sub InitializeKlonkkuCorpse(feature As IFeature)
        feature.SetName("klonkku corpse")
        feature.SetFlavor("You behold a very dead klonkku. It smells like you'd expect. For some reason, its left index finger is brown, and yer pretty sure that's not chocolate.")
        feature.CreateVerb(VerbTypes.CHECK_BUTTHOLE, AddressOf InitializeCheckKlonkkuButthole)
    End Sub

    Private Sub InitializeCheckKlonkkuButthole(verb As IVerb)
        verb.SetName("Check Butthole")
        verb.SetFlavor("Well, yer sure a curious fella, aintcha?")
    End Sub

    Private Sub InitializeStairs(route As IRoute)
        route.SetName("stairs")
        route.SetFlavor("You go up(or down) the stairs. The dev couldn't be bothered to make two different flavor texts.")
    End Sub

    Private Sub InitializePkasticBag(item As IItem)
        item.SetName("pkastic bag")
        item.SetFlavor("No, that is not a misspelling. This item is made from pkastic. You have mixed feelings about reaching inside.")
    End Sub

    Private Sub InitializeDestroyedPrinter(item As IItem)
        item.SetName("destroyed printer")
        item.SetFlavor("This printer looks like it has been thoroughly bashed to smithereens with a cricket bat.")
    End Sub

    Private Sub InitializeOpenDoorway(route As IRoute)
        route.SetName("open doorway")
        route.SetFlavor("You walk through a completely open doorway. The doors that previously hung here are gone.")
    End Sub
End Module

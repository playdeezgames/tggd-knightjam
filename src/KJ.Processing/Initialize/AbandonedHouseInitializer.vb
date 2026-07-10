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
               End Sub
    End Function

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

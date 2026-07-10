Imports KJ.Persistence

Friend Module AbandonedHouseInitializer
    Friend Function Initialize(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("Abandoned House")
                   location.SetDescription("This house is abandoned. The yard is overgrown. The doors are ripped off, and the windows are made of sheetgoods. There is probably a klonkku here.")
                   location.CreateRoute(Directions.OUT, context.SouthTown, AddressOf InitializeOpenDoorway)
                   context.SouthTown.CreateRoute(Directions.IN, location, AddressOf InitializeOpenDoorway)
                   location.Inventory.CreateItem(AddressOf InitializeDestroyedPrinter)
                   location.Inventory.CreateItem(AddressOf InitializePkasticBag)
               End Sub
    End Function

    Private Sub InitializePkasticBag(item As IItem)
        item.SetName("pkastic bag")
        item.SetDescription("No, that is not a misspelling. This item is made from pkastic. You have mixed feelings about reaching inside.")
    End Sub

    Private Sub InitializeDestroyedPrinter(item As IItem)
        item.SetName("destroyed printer")
        item.SetDescription("This printer looks like it has been thoroughly bashed to smithereens with a cricket bat.")
    End Sub

    Private Sub InitializeOpenDoorway(route As IRoute)
        route.SetName("open doorway")
        route.SetDescription("The doorway is open. The doors that previously hung here are gone.")
    End Sub
End Module

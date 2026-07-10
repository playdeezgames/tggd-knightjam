Imports KJ.Persistence

Friend Module TownInitializer
    Friend Sub Initialize(world As IWorld, context As IInitializationContext)
        world.CreateLocation(InitializeNorthWestTown(context))
        world.CreateLocation(InitializeNorthTown(context))
        world.CreateLocation(InitializeNorthEastTown(context))
        world.CreateLocation(InitializeWestTown(context))
        world.CreateLocation(InitializeCenterTown(context))
        world.CreateLocation(InitializeEastTown(context))
        world.CreateLocation(InitializeSouthWestTown(context))
        world.CreateLocation(InitializeSouthTown(context))
        world.CreateLocation(InitializeSouthEastTown(context))
        context.NorthWestTown.CreateRoute(Directions.SOUTH, context.WestTown, AddressOf InitializeRoad)
        context.WestTown.CreateRoute(Directions.NORTH, context.NorthWestTown, AddressOf InitializeRoad)
        context.NorthEastTown.CreateRoute(Directions.WEST, context.NorthTown, AddressOf InitializeRoad)
        context.NorthTown.CreateRoute(Directions.EAST, context.NorthEastTown, AddressOf InitializeRoad)
        context.SouthEastTown.CreateRoute(Directions.NORTH, context.EastTown, AddressOf InitializeRoad)
        context.EastTown.CreateRoute(Directions.SOUTH, context.SouthEastTown, AddressOf InitializeRoad)
        context.SouthWestTown.CreateRoute(Directions.EAST, context.SouthTown, AddressOf InitializeRoad)
        context.SouthTown.CreateRoute(Directions.WEST, context.SouthWestTown, AddressOf InitializeRoad)
        context.CenterTown.CreateRoute(Directions.NORTH, context.NorthTown, AddressOf InitializeRoad)
        context.NorthTown.CreateRoute(Directions.SOUTH, context.CenterTown, AddressOf InitializeRoad)
        context.CenterTown.CreateRoute(Directions.EAST, context.EastTown, AddressOf InitializeRoad)
        context.EastTown.CreateRoute(Directions.WEST, context.CenterTown, AddressOf InitializeRoad)
        context.CenterTown.CreateRoute(Directions.SOUTH, context.SouthTown, AddressOf InitializeRoad)
        context.SouthTown.CreateRoute(Directions.NORTH, context.CenterTown, AddressOf InitializeRoad)
        context.CenterTown.CreateRoute(Directions.WEST, context.WestTown, AddressOf InitializeRoad)
        context.WestTown.CreateRoute(Directions.EAST, context.CenterTown, AddressOf InitializeRoad)
    End Sub

    Private Sub InitializeRoad(route As IRoute)
        route.SetName("road")
        route.SetFlavor("You walk along a well traveled road.")
    End Sub

    Private Function InitializeSouthEastTown(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("southeast corner of town")
                   location.SetFlavor("You find yerself in the southeast corner of town.")
                   context.SouthEastTown = location
               End Sub
    End Function

    Private Function InitializeSouthTown(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("south side of town")
                   location.SetFlavor("You find yerself in the south side of town.")
                   context.SouthTown = location
               End Sub
    End Function

    Private Function InitializeSouthWestTown(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("southwest corner of town")
                   location.SetFlavor("You find yerself in the southwest corner of town.")
                   context.SouthWestTown = location
               End Sub
    End Function

    Private Function InitializeEastTown(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("east side of town")
                   location.SetFlavor("You find yerself in the east side of town.")
                   context.EastTown = location
               End Sub
    End Function

    Private Function InitializeCenterTown(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("town center")
                   location.SetFlavor("You find yerself in the town center.")
                   context.CenterTown = location
               End Sub
    End Function

    Private Function InitializeWestTown(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("west side of town")
                   location.SetFlavor("You find yerself in the west side of town.")
                   context.WestTown = location
               End Sub
    End Function

    Private Function InitializeNorthEastTown(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("northeast corner of town")
                   location.SetFlavor("You find yerself in the northeast corner of town.")
                   context.NorthEastTown = location
               End Sub
    End Function

    Private Function InitializeNorthTown(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("north side of town")
                   location.SetFlavor("You find yerself in the north side of town.")
                   context.NorthTown = location
               End Sub
    End Function

    Private Function InitializeNorthWestTown(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("northwest corner of town")
                   location.SetFlavor("You find yerself in the northwest corner of town.")
                   context.NorthWestTown = location
               End Sub
    End Function
End Module

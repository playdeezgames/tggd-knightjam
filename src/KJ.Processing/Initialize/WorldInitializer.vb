Imports System.Runtime.CompilerServices
Imports KJ.Persistence

Friend Module WorldInitializer
    <Extension>
    Friend Sub Initialize(world As IWorld, context As IInitializationContext)
        world.Clear()
        world.CreateLocation(BlueRoomInitializer.Initialize(context))
    End Sub
End Module

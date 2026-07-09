Imports KJ.Persistence

Friend Module BlueRoomInitializer
    Friend Function Initialize(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("The Blue Room")
                   location.SetDescription("This is the Blue Room. You feel like you may have been here before.")
               End Sub
    End Function
End Module

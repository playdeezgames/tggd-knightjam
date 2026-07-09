Imports KJ.Persistence

Friend Class InitializationContext
    Implements IInitializationContext
    Private Sub New(chosenName As String)
        Me.ChosenName = chosenName
    End Sub

    Public ReadOnly Property ChosenName As String Implements IInitializationContext.ChosenName

    Public Property BlueRoom As ILocation Implements IInitializationContext.BlueRoom

    Friend Shared Function Create(chosenName As String) As IInitializationContext
        Return New InitializationContext(chosenName)
    End Function
End Class

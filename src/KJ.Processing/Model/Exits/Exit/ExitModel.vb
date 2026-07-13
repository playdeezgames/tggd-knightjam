Imports KJ.Persistence

Friend Class ExitModel
    Implements IExitModel

    Private ReadOnly route As IRoute

    Private Sub New(route As IRoute)
        Me.route = route
    End Sub

    Public ReadOnly Property Direction As String Implements IExitModel.Direction
        Get
            Return route.Direction
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IExitModel.Name
        Get
            Return route.GetName()
        End Get
    End Property

    Private Delegate Function AttemptHandler(character As ICharacter, route As IRoute) As Boolean
    Private ReadOnly attemptHandlerTable As New Dictionary(Of String, AttemptHandler) From
        {
        }

    Public Sub AttemptTake() Implements IExitModel.AttemptTake
        Dim world = route.World
        world.ClearMessages()
        Dim character = world.Avatar
        Dim attemptHandler As AttemptHandler = Nothing
        If attemptHandlerTable.TryGetValue(route.RouteType, attemptHandler) Then
            If Not attemptHandler.Invoke(character, route) Then
                Return
            End If
        End If
        character.Location = route.Destination
        character.AddMessage(route.GetFlavor())
        character.Look()
    End Sub

    Friend Shared Function Create(route As IRoute) As IExitModel
        Return New ExitModel(route)
    End Function
End Class

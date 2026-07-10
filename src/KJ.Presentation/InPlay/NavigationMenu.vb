Imports KJ.Processing
Imports TGGD.Presentation

Friend Class NavigationMenu
    Inherits KJPickerMenu

    Private Sub New(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource)
        MyBase.New(context, model, previousDialog)
    End Sub

    Public Overrides ReadOnly Property PromptText As String
        Get
            Return "Now What?"
        End Get
    End Property

    Protected Overrides ReadOnly Property Launchers As IEnumerable(Of LaunchDelegate)
        Get
            Return Enumerable.Empty(Of LaunchDelegate).
                Append(AddressOf ChooseMove).
                Append(AddressOf ChooseGround).
                Append(AddressOf ChooseGameMenu)
        End Get
    End Property

    Private Function ChooseGround(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource) As IDialogChoice
        Return DialogChoice.Create(model.Ground.HasItems, "Ground...", GroundMenu.Launch(context, model, previousDialog))
    End Function

    Private Function ChooseMove(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource) As IDialogChoice
        Return DialogChoice.Create(model.Exits.HasAny, "Move...", MoveMenu.Launch(context, model, previousDialog))
    End Function

    Private Function ChooseGameMenu(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource) As IDialogChoice
        Return DialogChoice.CreateEnabled("Gämë Mënü", GameMenu.Launch(context, model, previousDialog))
    End Function

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource) As DialogSource
        Return Function() New NavigationMenu(context, model, previousDialog)
    End Function
End Class

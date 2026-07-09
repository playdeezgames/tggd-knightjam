Imports KJ.Processing
Imports TGGD.Presentation

Friend Class GameMenu
    Inherits BasePickerMenu(Of IDisplayContext, IWorldModel)

    Public Sub New(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource)
        MyBase.New(context, model, previousDialog)
    End Sub

    Public Overrides ReadOnly Property PromptText As String
        Get
            Return "Game Menu:"
        End Get
    End Property

    Protected Overrides ReadOnly Property Launchers As IEnumerable(Of LaunchDelegate)
        Get
            Return Enumerable.Empty(Of LaunchDelegate).
                Append(AddressOf ChooseContinue).
                Append(AddressOf ChooseAbandon)
        End Get
    End Property

    Private Function ChooseAbandon(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource) As IDialogChoice
        Return DialogChoice.CreateEnabled("Abandon", AddressOf ConfirmAbandon)
    End Function

    Private Function ConfirmAbandon() As IDialog
        Return ConfirmDialog(Of IDisplayContext).
            Launch(
                Context,
                "Are you sure you want to abandon?",
                AbandonActivity.Launch(Context, Model, PreviousDialog),
                InPlay.Launch(Context, Model, PreviousDialog)).Invoke()
    End Function

    Private Function ChooseContinue(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource) As IDialogChoice
        Return DialogChoice.CreateEnabled("Continue", InPlay.Launch(context, model, previousDialog))
    End Function

    Protected Overrides Sub Render()
    End Sub

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource) As DialogSource
        Return Function() New GameMenu(context, model, previousDialog)
    End Function
End Class

Imports KJ.Processing
Imports TGGD.Presentation

Friend Class NavigationMenu
    Inherits BasePickerMenu(Of IDisplayContext, IWorldModel)

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
                Append(AddressOf ChooseGameMenu)
        End Get
    End Property

    Private Function ChooseGameMenu(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource) As IDialogChoice
        Return DialogChoice.CreateEnabled("Game Menu", GameMenu.Launch(context, model, previousDialog))
    End Function

    Protected Overrides Sub Render()
        For Each message In Model.Messages
            'TODO: hints need to matter
            Context.Render(message.Text)
        Next
    End Sub

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource) As DialogSource
        Return Function() New NavigationMenu(context, model, previousDialog)
    End Function
End Class

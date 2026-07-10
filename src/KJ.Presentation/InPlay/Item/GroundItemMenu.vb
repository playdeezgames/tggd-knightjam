
Imports KJ.Processing
Imports TGGD.Presentation

Friend Class GroundItemMenu
    Inherits KJPickerMenu

    Private ReadOnly itemModel As IItemModel

    Private Sub New(
                   context As IDisplayContext,
                   model As IWorldModel,
                   previousDialog As DialogSource,
                   itemModel As IItemModel)
        MyBase.New(context, model, previousDialog)
        Me.itemModel = itemModel
    End Sub

    Public Overrides ReadOnly Property PromptText As String
        Get
            Return $"Do what with {itemModel.Name}?"
        End Get
    End Property

    Protected Overrides ReadOnly Property Launchers As IEnumerable(Of LaunchDelegate)
        Get
            Return Enumerable.Empty(Of LaunchDelegate).
                Append(AddressOf ChooseNeverMind)
        End Get
    End Property

    Friend Shared Function Launch(c As IDisplayContext, m As IWorldModel, e As DialogSource, itemModel As IItemModel) As DialogSource
        Return Function() New GroundItemMenu(c, m, e, itemModel)
    End Function

    Private Function ChooseNeverMind(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource) As IDialogChoice
        Return DialogChoice.CreateEnabled("Never Mind", GroundMenu.Launch(context, model, previousDialog))
    End Function
End Class

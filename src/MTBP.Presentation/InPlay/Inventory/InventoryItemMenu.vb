Imports MTBP.Processing
Imports TGGD.Presentation

Friend Class InventoryItemMenu
    Inherits PickerMenu

    Private ReadOnly ItemModel As IItemModel

    Private Sub New(context As IDisplayContext, model As IWorldModel, exitDialog As DialogSource, itemModel As IItemModel)
        MyBase.New(context, model, exitDialog, $"What to do with {itemModel.Text}?")
        Me.ItemModel = itemModel
    End Sub

    Protected Overrides ReadOnly Property Launchers As IEnumerable(Of LaunchDelegate)
        Get
            Return Enumerable.Empty(Of LaunchDelegate).
                Append(AddressOf ChooseNeverMind).
                Append(AddressOf ChooseDrop).
                Append(AddressOf ChooseExamine).
                Concat(CreateVerbChoices())
        End Get
    End Property

    Private Function CreateVerbChoices() As IEnumerable(Of LaunchDelegate)
        Return ItemModel.Verbs.Select(Function(x) CreateVerbChoice(x))
    End Function

    Private Function CreateVerbChoice(verbModel As IVerbModel) As LaunchDelegate
        Return Function(c, m, e)
                   Return DialogChoice.Create(True, verbModel.Text, InventoryItemVerbActivity.Launch(c, m, e, ItemModel, verbModel))
               End Function
    End Function

    Private Function ChooseDrop(context As IDisplayContext, model As IWorldModel, exitDialog As DialogSource) As IDialogChoice
        Return DialogChoice.Create(True, "Drop", DropItemActivity.Launch(context, model, exitDialog, ItemModel))
    End Function

    Private Function ChooseExamine(context As IDisplayContext, model As IWorldModel, exitDialog As DialogSource) As IDialogChoice
        Return DialogChoice.Create(True, "Examine", ExamineItemActivity.Launch(context, model, Launch(context, model, exitDialog, ItemModel), ItemModel))
    End Function

    Private Function ChooseNeverMind(
                                    context As IDisplayContext,
                                    model As IWorldModel,
                                    exitDialog As DialogSource) As IDialogChoice
        Return DialogChoice.Create(True, "Never Mind", InventoryMenu.Launch(context, model, exitDialog))
    End Function

    Friend Shared Function Launch(c As IDisplayContext, m As IWorldModel, e As DialogSource, itemModel As IItemModel) As DialogSource
        Return Function()
                   If itemModel.Exists Then
                       Return New InventoryItemMenu(c, m, e, itemModel)
                   End If
                   Return InventoryMenu.Launch(c, m, e).Invoke
               End Function
    End Function
End Class

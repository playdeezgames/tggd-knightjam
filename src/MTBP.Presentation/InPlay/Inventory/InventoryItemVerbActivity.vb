Imports MTBP.Processing
Imports TGGD.Presentation

Friend Class InventoryItemVerbActivity
    Inherits ExitableModelDialog(Of IDisplayContext, IWorldModel)

    Private ReadOnly ItemModel As IItemModel
    Private ReadOnly VerbModel As IVerbModel

    Private Sub New(context As IDisplayContext, model As IWorldModel, exitDialog As DialogSource, itemModel As IItemModel, verbModel As IVerbModel)
        MyBase.New(context, model, exitDialog)
        Me.ItemModel = itemModel
        Me.VerbModel = verbModel
    End Sub

    Friend Shared Function Launch(c As IDisplayContext, m As IWorldModel, e As DialogSource, itemModel As IItemModel, verbModel As IVerbModel) As DialogSource
        Return Function() New InventoryItemVerbActivity(c, m, e, itemModel, verbModel)
    End Function

    Public Overrides Function Run() As IDialogPrompt
        VerbModel.Perform(ItemModel)
        Return InventoryItemMenu.Launch(Context, Model, ExitDialog, ItemModel).Invoke().Run()
    End Function

End Class

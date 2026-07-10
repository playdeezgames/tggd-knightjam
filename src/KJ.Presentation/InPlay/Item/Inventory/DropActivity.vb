Imports KJ.Processing
Imports TGGD.Presentation

Friend Class DropActivity
    Inherits StackedModelDialog(Of IDisplayContext, IWorldModel)

    Private ReadOnly itemModel As IItemModel

    Private Sub New(context As IDisplayContext, model As IWorldModel, previous As DialogSource, itemModel As IItemModel)
        MyBase.New(context, model, previous)
        Me.itemModel = itemModel
    End Sub

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource, itemModel As IItemModel) As DialogSource
        Return Function() New DropActivity(context, model, previousDialog, itemModel)
    End Function

    Public Overrides Function Run() As IDialogPrompt
        itemModel.Drop()
        Return InventoryMenu.Launch(Context, Model, PreviousDialog).Invoke().Run()
    End Function
End Class

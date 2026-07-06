Imports MTBP.Processing
Imports TGGD.Presentation

Friend Class ExamineItemActivity
    Inherits ExitableModelDialog(Of IDisplayContext, IWorldModel)

    Private ReadOnly itemModel As IItemModel

    Public Sub New(context As IDisplayContext, model As IWorldModel, exitDialog As DialogSource, itemModel As IItemModel)
        MyBase.New(context, model, exitDialog)
        Me.itemModel = itemModel
    End Sub

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, dialogSource As DialogSource, itemModel As IItemModel) As DialogSource
        Return Function() New ExamineItemActivity(context, model, dialogSource, itemModel)
    End Function

    Public Overrides Function Run() As IDialogPrompt
        itemModel.Describe()
        Return ExitDialog.Invoke().Run()
    End Function
End Class

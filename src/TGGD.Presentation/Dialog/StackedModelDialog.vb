Imports TGGD.Processing

Public MustInherit Class StackedModelDialog(Of TContext As IDisplayContext, TModel As IModel)
    Inherits BaseModelDialog(Of TContext, TModel)

    Protected ReadOnly PreviousDialog As DialogSource

    Protected Sub New(
                     context As TContext,
                     model As TModel,
                     previous As DialogSource)
        MyBase.New(context, model)
        Me.PreviousDialog = previous
    End Sub
End Class

Imports KJ.Processing
Imports TGGD.Presentation

Friend Class LookActivity
    Inherits StackedModelDialog(Of IDisplayContext, IWorldModel)

    Private Sub New(context As IDisplayContext, model As IWorldModel, previous As DialogSource)
        MyBase.New(context, model, previous)
    End Sub

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource) As DialogSource
        Return Function() New LookActivity(context, model, previousDialog)
    End Function

    Public Overrides Function Run() As IDialogPrompt
        Model.Look()
        Return InPlay.Launch(Context, Model, PreviousDialog).Invoke().Run()
    End Function
End Class
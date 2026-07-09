Imports KJ.Processing
Imports TGGD.Presentation

Friend Class MoveActivity
    Inherits StackedModelDialog(Of IDisplayContext, IWorldModel)

    Private ReadOnly exitModel As IExitModel

    Private Sub New(context As IDisplayContext, model As IWorldModel, previous As DialogSource, exitModel As IExitModel)
        MyBase.New(context, model, previous)
        Me.exitModel = exitModel
    End Sub

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource, exitModel As IExitModel) As DialogSource
        Return Function() New MoveActivity(context, model, previousDialog, exitModel)
    End Function

    Public Overrides Function Run() As IDialogPrompt
        exitModel.Take()
        Return InPlay.Launch(Context, Model, PreviousDialog).Invoke().Run()
    End Function
End Class

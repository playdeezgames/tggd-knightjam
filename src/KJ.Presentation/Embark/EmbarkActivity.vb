Imports KJ.Processing
Imports TGGD.Presentation

Friend Class EmbarkActivity
    Inherits StackedModelDialog(Of IDisplayContext, IWorldModel)

    Private ReadOnly chosenName As String

    Private Sub New(context As IDisplayContext, model As IWorldModel, previous As DialogSource, chosenName As String)
        MyBase.New(context, model, previous)
        Me.chosenName = chosenName
    End Sub

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource, chosenName As String) As DialogSource
        Return Function() New EmbarkActivity(context, model, previousDialog, chosenName)
    End Function

    Public Overrides Function Run() As IDialogPrompt
        Model.Embark(chosenName)
        Return InPlay.Launch(Context, Model, PreviousDialog).Invoke().Run()
    End Function
End Class


Imports KJ.Processing
Imports TGGD.Presentation

Friend Class GroundMenu
    Inherits KJPickerMenu

    Private Sub New(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource)
        MyBase.New(context, model, previousDialog)
    End Sub

    Public Overrides ReadOnly Property PromptText As String
        Get
            Return "On the ground:"
        End Get
    End Property

    Protected Overrides ReadOnly Property Launchers As IEnumerable(Of LaunchDelegate)
        Get
            Return Enumerable.Empty(Of LaunchDelegate).
                Append(AddressOf ChooseNeverMind)
        End Get
    End Property

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource) As DialogSource
        Return Function()
                   If model.Ground.HasItems Then
                       Return New GroundMenu(context, model, previousDialog)
                   End If
                   Return InPlay.Launch(context, model, previousDialog).Invoke()
               End Function
    End Function

    Private Function ChooseNeverMind(context As IDisplayContext, model As IWorldModel, previousDialog As DialogSource) As IDialogChoice
        Return DialogChoice.CreateEnabled("Never Mind", InPlay.Launch(context, model, previousDialog))
    End Function
End Class
